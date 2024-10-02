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
        private static ReadOnlyArray<MemberInfo> GetMemberFastRaw(this Type type, string name)
        {
            return type.GetMember(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseRaw(this Type type, string name)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMemberWithBase(name).Concat(type.GetMemberFast(name)).ToArray();
            }
            return type.GetMemberFast(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberFastRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            return type.GetMember(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseRaw(this Type type, string name, BindingFlags bindingAttr)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMemberWithBase(name, bindingAttr).Concat(type.GetMemberFast(name, bindingAttr)).ToArray();
            }
            return type.GetMemberFast(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberFullAccessRaw(this Type type, string name)
        {
            return type.GetMemberFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetInstanceMemberFullAccessRaw(this Type type, string name)
        {
            return type.GetMemberFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetStaticMemberFullAccessRaw(this Type type, string name)
        {
            return type.GetMemberFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseFullAccessRaw(this Type type, string name)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMemberWithBaseFullAccess(name).Concat(type.GetMemberFullAccess(name)).ToArray();
            }
            return type.GetMemberFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetInstanceMemberWithBaseFullAccessRaw(this Type type, string name)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetInstanceMemberWithBaseFullAccess(name).Concat(type.GetInstanceMemberFullAccess(name)).ToArray();
            }
            return type.GetInstanceMemberFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetStaticMemberWithBaseFullAccessRaw(this Type type, string name)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMemberWithBaseFullAccess(name).Concat(type.GetStaticMemberFullAccess(name)).ToArray();
            }
            return type.GetStaticMemberFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberFastRaw(this Type type, string name, MemberTypes memberTypes, BindingFlags bindingAttr)
        {
            return type.GetMember(name, memberTypes, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseRaw(this Type type, string name, MemberTypes memberTypes, BindingFlags bindingAttr)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMemberWithBase(name, memberTypes, bindingAttr).Concat(type.GetMemberFast(name, memberTypes, bindingAttr)).ToArray();
            }
            return type.GetMemberFast(name, memberTypes, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberFullAccessRaw(this Type type, string name, MemberTypes memberTypes)
        {
            return type.GetMemberFast(name, memberTypes, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetInstanceMemberFullAccessRaw(this Type type, string name, MemberTypes memberTypes)
        {
            return type.GetMemberFast(name, memberTypes, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetStaticMemberFullAccessRaw(this Type type, string name, MemberTypes memberTypes)
        {
            return type.GetMemberFast(name, memberTypes, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseFullAccessRaw(this Type type, string name, MemberTypes memberTypes)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMemberWithBaseFullAccess(name, memberTypes).Concat(type.GetMemberFullAccess(name, memberTypes)).ToArray();
            }
            return type.GetMemberFullAccess(name, memberTypes);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetInstanceMemberWithBaseFullAccessRaw(this Type type, string name, MemberTypes memberTypes)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetInstanceMemberWithBaseFullAccess(name, memberTypes).Concat(type.GetInstanceMemberFullAccess(name, memberTypes)).ToArray();
            }
            return type.GetInstanceMemberFullAccess(name, memberTypes);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetStaticMemberWithBaseFullAccessRaw(this Type type, string name, MemberTypes memberTypes)
        {
            if (type.BaseType != null)
            {
                return type.BaseType.GetMemberWithBaseFullAccess(name, memberTypes).Concat(type.GetStaticMemberFullAccess(name, memberTypes)).ToArray();
            }
            return type.GetStaticMemberFullAccess(name, memberTypes);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberFastRaw<T>(string name)
        {
            return typeof(T).GetMember(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseRaw<T>(string name)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMemberWithBase(name).Concat(typeof(T).GetMemberFast(name)).ToArray();
            }
            return typeof(T).GetMemberFast(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberFastRaw<T>(string name, BindingFlags bindingAttr)
        {
            return typeof(T).GetMember(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseRaw<T>(string name, BindingFlags bindingAttr)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMemberWithBase(name, bindingAttr).Concat(typeof(T).GetMemberFast(name, bindingAttr)).ToArray();
            }
            return typeof(T).GetMemberFast(name, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberFullAccessRaw<T>(string name)
        {
            return typeof(T).GetMemberFast(name, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetInstanceMemberFullAccessRaw<T>(string name)
        {
            return typeof(T).GetMemberFast(name, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetStaticMemberFullAccessRaw<T>(string name)
        {
            return typeof(T).GetMemberFast(name, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseFullAccessRaw<T>(string name)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMemberWithBaseFullAccess(name).Concat(typeof(T).GetMemberFullAccess(name)).ToArray();
            }
            return typeof(T).GetMemberFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetInstanceMemberWithBaseFullAccessRaw<T>(string name)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetInstanceMemberWithBaseFullAccess(name).Concat(typeof(T).GetInstanceMemberFullAccess(name)).ToArray();
            }
            return typeof(T).GetInstanceMemberFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetStaticMemberWithBaseFullAccessRaw<T>(string name)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMemberWithBaseFullAccess(name).Concat(typeof(T).GetStaticMemberFullAccess(name)).ToArray();
            }
            return typeof(T).GetStaticMemberFullAccess(name);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberFastRaw<T>(string name, MemberTypes memberTypes, BindingFlags bindingAttr)
        {
            return typeof(T).GetMember(name, memberTypes, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseRaw<T>(string name, MemberTypes memberTypes, BindingFlags bindingAttr)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMemberWithBase(name, memberTypes, bindingAttr).Concat(typeof(T).GetMemberFast(name, memberTypes, bindingAttr)).ToArray();
            }
            return typeof(T).GetMemberFast(name, memberTypes, bindingAttr);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberFullAccessRaw<T>(string name, MemberTypes memberTypes)
        {
            return typeof(T).GetMemberFast(name, memberTypes, REReflection.FullAccessLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetInstanceMemberFullAccessRaw<T>(string name, MemberTypes memberTypes)
        {
            return typeof(T).GetMemberFast(name, memberTypes, REReflection.FullAccessInstanceLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetStaticMemberFullAccessRaw<T>(string name, MemberTypes memberTypes)
        {
            return typeof(T).GetMemberFast(name, memberTypes, REReflection.FullAccessStaticLookUp);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetMemberWithBaseFullAccessRaw<T>(string name, MemberTypes memberTypes)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMemberWithBaseFullAccess(name, memberTypes).Concat(typeof(T).GetMemberFullAccess(name, memberTypes)).ToArray();
            }
            return typeof(T).GetMemberFullAccess(name, memberTypes);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetInstanceMemberWithBaseFullAccessRaw<T>(string name, MemberTypes memberTypes)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetInstanceMemberWithBaseFullAccess(name, memberTypes).Concat(typeof(T).GetInstanceMemberFullAccess(name, memberTypes)).ToArray();
            }
            return typeof(T).GetInstanceMemberFullAccess(name, memberTypes);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] {"Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)"})]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MemberInfo> GetStaticMemberWithBaseFullAccessRaw<T>(string name, MemberTypes memberTypes)
        {
            if (typeof(T).BaseType != null)
            {
                return typeof(T).BaseType.GetMemberWithBaseFullAccess(name, memberTypes).Concat(typeof(T).GetStaticMemberFullAccess(name, memberTypes)).ToArray();
            }
            return typeof(T).GetStaticMemberFullAccess(name, memberTypes);
        }
    }
}
