using Mono.Cecil;
using System.Collections.Generic;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public class GetNestedTypeErrorHandler : GetSimpleMemberErrorHandlerBase<TypeDefinition>
    {
        public override string MemberType => "type";

        public override IEnumerable<TypeDefinition> GetMembers(TypeDefinition type)
        {
            return type.NestedTypes;
        }
    }
}
