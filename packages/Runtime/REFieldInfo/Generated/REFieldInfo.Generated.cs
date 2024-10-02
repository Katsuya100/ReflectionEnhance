using Katuusagi.MemoizationForUnity;
using System.Linq;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REFieldInfo
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetOptionalCustomModifiersFastRaw(this global::System.Reflection.FieldInfo self)
        {
            return self.GetOptionalCustomModifiers();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetRequiredCustomModifiersFastRaw(this global::System.Reflection.FieldInfo self)
        {
            return self.GetRequiredCustomModifiers();
        }
    }
}
