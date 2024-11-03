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
        private const string GetPropertyErrorHandler = "Katuusagi.ReflectionEnhance.Editor.GetPropertyErrorHandler";
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw(this Type type, string name)
        {
            return type.GetProperty(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw(this Type type, string name)
        {
            return type.GetPropertyFast(name) ?? type.BaseType?.GetPropertyWithBase(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw(this Type type, string name)
        {
            return type.GetPropertyWithBase(name) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw(this Type type, string name, Type[] types)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw(this Type type, string name, Type[] types)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw(this Type type, string name, Type[] types)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw(this Type type, string name, Type returnType, Type[] types)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw(this Type type, string name, Type returnType, Type[] types)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw(this Type type, string name, Type returnType, Type[] types)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw(this Type type, string name, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw(this Type type, string name, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw(this Type type, string name, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw(this Type type, string name, BindingFlags bindingAttr, Type[] types)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw(this Type type, string name, BindingFlags bindingAttr, Type[] types)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, types, null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw(this Type type, string name, BindingFlags bindingAttr, Type[] types)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, types, null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, types, null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, types, null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, types, null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, types, null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, types, null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, types, null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw(this Type type, string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw(this Type type, string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw(this Type type, string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw(this Type type, string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw(this Type type, string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw(this Type type, string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw(this Type type, string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw(this Type type, string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw(this Type type, string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T>(string name)
        {
            return typeof(T).GetProperty(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T>(string name)
        {
            return typeof(T).GetPropertyFast(name) ?? typeof(T).BaseType?.GetPropertyWithBase(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T>(string name)
        {
            return typeof(T).GetPropertyWithBase(name) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T>(string name, Type returnType, Type[] types)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T>(string name, Type returnType, Type[] types)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T>(string name, Type returnType, Type[] types)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T>(string name, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T>(string name, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T>(string name, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T>(string name, BindingFlags bindingAttr, Type[] types)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T>(string name, BindingFlags bindingAttr, Type[] types)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, types, null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T>(string name, BindingFlags bindingAttr, Type[] types)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, types, null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, types, null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, types, null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, types, null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, types, null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, types, null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, types, null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, types, null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T>(string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T>(string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T>(string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T>(string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T>(string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T>(string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T>(string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T>(string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T>(string name, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, types, modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Type returnType)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Type returnType)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return type.GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Type returnType)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Type returnType)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Type returnType)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetProperty(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, SubstitutionBinder.Default, null, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetProperty(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetInstancePropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetPropertyWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetInstancePropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstancePropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetInstancePropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetPropertyErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static PropertyInfo GetStaticPropertyWithBaseAndInterfaceFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, Type returnType, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticPropertyWithBaseFullAccessRaw(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).GetInterfacesFast().Select(v => v.GetStaticPropertyFullAccess(name, binder ?? SubstitutionBinder.Default, returnType, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers)).FirstOrDefault();
        }
    }
}
