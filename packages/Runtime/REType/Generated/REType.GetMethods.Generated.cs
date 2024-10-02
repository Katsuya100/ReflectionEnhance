using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using Katuusagi.ReflectionEnhance.Utils;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REType
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsFastRaw(this Type type)
        {
            return type.GetMethods();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsWithBaseRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMethodsWithBase().Concat(type.GetMethodsFast()).ToArray();
            }
            return type.GetMethodsFast();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsFastRaw(this Type type, BindingFlags bindingAttr)
        {
            return type.GetMethods(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsWithBaseRaw(this Type type, BindingFlags bindingAttr)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMethodsWithBase(bindingAttr).Concat(type.GetMethodsFast(bindingAttr)).ToArray();
            }
            return type.GetMethodsFast(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsFullAccessRaw(this Type type)
        {
            return type.GetMethodsFast(REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetInstanceMethodsFullAccessRaw(this Type type)
        {
            return type.GetMethodsFast(REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetStaticMethodsFullAccessRaw(this Type type)
        {
            return type.GetMethodsFast(REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMethodsWithBaseFullAccess().Concat(type.GetMethodsFullAccess()).ToArray();
            }
            return type.GetMethodsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetInstanceMethodsWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetInstanceMethodsWithBaseFullAccess().Concat(type.GetInstanceMethodsFullAccess()).ToArray();
            }
            return type.GetInstanceMethodsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetStaticMethodsWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMethodsWithBaseFullAccess().Concat(type.GetStaticMethodsFullAccess()).ToArray();
            }
            return type.GetStaticMethodsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsFastRaw<T>()
        {
            return typeof(T).GetMethods();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsWithBaseRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMethodsWithBase().Concat(typeof(T).GetMethodsFast()).ToArray();
            }
            return typeof(T).GetMethodsFast();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsFastRaw<T>(BindingFlags bindingAttr)
        {
            return typeof(T).GetMethods(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsWithBaseRaw<T>(BindingFlags bindingAttr)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMethodsWithBase(bindingAttr).Concat(typeof(T).GetMethodsFast(bindingAttr)).ToArray();
            }
            return typeof(T).GetMethodsFast(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsFullAccessRaw<T>()
        {
            return typeof(T).GetMethodsFast(REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetInstanceMethodsFullAccessRaw<T>()
        {
            return typeof(T).GetMethodsFast(REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetStaticMethodsFullAccessRaw<T>()
        {
            return typeof(T).GetMethodsFast(REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetMethodsWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMethodsWithBaseFullAccess().Concat(typeof(T).GetMethodsFullAccess()).ToArray();
            }
            return typeof(T).GetMethodsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetInstanceMethodsWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetInstanceMethodsWithBaseFullAccess().Concat(typeof(T).GetInstanceMethodsFullAccess()).ToArray();
            }
            return typeof(T).GetInstanceMethodsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodInfo> GetStaticMethodsWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMethodsWithBaseFullAccess().Concat(typeof(T).GetStaticMethodsFullAccess()).ToArray();
            }
            return typeof(T).GetStaticMethodsFullAccess();
        }
    }
}
