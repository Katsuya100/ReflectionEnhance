using Katuusagi.ConstExpressionForUnity;
using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REEventInfo
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetOtherMethodsFullAccessRaw(this EventInfo self)
        {
            return self.GetOtherMethodsFast(true);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetAccessorsRaw(this EventInfo self)
        {
            return self.GetAccessors(false);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetAccessorsRaw(this EventInfo self, bool nonPublic)
        {
            ReadOnlyArray<MethodInfo> others = null;
            try
            {
                others = self.GetOtherMethodsFast(nonPublic);
            }
            catch (NullReferenceException)
            {
            }
            var result = new List<MethodInfo>(others?.Count ?? 0 + 3);
            var add = self.GetAddMethod(nonPublic);
            if (add != null)
            {
                result.Add(add);
            }
            var remove = self.GetRemoveMethod(nonPublic);
            if (remove != null)
            {
                result.Add(remove);
            }
            var raise = self.GetRaiseMethod(nonPublic);
            if (raise != null)
            {
                result.Add(raise);
            }

            if (others != null)
            {
                result.AddRange(others);
            }
            return result.ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetAccessorsFullAccessRaw(this EventInfo self)
        {
            return self.GetAccessors(true);
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPublicMember(this EventInfo self)
        {
            return self.GetAccessors().Count > 0;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsStaticMember(this EventInfo self)
        {
            return self.GetAccessorsFullAccess().FirstOrDefault().IsStatic;
        }
    }
}
