using Katuusagi.ILPostProcessorCommon.Editor;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public abstract class GetSimpleMemberErrorHandlerBase<T> : GetMemberErrorHandlerBase<T>
        where T : MemberReference
    {
        public override void Check(MethodDefinition method, Instruction instruction, MethodReference called, IReadOnlyList<Instruction> argInstructions, IReadOnlyDictionary<string, object> parameters)
        {
            GetMemberParameters(parameters, called, out var type, out var name, out var bindingFlags);
            if (type.IsGenericParameter)
            {
                return;
            }

            Name = name;

            var typeDef = type.Resolve();
            var members = GetMembers(typeDef, name, bindingFlags, called.Name.Contains("WithBase"));
            if (!members.Any())
            {
                ILPPUtils.LogError("REFLECTIONENHANCE5061", "ReflectionEnhance failed.", $"\"{Name}\" {MemberType} is not found among type \"{type.FullName}\".", method, instruction);
                return;
            }
        }
    }
}
