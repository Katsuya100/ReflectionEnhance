using Katuusagi.MemoizationForUnity;
using System.Linq;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REMethodBase
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.ParameterInfo> GetParametersFastRaw(this global::System.Reflection.MethodBase self)
        {
            return self.GetParameters();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetGenericArgumentsFastRaw(this global::System.Reflection.MethodBase self)
        {
            return self.GetGenericArguments();
        }
    }
}
