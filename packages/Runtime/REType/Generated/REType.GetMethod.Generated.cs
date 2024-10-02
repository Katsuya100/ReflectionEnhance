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
        private const string GetMethodErrorHandler = "Katuusagi.ReflectionEnhance.Editor.GetMethodErrorHandler";
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw(this Type type, string name)
        {
            return type.GetMethod(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw(this Type type, string name)
        {
            return type.GetMethodFast(name) ?? type.BaseType?.GetMethodWithBase(name);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw(this Type type, string name, Type[] types)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw(this Type type, string name, Type[] types)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw(this Type type, string name, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw(this Type type, string name, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetMethodFullAccess(name) ?? type.BaseType?.GetMethodWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name) ?? type.BaseType?.GetMethodWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw(this Type type, string name, BindingFlags bindingAttr, Type[] types)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw(this Type type, string name, BindingFlags bindingAttr, Type[] types)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw(this Type type, string name, Type[] types)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw(this Type type, string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw(this Type type, string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw(this Type type, string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw(this Type type, string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw(this Type type, string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw(this Type type, string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw(this Type type, string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw(this Type type, string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw(this Type type, string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw(this Type type, string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw(this Type type, string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw(this Type type, string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw(this Type type, string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T>(string name)
        {
            return typeof(T).GetMethod(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T>(string name)
        {
            return typeof(T).GetMethodFast(name) ?? typeof(T).BaseType?.GetMethodWithBase(name);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T>(string name, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T>(string name, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetMethodFullAccess(name) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T>(string name, BindingFlags bindingAttr, Type[] types)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T>(string name, BindingFlags bindingAttr, Type[] types)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T>(string name, Type[] types)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T>(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T>(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T>(string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T>(string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T>(string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T>(string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T>(string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T>(string name, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T>(string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T>(string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T>(string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T>(string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T>(string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T>(string name, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name)
        {
            return type.GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethod(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name)
        {
            return typeof(T).GetStaticMethodFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethod(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBase(name, bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFast(name, REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetInstanceMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetInstanceMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetMethodErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static MethodInfo GetStaticMethodWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(string name, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticMethodFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetMethodWithBaseFullAccess(name, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
    }
}