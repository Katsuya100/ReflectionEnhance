using Katuusagi.ILPostProcessorCommon.Editor;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public abstract class GetMemberOfHasParameterErrorHandlerBase<T> : GetMemberErrorHandlerBase<T>
        where T : MemberReference
    {
        protected void CheckMembersOfHasParameter(MethodDefinition method, Instruction instruction, IEnumerable<T> members, TypeReference type)
        {
            if (!members.Any())
            {
                ILPPUtils.LogError("REFLECTIONENHANCE5061", "ReflectionEnhance failed.", $"\"{Name}\" {MemberType} is not found among type \"{type.FullName}\".", method, instruction);
                return;
            }

            if (!IsSingle(members))
            {
                ILPPUtils.LogError("REFLECTIONENHANCE5062", "ReflectionEnhance failed.", $"\"{Name}\" {MemberType} is ambiguous match found among type \"{type.FullName}\".", method, instruction);
                return;
            }
        }

        protected static bool ShrinkMembersOfHasParameter(MethodDefinition method, TypeReference type, IEnumerable<TypeReference> types, Func<T, IEnumerable<ParameterDefinition>> query, bool checkEmptyParameter, ref IEnumerable<T> members)
        {
            if (types?.Any() ?? false)
            {
                Dictionary<GenericParameter, TypeReference> typeParameters = null;
                if (type.IsGenericInstance)
                {
                    typeParameters = new Dictionary<GenericParameter, TypeReference>();
                    ILPPUtils.CreateTypeParameters(method.Module, type, typeParameters);
                }

                members = members.Where(v => query(v).Select(v => ILPPUtils.ReplaceGeneric(method.Module, v.ParameterType, typeParameters)).SequenceEqual(types, SubstitutionTypeReferenceComparer.Default));
                return true;
            }
            else if (checkEmptyParameter)
            {
                members = members.Where(v => !query(v).Any());
            }

            return false;
        }

        protected static bool IsSingle(IEnumerable<T> collection)
        {
            int i = 0;
            foreach (var elem in collection)
            {
                if (i == 1)
                {
                    return false;
                }

                ++i;
            }

            return true;
        }

        protected static void GetTypes(IReadOnlyDictionary<string, object> param, MethodReference called, MethodDefinition method, Instruction instruction, out IEnumerable<TypeReference> types)
        {
            if (TryGetParameter(param, "types", out types) && types == null)
            {
                ILPPUtils.LogError("REFLECTIONENHANCE5063", "ReflectionEnhance failed.", $"types argument is null.", method, instruction);
            }
            else if (called is GenericInstanceMethod genMethod)
            {
                var genMethodDef = genMethod.Resolve();
                var parameters = genMethodDef.GenericParameters.Select((v, i) => (v, i));
                var genArgAndParams = genMethod.GenericArguments.Select((v, i) => (v, i)).Join(parameters, v => v.i, v => v.i, (a, p) => (a.v, p.v));
                types = genArgAndParams.Where(v => v.Item2.Name != "T").Select(v => v.Item1).ToArray();
            }
        }
    }
}
