using Katuusagi.ConstExpressionForUnity;
using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REPropertyInfo
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ParameterInfo GetIndexParameterRaw(this PropertyInfo self, string name)
        {
            return self.GetIndexParametersFast().FirstOrDefault(v => v.Name == name);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetIndexParameterTypesRaw(this PropertyInfo self)
        {
            return self.GetIndexParametersFast().Select(v => v.ParameterType).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetIndexParameterCountRaw(this PropertyInfo self)
        {
            return self.GetIndexParametersFast().Count;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasIndexParameterRaw(this PropertyInfo self)
        {
            return self.GetIndexParametersFast().Any();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasByRefIndexParameterRaw(this PropertyInfo self)
        {
            return self.GetIndexParametersFast().Any(v => v.ParameterType.IsByRef);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetAccessorsFullAccessRaw(this PropertyInfo self)
        {
            return self.GetAccessorsFast(true);
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPublicMember(this PropertyInfo self)
        {
            return self.GetAccessorsFast().Count > 0;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsStaticMember(this PropertyInfo self)
        {
            return self.GetAccessorsFullAccess().FirstOrDefault().IsStatic;
        }
    }
}
