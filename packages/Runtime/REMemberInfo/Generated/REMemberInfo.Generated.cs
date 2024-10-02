using Katuusagi.MemoizationForUnity;
using System.Linq;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REMemberInfo
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.CustomAttributeData> GetCustomAttributesFastRaw(this global::System.Reflection.MemberInfo self)
        {
            return self.CustomAttributes.ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Object> GetCustomAttributesFastRaw(this global::System.Reflection.MemberInfo self, global::System.Boolean inherit)
        {
            return self.GetCustomAttributes(inherit);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Object> GetCustomAttributesFastRaw(this global::System.Reflection.MemberInfo self, global::System.Type attributeType, global::System.Boolean inherit)
        {
            return self.GetCustomAttributes(attributeType, inherit);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.CustomAttributeData> GetCustomAttributesDataFastRaw(this global::System.Reflection.MemberInfo self)
        {
            return self.GetCustomAttributesData().ToArray();
        }
    }
}
