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
        private static ReadOnlyArray<Type> GetNestedTypesFastRaw(this Type type)
        {
            return type.GetNestedTypes();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetNestedTypesWithBase().Concat(type.GetNestedTypesFast()).ToArray();
            }
            return type.GetNestedTypesFast();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseAndInterfaceRaw(this Type type)
        {
            return type.GetNestedTypesWithBase().Concat(type.GetInterfacesFast().SelectMany(v => v.GetNestedTypesFast())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesFastRaw(this Type type, BindingFlags bindingAttr)
        {
            return type.GetNestedTypes(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseRaw(this Type type, BindingFlags bindingAttr)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetNestedTypesWithBase(bindingAttr).Concat(type.GetNestedTypesFast(bindingAttr)).ToArray();
            }
            return type.GetNestedTypesFast(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseAndInterfaceRaw(this Type type, BindingFlags bindingAttr)
        {
            return type.GetNestedTypesWithBase(bindingAttr).Concat(type.GetInterfacesFast().SelectMany(v => v.GetNestedTypesFast(bindingAttr))).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesFullAccessRaw(this Type type)
        {
            return type.GetNestedTypesFast(REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetInstanceNestedTypesFullAccessRaw(this Type type)
        {
            return type.GetNestedTypesFast(REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetStaticNestedTypesFullAccessRaw(this Type type)
        {
            return type.GetNestedTypesFast(REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetNestedTypesWithBaseFullAccess().Concat(type.GetNestedTypesFullAccess()).ToArray();
            }
            return type.GetNestedTypesFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetInstanceNestedTypesWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetInstanceNestedTypesWithBaseFullAccess().Concat(type.GetInstanceNestedTypesFullAccess()).ToArray();
            }
            return type.GetInstanceNestedTypesFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetStaticNestedTypesWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetNestedTypesWithBaseFullAccess().Concat(type.GetStaticNestedTypesFullAccess()).ToArray();
            }
            return type.GetStaticNestedTypesFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseAndInterfaceFullAccessRaw(this Type type)
        {
            return type.GetNestedTypesWithBaseFullAccessRaw().Concat(type.GetInterfacesFast().SelectMany(v => v.GetNestedTypesFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetInstanceNestedTypesWithBaseAndInterfaceFullAccessRaw(this Type type)
        {
            return type.GetInstanceNestedTypesWithBaseFullAccessRaw().Concat(type.GetInterfacesFast().SelectMany(v => v.GetInstanceNestedTypesFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetStaticNestedTypesWithBaseAndInterfaceFullAccessRaw(this Type type)
        {
            return type.GetStaticNestedTypesWithBaseFullAccessRaw().Concat(type.GetInterfacesFast().SelectMany(v => v.GetStaticNestedTypesFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesFastRaw<T>()
        {
            return typeof(T).GetNestedTypes();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetNestedTypesWithBase().Concat(typeof(T).GetNestedTypesFast()).ToArray();
            }
            return typeof(T).GetNestedTypesFast();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseAndInterfaceRaw<T>()
        {
            return typeof(T).GetNestedTypesWithBase().Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetNestedTypesFast())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesFastRaw<T>(BindingFlags bindingAttr)
        {
            return typeof(T).GetNestedTypes(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseRaw<T>(BindingFlags bindingAttr)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetNestedTypesWithBase(bindingAttr).Concat(typeof(T).GetNestedTypesFast(bindingAttr)).ToArray();
            }
            return typeof(T).GetNestedTypesFast(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseAndInterfaceRaw<T>(BindingFlags bindingAttr)
        {
            return typeof(T).GetNestedTypesWithBase(bindingAttr).Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetNestedTypesFast(bindingAttr))).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesFullAccessRaw<T>()
        {
            return typeof(T).GetNestedTypesFast(REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetInstanceNestedTypesFullAccessRaw<T>()
        {
            return typeof(T).GetNestedTypesFast(REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetStaticNestedTypesFullAccessRaw<T>()
        {
            return typeof(T).GetNestedTypesFast(REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetNestedTypesWithBaseFullAccess().Concat(typeof(T).GetNestedTypesFullAccess()).ToArray();
            }
            return typeof(T).GetNestedTypesFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetInstanceNestedTypesWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetInstanceNestedTypesWithBaseFullAccess().Concat(typeof(T).GetInstanceNestedTypesFullAccess()).ToArray();
            }
            return typeof(T).GetInstanceNestedTypesFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetStaticNestedTypesWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetNestedTypesWithBaseFullAccess().Concat(typeof(T).GetStaticNestedTypesFullAccess()).ToArray();
            }
            return typeof(T).GetStaticNestedTypesFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetNestedTypesWithBaseAndInterfaceFullAccessRaw<T>()
        {
            return typeof(T).GetNestedTypesWithBaseFullAccessRaw().Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetNestedTypesFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetInstanceNestedTypesWithBaseAndInterfaceFullAccessRaw<T>()
        {
            return typeof(T).GetInstanceNestedTypesWithBaseFullAccessRaw().Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetInstanceNestedTypesFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetStaticNestedTypesWithBaseAndInterfaceFullAccessRaw<T>()
        {
            return typeof(T).GetStaticNestedTypesWithBaseFullAccessRaw().Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetStaticNestedTypesFullAccess())).ToArray();
        }
    }
}
