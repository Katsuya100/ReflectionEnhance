using Katuusagi.ConstExpressionForUnity;
using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using Katuusagi.Pool;
using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REEnum
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetValuesFastRaw<TEnum>(out ReadOnlyArray<TEnum> result)
        {
            if (!REType.IsEnumFast<TEnum>())
            {
                result = null;
                return false;
            }

            result = GetValuesInternal<TEnum>();
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<TEnum> GetValuesFast<TEnum>()
            where TEnum : Enum
        {
            return GetValuesInternal<TEnum>();
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<TEnum> GetValuesInternalRaw<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)) as TEnum[];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetNameFast<TEnum>(TEnum enumValue, out string result)
        {
            if (!REType.IsEnumFast<TEnum>())
            {
                result = default;
                return false;
            }

            result = GetNameInternal(enumValue);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetNameFast<TEnum>(TEnum enumValue)
            where TEnum : Enum
        {
            return GetNameInternal(enumValue);
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetNameInternalRaw<TEnum>(TEnum enumValue)
        {
            return Enum.GetName(typeof(TEnum), enumValue);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetNamesFastRaw<TEnum>(out ReadOnlyArray<string> result)
        {
            if (!REType.IsEnumFast<TEnum>())
            {
                result = null;
                return false;
            }

            result = GetNamesInternal<TEnum>();
            return true;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<string> GetNamesFast<TEnum>()
            where TEnum : Enum
        {
            return GetNamesInternal<TEnum>();
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<string> GetNamesInternalRaw<TEnum>()
        {
            return Enum.GetNames(typeof(TEnum));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParseFast<TEnum>(string name, out TEnum result)
        {
            if (!REType.IsEnumFast<TEnum>())
            {
                result = default;
                return false;
            }

            result = ParseInternal<TEnum>(name);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TEnum ParseFast<TEnum>(string name)
            where TEnum : Enum
        {
            return ParseInternal<TEnum>(name);
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TEnum ParseInternalRaw<TEnum>(string name)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParseFast<TEnum>(string name, bool ignoreCase, out TEnum result)
        {
            if (!REType.IsEnumFast<TEnum>())
            {
                result = default;
                return false;
            }

            result = ParseInternal<TEnum>(name, ignoreCase);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TEnum ParseFast<TEnum>(string name, bool ignoreCase)
            where TEnum : Enum
        {
            return ParseInternal<TEnum>(name, ignoreCase);
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static TEnum ParseInternalRaw<TEnum>(string name, bool ignoreCase)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), name, ignoreCase);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetUnderlyingTypeFastRaw<TEnum>(out Type result)
        {
            if (!REType.IsEnumFast<TEnum>())
            {
                result = null;
                return false;
            }

            result = GetUnderlyingTypeInternal<TEnum>();
            return true;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetUnderlyingTypeFast<TEnum>()
            where TEnum : Enum
        {
            return GetUnderlyingTypeInternal<TEnum>();
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetUnderlyingTypeInternalRaw<TEnum>()
        {
            return Enum.GetUnderlyingType(typeof(TEnum));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDefinedFastWithoutConstraint<TEnum>(TEnum value)
        {
            if (!REType.IsEnumFast<TEnum>())
            {
                return false;
            }

            return IsDefinedInternal(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDefinedFast<TEnum>(TEnum value)
            where TEnum : Enum
        {
            return IsDefinedInternal(value);
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsDefinedInternalRaw<TEnum>(TEnum value)
        {
            var v = ThreadStaticBoxingPool<TEnum>.Get(value);
            try
            {
                return Enum.IsDefined(typeof(TEnum), v);
            }
            finally
            {
                ThreadStaticBoxingPool<TEnum>.Return(v);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryEnumTo<TEnum, TUnderlying>(TEnum enumValue, out TUnderlying result)
        {
            if (!IsEqualsUnderlyingWithoutConstraint<TEnum, TUnderlying>())
            {
                result = default;
                return false;
            }

            result = UnsafeUtility.As<TEnum, TUnderlying>(ref enumValue);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TUnderlying EnumTo<TEnum, TUnderlying>(TEnum enumValue)
            where TEnum : Enum
        {
            if (!IsEqualsUnderlying<TEnum, TUnderlying>())
            {
                throw new InvalidCastException($"cast failed.{typeof(TEnum)} -> {typeof(TUnderlying)}");
            }

            return UnsafeUtility.As<TEnum, TUnderlying>(ref enumValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryToEnum<TUnderlying, TEnum>(TUnderlying value, out TEnum result)
        {
            if (!IsEqualsUnderlyingWithoutConstraint<TEnum, TUnderlying>())
            {
                result = default;
                return false;
            }

            result = UnsafeUtility.As<TUnderlying, TEnum>(ref value);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TEnum ToEnum<TUnderlying, TEnum>(TUnderlying value)
            where TEnum : Enum
        {
            if (!IsEqualsUnderlying<TEnum, TUnderlying>())
            {
                throw new InvalidCastException($"cast failed.{typeof(TUnderlying)} -> {typeof(TEnum)}");
            }

            return UnsafeUtility.As<TUnderlying, TEnum>(ref value);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetUnderlyingValuesFastRaw<TEnum, TUnderlying>(out ReadOnlyArray<TUnderlying> result)
        {
            if (!IsEqualsUnderlyingWithoutConstraint<TEnum, TUnderlying>())
            {
                result = null;
                return false;
            }

            result = GetUnderlyingValuesInternal<TEnum, TUnderlying>();
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<TUnderlying> GetUnderlyingValuesFast<TEnum, TUnderlying>()
            where TEnum : Enum
        {
            if (!IsEqualsUnderlying<TEnum, TUnderlying>())
            {
                throw new InvalidCastException($"cast failed.{typeof(TUnderlying)} -> {typeof(TEnum)}");
            }

            return GetUnderlyingValuesInternal<TEnum, TUnderlying>();
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<TUnderlying> GetUnderlyingValuesInternalRaw<TEnum, TUnderlying>()
        {
            var values = GetValuesInternal<TEnum>();
            var result = new TUnderlying[values.Count];
            for (int i = 0; i < values.Count; ++i)
            {
                var enumValue = values[i];
                result[i] = UnsafeUtility.As<TEnum, TUnderlying>(ref enumValue);
            }
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEqualsUnderlyingWithoutConstraintRaw<TEnum, TUnderlying>()
        {
            return REType.IsEnumFast<TEnum>() && IsEqualsUnderlyingInternal<TEnum, TUnderlying>();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqualsUnderlying<TEnum, TUnderlying>()
            where TEnum : Enum
        {
            return IsEqualsUnderlyingInternal<TEnum, TUnderlying>();
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEqualsUnderlyingInternalRaw<TEnum, TUnderlying>()
        {
            return GetUnderlyingTypeInternal<TEnum>() == typeof(TUnderlying);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasFlagLowAlloc<TEnum>(this TEnum enumValue, TEnum check)
            where TEnum : struct, Enum
        {
            var v = ThreadStaticStructOnlyBoxingPool<TEnum, Enum>.Get(check);
            try
            {
                return enumValue.HasFlag(v);
            }
            finally
            {
                ThreadStaticStructOnlyBoxingPool<TEnum, Enum>.Return(v);
            }
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSerializableEnumWithoutConstraintRaw<TEnum>()
        {
            if (!REType.IsEnumFast<TEnum>() || REType.IsGenericTypeDefinitionFast<TEnum>() || (TryGetValuesFast<TEnum>(out var values) && values.Count <= 0))
            {
                return false;
            }

            return !IsEqualsUnderlyingWithoutConstraint<TEnum, long>() && !IsEqualsUnderlyingWithoutConstraint<TEnum, ulong>();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSerializableEnumRaw<TEnum>()
            where TEnum : Enum
        {
            if (REType.IsGenericTypeDefinitionFast<TEnum>() || GetValuesFast<TEnum>().Count <= 0)
            {
                return false;
            }

            return !IsEqualsUnderlying<TEnum, long>() && !IsEqualsUnderlying<TEnum, ulong>();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSerializableEnumRaw(this Type self)
        {
            if (!self.IsEnum || self.IsGenericTypeDefinition || Enum.GetValues(self).Length <= 0)
            {
                return false;
            }

            var underlingType = self.GetEnumUnderlyingType();
            return underlingType != typeof(long) &&
                   underlingType != typeof(ulong);
        }
    }
}
