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
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsFastRaw(this Type type)
        {
            return type.GetConstructors();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsWithBaseRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetConstructorsWithBase().Concat(type.GetConstructorsFast()).ToArray();
            }
            return type.GetConstructorsFast();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsFastRaw(this Type type, BindingFlags bindingAttr)
        {
            return type.GetConstructors(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsWithBaseRaw(this Type type, BindingFlags bindingAttr)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetConstructorsWithBase(bindingAttr).Concat(type.GetConstructorsFast(bindingAttr)).ToArray();
            }
            return type.GetConstructorsFast(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsFullAccessRaw(this Type type)
        {
            return type.GetConstructorsFast(REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetInstanceConstructorsFullAccessRaw(this Type type)
        {
            return type.GetConstructorsFast(REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetStaticConstructorsFullAccessRaw(this Type type)
        {
            return type.GetConstructorsFast(REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetConstructorsWithBaseFullAccess().Concat(type.GetConstructorsFullAccess()).ToArray();
            }
            return type.GetConstructorsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetInstanceConstructorsWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetInstanceConstructorsWithBaseFullAccess().Concat(type.GetInstanceConstructorsFullAccess()).ToArray();
            }
            return type.GetInstanceConstructorsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetStaticConstructorsWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetConstructorsWithBaseFullAccess().Concat(type.GetStaticConstructorsFullAccess()).ToArray();
            }
            return type.GetStaticConstructorsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsFastRaw<T>()
        {
            return typeof(T).GetConstructors();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsWithBaseRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetConstructorsWithBase().Concat(typeof(T).GetConstructorsFast()).ToArray();
            }
            return typeof(T).GetConstructorsFast();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsFastRaw<T>(BindingFlags bindingAttr)
        {
            return typeof(T).GetConstructors(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsWithBaseRaw<T>(BindingFlags bindingAttr)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetConstructorsWithBase(bindingAttr).Concat(typeof(T).GetConstructorsFast(bindingAttr)).ToArray();
            }
            return typeof(T).GetConstructorsFast(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsFullAccessRaw<T>()
        {
            return typeof(T).GetConstructorsFast(REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetInstanceConstructorsFullAccessRaw<T>()
        {
            return typeof(T).GetConstructorsFast(REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetStaticConstructorsFullAccessRaw<T>()
        {
            return typeof(T).GetConstructorsFast(REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetConstructorsWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetConstructorsWithBaseFullAccess().Concat(typeof(T).GetConstructorsFullAccess()).ToArray();
            }
            return typeof(T).GetConstructorsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetInstanceConstructorsWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetInstanceConstructorsWithBaseFullAccess().Concat(typeof(T).GetInstanceConstructorsFullAccess()).ToArray();
            }
            return typeof(T).GetInstanceConstructorsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<ConstructorInfo> GetStaticConstructorsWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetConstructorsWithBaseFullAccess().Concat(typeof(T).GetStaticConstructorsFullAccess()).ToArray();
            }
            return typeof(T).GetStaticConstructorsFullAccess();
        }
    }
}
