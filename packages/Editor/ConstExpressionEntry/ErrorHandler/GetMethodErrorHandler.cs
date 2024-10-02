using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public class GetMethodErrorHandler : GetMethodBaseErrorHandlerBase
    {
        private int? _genericParameterCount = null;
        private CallingConventions _callConvention;

        public override string MemberType => $"method";

        public override void Check(MethodDefinition method, Instruction instruction, MethodReference called, IReadOnlyList<Instruction> argInstructions, IReadOnlyDictionary<string, object> parameters)
        {
            GetMemberParameters(parameters, called, out var type, out var name, out var bindingFlags);
            if (type.IsGenericParameter)
            {
                return;
            }

            GetTypes(parameters, called, method, instruction, out var types);

            var p = types == null ? string.Empty : string.Join(", ", types?.Select(v => v.FullName));
            Name = $"{name}({p})";

            if (!TryGetParameter(parameters, "callConvention", out _callConvention))
            {
                _callConvention = CallingConventions.Any;
            }

            TryGetParameter(parameters, "genericParameterCount", out _genericParameterCount);

            var typeDef = type.Resolve();
            var members = GetMembers(typeDef, name, bindingFlags, called.Name.Contains("WithBase"));
            CheckGetMethodBaseProcess(method, instruction, members, type, types, false);
        }

        public override IEnumerable<MethodDefinition> GetMembers(TypeDefinition type)
        {
            if (_genericParameterCount != null)
            {
                return type.Methods.Where(v => IsSameMethodCallingConventions(v, _callConvention) && v.GenericParameters.Count == _genericParameterCount);
            }

            return type.Methods.Where(v => IsSameMethodCallingConventions(v, _callConvention));
        }
    }
}
