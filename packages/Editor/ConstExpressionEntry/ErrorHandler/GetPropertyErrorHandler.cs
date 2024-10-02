using Katuusagi.ILPostProcessorCommon.Editor;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public class GetPropertyErrorHandler : GetMemberOfHasParameterErrorHandlerBase<PropertyDefinition>
    {
        private CallingConventions _callConvention;

        public override string MemberType => "constructor";

        public override void Check(MethodDefinition method, Instruction instruction, MethodReference called, IReadOnlyList<Instruction> argInstructions, IReadOnlyDictionary<string, object> parameters)
        {
            GetMemberParameters(parameters, called, out var type, out var name, out var bindingFlags);
            if (type.IsGenericParameter)
            {
                return;
            }

            GetTypes(parameters, called, method, instruction, out var types);
            TryGetParameter(parameters, "returnType", out TypeReference returnType);

            Name = name;

            var typeDef = type.Resolve();
            var members = GetMembers(typeDef, name, bindingFlags, called.Name.Contains("WithBase"));
            ShrinkMembersOfHasParameter(method, type, types, v => v.Parameters, false, ref members);

            if (returnType != null)
            {
                members = members.Where(v => v.PropertyType.Is(returnType));
            }

            CheckMembersOfHasParameter(method, instruction, members, type);
        }

        public override IEnumerable<PropertyDefinition> GetMembers(TypeDefinition type)
        {
            return type.Properties;
        }
    }
}
