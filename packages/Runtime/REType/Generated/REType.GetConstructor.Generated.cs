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
        private const string GetConstructorErrorHandler = "Katuusagi.ReflectionEnhance.Editor.GetConstructorErrorHandler";
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw(this Type type, Type[] types)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw(this Type type, Type[] types)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.Types0, null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw(this Type type, BindingFlags bindingAttr, Type[] types)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw(this Type type, BindingFlags bindingAttr, Type[] types)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw(this Type type, Type[] types)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw(this Type type, Type[] types)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw(this Type type, Type[] types)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw(this Type type, Type[] types)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw(this Type type, Type[] types)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw(this Type type, Type[] types)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, types, null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw(this Type type, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw(this Type type, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw(this Type type, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw(this Type type, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw(this Type type, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw(this Type type, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw(this Type type, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw(this Type type, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw(this Type type, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw(this Type type, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw(this Type type, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw(this Type type, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw(this Type type, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw(this Type type, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T>(Type[] types)
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T>(Type[] types)
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.Types0, null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.Types0, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T>(BindingFlags bindingAttr, Type[] types)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T>(BindingFlags bindingAttr, Type[] types)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T>(Type[] types)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T>(Type[] types)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T>(Type[] types)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T>(Type[] types)
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T>(Type[] types)
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T>(Type[] types)
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, types, null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, types, null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T>(BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T>(BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T>(Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T>(Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T>(Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T>(Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T>(Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T>(Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T>(Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T>(Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T>(Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T>(Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T>(Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T>(Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, types, modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type)
        {
            return type.GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type)
        {
            return type.GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type)
        {
            return type.GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type)
        {
            return type.GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type)
        {
            return type.GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? type.BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(this Type type, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return type.GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? type.BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            return typeof(T).GetConstructor(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            return typeof(T).GetConstructorFast(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(REReflection.DefaultLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructor(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructorFast(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            return typeof(T).GetConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            return typeof(T).GetInstanceConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>()
        {
            return typeof(T).GetStaticConstructorFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), null);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(BindingFlags bindingAttr, Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFastRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructor(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBase(bindingAttr, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessInstanceLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFast(REReflection.FullAccessStaticLookUp, binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetInstanceConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetInstanceConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetInstanceConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
        [Memoization(Modifier = "public static", CompareArrayElement = true, ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetConstructorErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ConstructorInfo GetStaticConstructorWithBaseFullAccessRaw<T, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(Binder binder, CallingConventions callConvention, ParameterModifier[] modifiers)
        {
            return typeof(T).GetStaticConstructorFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers) ?? typeof(T).BaseType?.GetConstructorWithBaseFullAccess(binder ?? SubstitutionBinder.Default, callConvention, ArrayCache.MakeTypeArray<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(), modifiers);
        }
    }
}
