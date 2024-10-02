using Katuusagi.ILPostProcessorCommon;
using System.Reflection;

namespace Katuusagi.ReflectionEnhance
{
    internal class MembersHandle<T> : AsyncHandle<ReadOnlyArray<T>>
        where T : MemberInfo
    {
        public void SetResult(ReadOnlyArray<T> result)
        {
            SetResultInternal(result);
        }
    }
}
