using Katuusagi.MemoizationForUnity;
using System.Linq;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REEventInfo
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.MethodInfo> GetOtherMethodsFastRaw(this global::System.Reflection.EventInfo self)
        {
            return self.GetOtherMethods();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.MethodInfo> GetOtherMethodsFastRaw(this global::System.Reflection.EventInfo self, global::System.Boolean nonPublic)
        {
            return self.GetOtherMethods(nonPublic);
        }
    }
}
