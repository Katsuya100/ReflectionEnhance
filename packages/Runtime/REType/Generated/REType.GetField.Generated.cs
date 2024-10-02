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
        private const string GetFieldErrorHandler = "Katuusagi.ReflectionEnhance.Editor.GetFieldErrorHandler";
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldFastRaw(this Type type, string name)
        {
            return type.GetField(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldWithBaseRaw(this Type type, string name)
        {
            return type.GetFieldFast(name) ?? type.BaseType?.GetFieldWithBase(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldFastRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetField(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldWithBaseRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetFieldFast(name, bindingAttr) ?? type.BaseType?.GetFieldWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldFullAccessRaw(this Type type, string name)
        {
            return type.GetFieldFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetInstanceFieldFullAccessRaw(this Type type, string name)
        {
            return type.GetFieldFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetStaticFieldFullAccessRaw(this Type type, string name)
        {
            return type.GetFieldFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetFieldFullAccess(name) ?? type.BaseType?.GetFieldWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetInstanceFieldWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetInstanceFieldFullAccess(name) ?? type.BaseType?.GetInstanceFieldWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetStaticFieldWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetStaticFieldFullAccess(name) ?? type.BaseType?.GetFieldWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldFastRaw<T>(string name)
        {
            return typeof(T).GetField(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldWithBaseRaw<T>(string name)
        {
            return typeof(T).GetFieldFast(name) ?? typeof(T).BaseType?.GetFieldWithBase(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldFastRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetField(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldWithBaseRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetFieldFast(name, bindingAttr) ?? typeof(T).BaseType?.GetFieldWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldFullAccessRaw<T>(string name)
        {
            return typeof(T).GetFieldFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetInstanceFieldFullAccessRaw<T>(string name)
        {
            return typeof(T).GetFieldFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetStaticFieldFullAccessRaw<T>(string name)
        {
            return typeof(T).GetFieldFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetFieldFullAccess(name) ?? typeof(T).BaseType?.GetFieldWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetInstanceFieldWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetInstanceFieldFullAccess(name) ?? typeof(T).BaseType?.GetInstanceFieldWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetStaticFieldWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetStaticFieldFullAccess(name) ?? typeof(T).BaseType?.GetFieldWithBaseFullAccess(name);
        }
    }
}
