using Katuusagi.MemoizationForUnity;
using System.Linq;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REPropertyInfo
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.ParameterInfo> GetIndexParametersFastRaw(this global::System.Reflection.PropertyInfo self)
        {
            return self.GetIndexParameters();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.MethodInfo> GetAccessorsFastRaw(this global::System.Reflection.PropertyInfo self)
        {
            return self.GetAccessors();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.MethodInfo> GetAccessorsFastRaw(this global::System.Reflection.PropertyInfo self, global::System.Boolean nonPublic)
        {
            return self.GetAccessors(nonPublic);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetOptionalCustomModifiersFastRaw(this global::System.Reflection.PropertyInfo self)
        {
            return self.GetOptionalCustomModifiers();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetRequiredCustomModifiersFastRaw(this global::System.Reflection.PropertyInfo self)
        {
            return self.GetRequiredCustomModifiers();
        }
    }
}
