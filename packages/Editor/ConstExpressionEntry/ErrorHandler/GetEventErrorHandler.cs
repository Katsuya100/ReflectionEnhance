using Mono.Cecil;
using System.Collections.Generic;

namespace Katuusagi.ReflectionEnhance.Editor
{
    public class GetEventErrorHandler : GetSimpleMemberErrorHandlerBase<EventDefinition>
    {
        public override string MemberType => "event";

        public override IEnumerable<EventDefinition> GetMembers(TypeDefinition type)
        {
            return type.Events;
        }
    }
}
