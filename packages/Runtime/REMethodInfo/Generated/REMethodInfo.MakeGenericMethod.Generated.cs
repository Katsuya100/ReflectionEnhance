using Katuusagi.MemoizationForUnity;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REMethodInfo
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0>(this MethodInfo self)
        {
            ArrayCache.Types1[0] = typeof(TArg0);
            return self.MakeGenericMethodFast(ArrayCache.Types1);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0)
        {
            ArrayCache.Types1[0] = arg0;
            return self.MakeGenericMethodFast(ArrayCache.Types1);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1>(this MethodInfo self)
        {
            ArrayCache.Types2[0] = typeof(TArg0);
            ArrayCache.Types2[1] = typeof(TArg1);
            return self.MakeGenericMethodFast(ArrayCache.Types2);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1)
        {
            ArrayCache.Types2[0] = arg0;
            ArrayCache.Types2[1] = arg1;
            return self.MakeGenericMethodFast(ArrayCache.Types2);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2>(this MethodInfo self)
        {
            ArrayCache.Types3[0] = typeof(TArg0);
            ArrayCache.Types3[1] = typeof(TArg1);
            ArrayCache.Types3[2] = typeof(TArg2);
            return self.MakeGenericMethodFast(ArrayCache.Types3);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2)
        {
            ArrayCache.Types3[0] = arg0;
            ArrayCache.Types3[1] = arg1;
            ArrayCache.Types3[2] = arg2;
            return self.MakeGenericMethodFast(ArrayCache.Types3);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3>(this MethodInfo self)
        {
            ArrayCache.Types4[0] = typeof(TArg0);
            ArrayCache.Types4[1] = typeof(TArg1);
            ArrayCache.Types4[2] = typeof(TArg2);
            ArrayCache.Types4[3] = typeof(TArg3);
            return self.MakeGenericMethodFast(ArrayCache.Types4);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3)
        {
            ArrayCache.Types4[0] = arg0;
            ArrayCache.Types4[1] = arg1;
            ArrayCache.Types4[2] = arg2;
            ArrayCache.Types4[3] = arg3;
            return self.MakeGenericMethodFast(ArrayCache.Types4);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this MethodInfo self)
        {
            ArrayCache.Types5[0] = typeof(TArg0);
            ArrayCache.Types5[1] = typeof(TArg1);
            ArrayCache.Types5[2] = typeof(TArg2);
            ArrayCache.Types5[3] = typeof(TArg3);
            ArrayCache.Types5[4] = typeof(TArg4);
            return self.MakeGenericMethodFast(ArrayCache.Types5);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4)
        {
            ArrayCache.Types5[0] = arg0;
            ArrayCache.Types5[1] = arg1;
            ArrayCache.Types5[2] = arg2;
            ArrayCache.Types5[3] = arg3;
            ArrayCache.Types5[4] = arg4;
            return self.MakeGenericMethodFast(ArrayCache.Types5);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this MethodInfo self)
        {
            ArrayCache.Types6[0] = typeof(TArg0);
            ArrayCache.Types6[1] = typeof(TArg1);
            ArrayCache.Types6[2] = typeof(TArg2);
            ArrayCache.Types6[3] = typeof(TArg3);
            ArrayCache.Types6[4] = typeof(TArg4);
            ArrayCache.Types6[5] = typeof(TArg5);
            return self.MakeGenericMethodFast(ArrayCache.Types6);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5)
        {
            ArrayCache.Types6[0] = arg0;
            ArrayCache.Types6[1] = arg1;
            ArrayCache.Types6[2] = arg2;
            ArrayCache.Types6[3] = arg3;
            ArrayCache.Types6[4] = arg4;
            ArrayCache.Types6[5] = arg5;
            return self.MakeGenericMethodFast(ArrayCache.Types6);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this MethodInfo self)
        {
            ArrayCache.Types7[0] = typeof(TArg0);
            ArrayCache.Types7[1] = typeof(TArg1);
            ArrayCache.Types7[2] = typeof(TArg2);
            ArrayCache.Types7[3] = typeof(TArg3);
            ArrayCache.Types7[4] = typeof(TArg4);
            ArrayCache.Types7[5] = typeof(TArg5);
            ArrayCache.Types7[6] = typeof(TArg6);
            return self.MakeGenericMethodFast(ArrayCache.Types7);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6)
        {
            ArrayCache.Types7[0] = arg0;
            ArrayCache.Types7[1] = arg1;
            ArrayCache.Types7[2] = arg2;
            ArrayCache.Types7[3] = arg3;
            ArrayCache.Types7[4] = arg4;
            ArrayCache.Types7[5] = arg5;
            ArrayCache.Types7[6] = arg6;
            return self.MakeGenericMethodFast(ArrayCache.Types7);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this MethodInfo self)
        {
            ArrayCache.Types8[0] = typeof(TArg0);
            ArrayCache.Types8[1] = typeof(TArg1);
            ArrayCache.Types8[2] = typeof(TArg2);
            ArrayCache.Types8[3] = typeof(TArg3);
            ArrayCache.Types8[4] = typeof(TArg4);
            ArrayCache.Types8[5] = typeof(TArg5);
            ArrayCache.Types8[6] = typeof(TArg6);
            ArrayCache.Types8[7] = typeof(TArg7);
            return self.MakeGenericMethodFast(ArrayCache.Types8);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7)
        {
            ArrayCache.Types8[0] = arg0;
            ArrayCache.Types8[1] = arg1;
            ArrayCache.Types8[2] = arg2;
            ArrayCache.Types8[3] = arg3;
            ArrayCache.Types8[4] = arg4;
            ArrayCache.Types8[5] = arg5;
            ArrayCache.Types8[6] = arg6;
            ArrayCache.Types8[7] = arg7;
            return self.MakeGenericMethodFast(ArrayCache.Types8);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this MethodInfo self)
        {
            ArrayCache.Types9[0] = typeof(TArg0);
            ArrayCache.Types9[1] = typeof(TArg1);
            ArrayCache.Types9[2] = typeof(TArg2);
            ArrayCache.Types9[3] = typeof(TArg3);
            ArrayCache.Types9[4] = typeof(TArg4);
            ArrayCache.Types9[5] = typeof(TArg5);
            ArrayCache.Types9[6] = typeof(TArg6);
            ArrayCache.Types9[7] = typeof(TArg7);
            ArrayCache.Types9[8] = typeof(TArg8);
            return self.MakeGenericMethodFast(ArrayCache.Types9);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8)
        {
            ArrayCache.Types9[0] = arg0;
            ArrayCache.Types9[1] = arg1;
            ArrayCache.Types9[2] = arg2;
            ArrayCache.Types9[3] = arg3;
            ArrayCache.Types9[4] = arg4;
            ArrayCache.Types9[5] = arg5;
            ArrayCache.Types9[6] = arg6;
            ArrayCache.Types9[7] = arg7;
            ArrayCache.Types9[8] = arg8;
            return self.MakeGenericMethodFast(ArrayCache.Types9);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this MethodInfo self)
        {
            ArrayCache.Types10[0] = typeof(TArg0);
            ArrayCache.Types10[1] = typeof(TArg1);
            ArrayCache.Types10[2] = typeof(TArg2);
            ArrayCache.Types10[3] = typeof(TArg3);
            ArrayCache.Types10[4] = typeof(TArg4);
            ArrayCache.Types10[5] = typeof(TArg5);
            ArrayCache.Types10[6] = typeof(TArg6);
            ArrayCache.Types10[7] = typeof(TArg7);
            ArrayCache.Types10[8] = typeof(TArg8);
            ArrayCache.Types10[9] = typeof(TArg9);
            return self.MakeGenericMethodFast(ArrayCache.Types10);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9)
        {
            ArrayCache.Types10[0] = arg0;
            ArrayCache.Types10[1] = arg1;
            ArrayCache.Types10[2] = arg2;
            ArrayCache.Types10[3] = arg3;
            ArrayCache.Types10[4] = arg4;
            ArrayCache.Types10[5] = arg5;
            ArrayCache.Types10[6] = arg6;
            ArrayCache.Types10[7] = arg7;
            ArrayCache.Types10[8] = arg8;
            ArrayCache.Types10[9] = arg9;
            return self.MakeGenericMethodFast(ArrayCache.Types10);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this MethodInfo self)
        {
            ArrayCache.Types11[0] = typeof(TArg0);
            ArrayCache.Types11[1] = typeof(TArg1);
            ArrayCache.Types11[2] = typeof(TArg2);
            ArrayCache.Types11[3] = typeof(TArg3);
            ArrayCache.Types11[4] = typeof(TArg4);
            ArrayCache.Types11[5] = typeof(TArg5);
            ArrayCache.Types11[6] = typeof(TArg6);
            ArrayCache.Types11[7] = typeof(TArg7);
            ArrayCache.Types11[8] = typeof(TArg8);
            ArrayCache.Types11[9] = typeof(TArg9);
            ArrayCache.Types11[10] = typeof(TArg10);
            return self.MakeGenericMethodFast(ArrayCache.Types11);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10)
        {
            ArrayCache.Types11[0] = arg0;
            ArrayCache.Types11[1] = arg1;
            ArrayCache.Types11[2] = arg2;
            ArrayCache.Types11[3] = arg3;
            ArrayCache.Types11[4] = arg4;
            ArrayCache.Types11[5] = arg5;
            ArrayCache.Types11[6] = arg6;
            ArrayCache.Types11[7] = arg7;
            ArrayCache.Types11[8] = arg8;
            ArrayCache.Types11[9] = arg9;
            ArrayCache.Types11[10] = arg10;
            return self.MakeGenericMethodFast(ArrayCache.Types11);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this MethodInfo self)
        {
            ArrayCache.Types12[0] = typeof(TArg0);
            ArrayCache.Types12[1] = typeof(TArg1);
            ArrayCache.Types12[2] = typeof(TArg2);
            ArrayCache.Types12[3] = typeof(TArg3);
            ArrayCache.Types12[4] = typeof(TArg4);
            ArrayCache.Types12[5] = typeof(TArg5);
            ArrayCache.Types12[6] = typeof(TArg6);
            ArrayCache.Types12[7] = typeof(TArg7);
            ArrayCache.Types12[8] = typeof(TArg8);
            ArrayCache.Types12[9] = typeof(TArg9);
            ArrayCache.Types12[10] = typeof(TArg10);
            ArrayCache.Types12[11] = typeof(TArg11);
            return self.MakeGenericMethodFast(ArrayCache.Types12);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11)
        {
            ArrayCache.Types12[0] = arg0;
            ArrayCache.Types12[1] = arg1;
            ArrayCache.Types12[2] = arg2;
            ArrayCache.Types12[3] = arg3;
            ArrayCache.Types12[4] = arg4;
            ArrayCache.Types12[5] = arg5;
            ArrayCache.Types12[6] = arg6;
            ArrayCache.Types12[7] = arg7;
            ArrayCache.Types12[8] = arg8;
            ArrayCache.Types12[9] = arg9;
            ArrayCache.Types12[10] = arg10;
            ArrayCache.Types12[11] = arg11;
            return self.MakeGenericMethodFast(ArrayCache.Types12);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this MethodInfo self)
        {
            ArrayCache.Types13[0] = typeof(TArg0);
            ArrayCache.Types13[1] = typeof(TArg1);
            ArrayCache.Types13[2] = typeof(TArg2);
            ArrayCache.Types13[3] = typeof(TArg3);
            ArrayCache.Types13[4] = typeof(TArg4);
            ArrayCache.Types13[5] = typeof(TArg5);
            ArrayCache.Types13[6] = typeof(TArg6);
            ArrayCache.Types13[7] = typeof(TArg7);
            ArrayCache.Types13[8] = typeof(TArg8);
            ArrayCache.Types13[9] = typeof(TArg9);
            ArrayCache.Types13[10] = typeof(TArg10);
            ArrayCache.Types13[11] = typeof(TArg11);
            ArrayCache.Types13[12] = typeof(TArg12);
            return self.MakeGenericMethodFast(ArrayCache.Types13);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12)
        {
            ArrayCache.Types13[0] = arg0;
            ArrayCache.Types13[1] = arg1;
            ArrayCache.Types13[2] = arg2;
            ArrayCache.Types13[3] = arg3;
            ArrayCache.Types13[4] = arg4;
            ArrayCache.Types13[5] = arg5;
            ArrayCache.Types13[6] = arg6;
            ArrayCache.Types13[7] = arg7;
            ArrayCache.Types13[8] = arg8;
            ArrayCache.Types13[9] = arg9;
            ArrayCache.Types13[10] = arg10;
            ArrayCache.Types13[11] = arg11;
            ArrayCache.Types13[12] = arg12;
            return self.MakeGenericMethodFast(ArrayCache.Types13);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this MethodInfo self)
        {
            ArrayCache.Types14[0] = typeof(TArg0);
            ArrayCache.Types14[1] = typeof(TArg1);
            ArrayCache.Types14[2] = typeof(TArg2);
            ArrayCache.Types14[3] = typeof(TArg3);
            ArrayCache.Types14[4] = typeof(TArg4);
            ArrayCache.Types14[5] = typeof(TArg5);
            ArrayCache.Types14[6] = typeof(TArg6);
            ArrayCache.Types14[7] = typeof(TArg7);
            ArrayCache.Types14[8] = typeof(TArg8);
            ArrayCache.Types14[9] = typeof(TArg9);
            ArrayCache.Types14[10] = typeof(TArg10);
            ArrayCache.Types14[11] = typeof(TArg11);
            ArrayCache.Types14[12] = typeof(TArg12);
            ArrayCache.Types14[13] = typeof(TArg13);
            return self.MakeGenericMethodFast(ArrayCache.Types14);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, Type arg13)
        {
            ArrayCache.Types14[0] = arg0;
            ArrayCache.Types14[1] = arg1;
            ArrayCache.Types14[2] = arg2;
            ArrayCache.Types14[3] = arg3;
            ArrayCache.Types14[4] = arg4;
            ArrayCache.Types14[5] = arg5;
            ArrayCache.Types14[6] = arg6;
            ArrayCache.Types14[7] = arg7;
            ArrayCache.Types14[8] = arg8;
            ArrayCache.Types14[9] = arg9;
            ArrayCache.Types14[10] = arg10;
            ArrayCache.Types14[11] = arg11;
            ArrayCache.Types14[12] = arg12;
            ArrayCache.Types14[13] = arg13;
            return self.MakeGenericMethodFast(ArrayCache.Types14);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this MethodInfo self)
        {
            ArrayCache.Types15[0] = typeof(TArg0);
            ArrayCache.Types15[1] = typeof(TArg1);
            ArrayCache.Types15[2] = typeof(TArg2);
            ArrayCache.Types15[3] = typeof(TArg3);
            ArrayCache.Types15[4] = typeof(TArg4);
            ArrayCache.Types15[5] = typeof(TArg5);
            ArrayCache.Types15[6] = typeof(TArg6);
            ArrayCache.Types15[7] = typeof(TArg7);
            ArrayCache.Types15[8] = typeof(TArg8);
            ArrayCache.Types15[9] = typeof(TArg9);
            ArrayCache.Types15[10] = typeof(TArg10);
            ArrayCache.Types15[11] = typeof(TArg11);
            ArrayCache.Types15[12] = typeof(TArg12);
            ArrayCache.Types15[13] = typeof(TArg13);
            ArrayCache.Types15[14] = typeof(TArg14);
            return self.MakeGenericMethodFast(ArrayCache.Types15);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, Type arg13, Type arg14)
        {
            ArrayCache.Types15[0] = arg0;
            ArrayCache.Types15[1] = arg1;
            ArrayCache.Types15[2] = arg2;
            ArrayCache.Types15[3] = arg3;
            ArrayCache.Types15[4] = arg4;
            ArrayCache.Types15[5] = arg5;
            ArrayCache.Types15[6] = arg6;
            ArrayCache.Types15[7] = arg7;
            ArrayCache.Types15[8] = arg8;
            ArrayCache.Types15[9] = arg9;
            ArrayCache.Types15[10] = arg10;
            ArrayCache.Types15[11] = arg11;
            ArrayCache.Types15[12] = arg12;
            ArrayCache.Types15[13] = arg13;
            ArrayCache.Types15[14] = arg14;
            return self.MakeGenericMethodFast(ArrayCache.Types15);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this MethodInfo self)
        {
            ArrayCache.Types16[0] = typeof(TArg0);
            ArrayCache.Types16[1] = typeof(TArg1);
            ArrayCache.Types16[2] = typeof(TArg2);
            ArrayCache.Types16[3] = typeof(TArg3);
            ArrayCache.Types16[4] = typeof(TArg4);
            ArrayCache.Types16[5] = typeof(TArg5);
            ArrayCache.Types16[6] = typeof(TArg6);
            ArrayCache.Types16[7] = typeof(TArg7);
            ArrayCache.Types16[8] = typeof(TArg8);
            ArrayCache.Types16[9] = typeof(TArg9);
            ArrayCache.Types16[10] = typeof(TArg10);
            ArrayCache.Types16[11] = typeof(TArg11);
            ArrayCache.Types16[12] = typeof(TArg12);
            ArrayCache.Types16[13] = typeof(TArg13);
            ArrayCache.Types16[14] = typeof(TArg14);
            ArrayCache.Types16[15] = typeof(TArg15);
            return self.MakeGenericMethodFast(ArrayCache.Types16);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MethodInfo MakeGenericMethodFastRaw(this MethodInfo self, Type arg0, Type arg1, Type arg2, Type arg3, Type arg4, Type arg5, Type arg6, Type arg7, Type arg8, Type arg9, Type arg10, Type arg11, Type arg12, Type arg13, Type arg14, Type arg15)
        {
            ArrayCache.Types16[0] = arg0;
            ArrayCache.Types16[1] = arg1;
            ArrayCache.Types16[2] = arg2;
            ArrayCache.Types16[3] = arg3;
            ArrayCache.Types16[4] = arg4;
            ArrayCache.Types16[5] = arg5;
            ArrayCache.Types16[6] = arg6;
            ArrayCache.Types16[7] = arg7;
            ArrayCache.Types16[8] = arg8;
            ArrayCache.Types16[9] = arg9;
            ArrayCache.Types16[10] = arg10;
            ArrayCache.Types16[11] = arg11;
            ArrayCache.Types16[12] = arg12;
            ArrayCache.Types16[13] = arg13;
            ArrayCache.Types16[14] = arg14;
            ArrayCache.Types16[15] = arg15;
            return self.MakeGenericMethodFast(ArrayCache.Types16);
        }
    }
}
