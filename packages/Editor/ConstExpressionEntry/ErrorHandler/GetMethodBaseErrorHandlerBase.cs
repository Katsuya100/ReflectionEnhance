using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Reflection;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public abstract class GetMethodBaseErrorHandlerBase : GetMemberOfHasParameterErrorHandlerBase<MethodDefinition>
    {
        protected void CheckGetMethodBaseProcess(MethodDefinition method, Instruction instruction, IEnumerable<MethodDefinition> members, TypeReference type, IEnumerable<TypeReference> types, bool checkEmptyParameter)
        {
            ShrinkMembersOfHasParameter(method, type, types, v => v.Parameters, checkEmptyParameter, ref members);
            CheckMembersOfHasParameter(method, instruction, members, type);
        }

        protected static bool IsSameMethodCallingConventions(MethodDefinition method, CallingConventions conventions)
        {
            if (method.CallingConvention != MethodCallingConvention.VarArg && (conventions | CallingConventions.Standard) != 0)
            {
                return true;
            }

            if (method.CallingConvention == MethodCallingConvention.VarArg && (conventions | CallingConventions.VarArgs) != 0)
            {
                return true;
            }

            if (method.HasThis && (conventions | CallingConventions.HasThis) != 0)
            {
                return true;
            }

            if (method.ExplicitThis && (conventions | CallingConventions.ExplicitThis) != 0)
            {
                return true;
            }

            return false;
        }
    }
}
