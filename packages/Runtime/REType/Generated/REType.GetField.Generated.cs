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
        private static FieldInfo GetFieldWithBaseAndInterfaceRaw(this Type type, string name)
        {
            return type.GetFieldWithBase(name) ?? type.GetInterfacesFast().Select(v => v.GetFieldFast(name)).FirstOrDefault();
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
        private static FieldInfo GetFieldWithBaseAndInterfaceRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetFieldWithBase(name, bindingAttr) ?? type.GetInterfacesFast().Select(v => v.GetFieldFast(name, bindingAttr)).FirstOrDefault();
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
        private static FieldInfo GetFieldWithBaseAndInterfaceFullAccessRaw(this Type type, string name)
        {
            return type.GetFieldWithBaseFullAccessRaw(name) ?? type.GetInterfacesFast().Select(v => v.GetFieldFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetInstanceFieldWithBaseAndInterfaceFullAccessRaw(this Type type, string name)
        {
            return type.GetInstanceFieldWithBaseFullAccessRaw(name) ?? type.GetInterfacesFast().Select(v => v.GetInstanceFieldFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetStaticFieldWithBaseAndInterfaceFullAccessRaw(this Type type, string name)
        {
            return type.GetStaticFieldWithBaseFullAccessRaw(name) ?? type.GetInterfacesFast().Select(v => v.GetStaticFieldFullAccess(name)).FirstOrDefault();
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
        private static FieldInfo GetFieldWithBaseAndInterfaceRaw<T>(string name)
        {
            return typeof(T).GetFieldWithBase(name) ?? typeof(T).GetInterfacesFast().Select(v => v.GetFieldFast(name)).FirstOrDefault();
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
        private static FieldInfo GetFieldWithBaseAndInterfaceRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetFieldWithBase(name, bindingAttr) ?? typeof(T).GetInterfacesFast().Select(v => v.GetFieldFast(name, bindingAttr)).FirstOrDefault();
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
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldWithBaseAndInterfaceFullAccessRaw<T>(string name)
        {
            return typeof(T).GetFieldWithBaseFullAccessRaw(name) ?? typeof(T).GetInterfacesFast().Select(v => v.GetFieldFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetInstanceFieldWithBaseAndInterfaceFullAccessRaw<T>(string name)
        {
            return typeof(T).GetInstanceFieldWithBaseFullAccessRaw(name) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstanceFieldFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetFieldErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetStaticFieldWithBaseAndInterfaceFullAccessRaw<T>(string name)
        {
            return typeof(T).GetStaticFieldWithBaseFullAccessRaw(name) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticFieldFullAccess(name)).FirstOrDefault();
        }
    }
}
