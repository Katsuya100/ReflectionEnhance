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
        private const string GetEventErrorHandler = "Katuusagi.ReflectionEnhance.Editor.GetEventErrorHandler";
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventFastRaw(this Type type, string name)
        {
            return type.GetEvent(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventWithBaseRaw(this Type type, string name)
        {
            return type.GetEventFast(name) ?? type.BaseType?.GetEventWithBase(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventFastRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetEvent(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventWithBaseRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetEventFast(name, bindingAttr) ?? type.BaseType?.GetEventWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventFullAccessRaw(this Type type, string name)
        {
            return type.GetEventFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetInstanceEventFullAccessRaw(this Type type, string name)
        {
            return type.GetEventFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetStaticEventFullAccessRaw(this Type type, string name)
        {
            return type.GetEventFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetEventFullAccess(name) ?? type.BaseType?.GetEventWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetInstanceEventWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetInstanceEventFullAccess(name) ?? type.BaseType?.GetInstanceEventWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetStaticEventWithBaseFullAccessRaw(this Type type, string name)
        {
            return type.GetStaticEventFullAccess(name) ?? type.BaseType?.GetEventWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventFastRaw<T>(string name)
        {
            return typeof(T).GetEvent(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventWithBaseRaw<T>(string name)
        {
            return typeof(T).GetEventFast(name) ?? typeof(T).BaseType?.GetEventWithBase(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventFastRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetEvent(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventWithBaseRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetEventFast(name, bindingAttr) ?? typeof(T).BaseType?.GetEventWithBase(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventFullAccessRaw<T>(string name)
        {
            return typeof(T).GetEventFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetInstanceEventFullAccessRaw<T>(string name)
        {
            return typeof(T).GetEventFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetStaticEventFullAccessRaw<T>(string name)
        {
            return typeof(T).GetEventFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetEventWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetEventFullAccess(name) ?? typeof(T).BaseType?.GetEventWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetInstanceEventWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetInstanceEventFullAccess(name) ?? typeof(T).BaseType?.GetInstanceEventWithBaseFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false, ErrorHandler = GetEventErrorHandler)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static EventInfo GetStaticEventWithBaseFullAccessRaw<T>(string name)
        {
            return typeof(T).GetStaticEventFullAccess(name) ?? typeof(T).BaseType?.GetEventWithBaseFullAccess(name);
        }
    }
}
