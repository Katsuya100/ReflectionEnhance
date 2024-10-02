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
        private const string GetNestedTypeErrorHandler = "Katuusagi.ReflectionEnhance.Editor.GetNestedTypeErrorHandler";
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeFastRaw(this Type type, string name)
        {
            return type.GetNestedType(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeWithBaseRaw(this Type type, string name)
        {
            return type.GetNestedTypeFast(name) ?? type.BaseType?.GetNestedTypeWithBase(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeFastRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetNestedType(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeWithBaseRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetNestedTypeFast(name, bindingAttr) ?? type.BaseType?.GetNestedTypeWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeFullAccessRaw(this Type type, string name)
        {
            return type.GetNestedTypeFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetInstanceNestedTypeFullAccessRaw(this Type type, string name)
        {
            return type.GetNestedTypeFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetStaticNestedTypeFullAccessRaw(this Type type, string name)
        {
            return type.GetNestedTypeFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetNestedTypeFullAccess(name) ?? type.BaseType?.GetNestedTypeWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetInstanceNestedTypeWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetInstanceNestedTypeFullAccess(name) ?? type.BaseType?.GetInstanceNestedTypeWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetStaticNestedTypeWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetStaticNestedTypeFullAccess(name) ?? type.BaseType?.GetNestedTypeWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeFastRaw<T>(string name)
        {
            return typeof(T).GetNestedType(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeWithBaseRaw<T>(string name)
        {
            return typeof(T).GetNestedTypeFast(name) ?? typeof(T).BaseType?.GetNestedTypeWithBase(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeFastRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetNestedType(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeWithBaseRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetNestedTypeFast(name, bindingAttr) ?? typeof(T).BaseType?.GetNestedTypeWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeFullAccessRaw<T>(string name)
        {
            return typeof(T).GetNestedTypeFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetInstanceNestedTypeFullAccessRaw<T>(string name)
        {
            return typeof(T).GetNestedTypeFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetStaticNestedTypeFullAccessRaw<T>(string name)
        {
            return typeof(T).GetNestedTypeFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetNestedTypeWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetNestedTypeFullAccess(name) ?? typeof(T).BaseType?.GetNestedTypeWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetInstanceNestedTypeWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetInstanceNestedTypeFullAccess(name) ?? typeof(T).BaseType?.GetInstanceNestedTypeWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetNestedTypeErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetStaticNestedTypeWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetStaticNestedTypeFullAccess(name) ?? typeof(T).BaseType?.GetNestedTypeWithBaseFullAccess(name);
        }
    }
}
