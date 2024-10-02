using Mono.Cecil;
using System.Collections.Generic;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public class GetFieldErrorHandler : GetSimpleMemberErrorHandlerBase<FieldDefinition>
    {
        public override string MemberType => "field";

        public override IEnumerable<FieldDefinition> GetMembers(TypeDefinition type)
        {
            return type.Fields;
        }
    }
}
