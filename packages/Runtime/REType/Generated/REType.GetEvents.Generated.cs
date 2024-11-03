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
        private static ReadOnlyArray<EventInfo> GetEventsFastRaw(this Type type)
        {
            return type.GetEvents();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetEventsWithBase().Concat(type.GetEventsFast()).ToArray();
            }
            return type.GetEventsFast();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseAndInterfaceRaw(this Type type)
        {
            return type.GetEventsWithBase().Concat(type.GetInterfacesFast().SelectMany(v => v.GetEventsFast())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsFastRaw(this Type type, BindingFlags bindingAttr)
        {
            return type.GetEvents(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseRaw(this Type type, BindingFlags bindingAttr)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetEventsWithBase(bindingAttr).Concat(type.GetEventsFast(bindingAttr)).ToArray();
            }
            return type.GetEventsFast(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseAndInterfaceRaw(this Type type, BindingFlags bindingAttr)
        {
            return type.GetEventsWithBase(bindingAttr).Concat(type.GetInterfacesFast().SelectMany(v => v.GetEventsFast(bindingAttr))).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsFullAccessRaw(this Type type)
        {
            return type.GetEventsFast(REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetInstanceEventsFullAccessRaw(this Type type)
        {
            return type.GetEventsFast(REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetStaticEventsFullAccessRaw(this Type type)
        {
            return type.GetEventsFast(REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetEventsWithBaseFullAccess().Concat(type.GetEventsFullAccess()).ToArray();
            }
            return type.GetEventsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetInstanceEventsWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetInstanceEventsWithBaseFullAccess().Concat(type.GetInstanceEventsFullAccess()).ToArray();
            }
            return type.GetInstanceEventsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetStaticEventsWithBaseFullAccessRaw(this Type type)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetEventsWithBaseFullAccess().Concat(type.GetStaticEventsFullAccess()).ToArray();
            }
            return type.GetStaticEventsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseAndInterfaceFullAccessRaw(this Type type)
        {
            return type.GetEventsWithBaseFullAccessRaw().Concat(type.GetInterfacesFast().SelectMany(v => v.GetEventsFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetInstanceEventsWithBaseAndInterfaceFullAccessRaw(this Type type)
        {
            return type.GetInstanceEventsWithBaseFullAccessRaw().Concat(type.GetInterfacesFast().SelectMany(v => v.GetInstanceEventsFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetStaticEventsWithBaseAndInterfaceFullAccessRaw(this Type type)
        {
            return type.GetStaticEventsWithBaseFullAccessRaw().Concat(type.GetInterfacesFast().SelectMany(v => v.GetStaticEventsFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsFastRaw<T>()
        {
            return typeof(T).GetEvents();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetEventsWithBase().Concat(typeof(T).GetEventsFast()).ToArray();
            }
            return typeof(T).GetEventsFast();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseAndInterfaceRaw<T>()
        {
            return typeof(T).GetEventsWithBase().Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetEventsFast())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsFastRaw<T>(BindingFlags bindingAttr)
        {
            return typeof(T).GetEvents(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseRaw<T>(BindingFlags bindingAttr)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetEventsWithBase(bindingAttr).Concat(typeof(T).GetEventsFast(bindingAttr)).ToArray();
            }
            return typeof(T).GetEventsFast(bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseAndInterfaceRaw<T>(BindingFlags bindingAttr)
        {
            return typeof(T).GetEventsWithBase(bindingAttr).Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetEventsFast(bindingAttr))).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsFullAccessRaw<T>()
        {
            return typeof(T).GetEventsFast(REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetInstanceEventsFullAccessRaw<T>()
        {
            return typeof(T).GetEventsFast(REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetStaticEventsFullAccessRaw<T>()
        {
            return typeof(T).GetEventsFast(REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetEventsWithBaseFullAccess().Concat(typeof(T).GetEventsFullAccess()).ToArray();
            }
            return typeof(T).GetEventsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetInstanceEventsWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetInstanceEventsWithBaseFullAccess().Concat(typeof(T).GetInstanceEventsFullAccess()).ToArray();
            }
            return typeof(T).GetInstanceEventsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetStaticEventsWithBaseFullAccessRaw<T>()
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetEventsWithBaseFullAccess().Concat(typeof(T).GetStaticEventsFullAccess()).ToArray();
            }
            return typeof(T).GetStaticEventsFullAccess();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetEventsWithBaseAndInterfaceFullAccessRaw<T>()
        {
            return typeof(T).GetEventsWithBaseFullAccessRaw().Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetEventsFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetInstanceEventsWithBaseAndInterfaceFullAccessRaw<T>()
        {
            return typeof(T).GetInstanceEventsWithBaseFullAccessRaw().Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetInstanceEventsFullAccess())).ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<EventInfo> GetStaticEventsWithBaseAndInterfaceFullAccessRaw<T>()
        {
            return typeof(T).GetStaticEventsWithBaseFullAccessRaw().Concat(typeof(T).GetInterfacesFast().SelectMany(v => v.GetStaticEventsFullAccess())).ToArray();
        }
    }
}
