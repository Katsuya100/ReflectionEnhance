using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public class GetConstructorErrorHandler : GetMethodBaseErrorHandlerBase
    {
        private CallingConventions _callConvention;

        public override string MemberType => "constructor";

        public override void Check(MethodDefinition method, Instruction instruction, MethodReference called, IReadOnlyList<Instruction> argInstructions, IReadOnlyDictionary<string, object> parameters)
        {
            GetMemberParameters(parameters, called, out var type, out var bindingFlags);
            if (type.IsGenericParameter)
            {
                return;
            }

            GetTypes(parameters, called, method, instruction, out var types);

            var name = method.IsStatic ? ".cctor" : ".ctor";
            var p = types == null ? string.Empty : string.Join(", ", types?.Select(v => v.FullName));
            Name = $"{name}({p})";

            if (!TryGetParameter(parameters, "callConvention", out _callConvention))
            {
                _callConvention = CallingConventions.Any;
            }

            var typeDef = type.Resolve();
            var members = GetMembers(typeDef, null, bindingFlags, called.Name.Contains("WithBase"));
            CheckGetMethodBaseProcess(method, instruction, members, type, types, true);
        }

        public override IEnumerable<MethodDefinition> GetMembers(TypeDefinition type)
        {
            return type.Methods.Where(v => v.IsConstructor && IsSameMethodCallingConventions(v, _callConvention));
        }
    }
}
