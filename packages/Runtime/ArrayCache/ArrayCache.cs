using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using System.Runtime.CompilerServices;

namespace Katuusagi.ReflectionEnhance
{
    internal static partial class ArrayCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] GetArrayCache<T>(ReadOnlyArray<T> types)
        {
            var result = GetArrayCache<T>(types.Count);
            types.CopyTo(result);
            return result;
        }

        [Memoization(Modifier = "internal static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T[] GetArrayCacheRaw<T>(int size)
        {
            return new T[size];
        }

        [Memoization(Modifier = "internal static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T[] GetDefaultArrayCacheRaw<T>(int size)
        {
            return new T[size];
        }
    }
}
