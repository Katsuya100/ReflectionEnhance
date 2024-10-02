using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Katuusagi.ReflectionEnhance.Utils
{
    internal static class EnumerableUtils
    {
#if UNITY_2022_1_OR_NEWER || !ENABLE_IL2CPP
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ParallelQuery<T> AsSafeParallel<T>(this IEnumerable<T> self)
        {
            return self.AsParallel();
        }
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> AsSafeParallel<T>(this IEnumerable<T> self)
        {
            return self;
        }
#endif
    }
}
