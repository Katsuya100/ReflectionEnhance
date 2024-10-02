using Katuusagi.ConstExpressionForUnity;
using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REMemberInfo
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsCompilerGeneratedRaw(this MemberInfo self)
        {
            return self.HasAttribute<CompilerGeneratedAttribute>() || (self.DeclaringType?.IsCompilerGenerated() ?? false);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasAttributeRaw<TAttribute>(this MemberInfo self)
            where TAttribute : Attribute
        {
            return self.GetCustomAttributes<TAttribute>(false).Any();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasAttributeRaw(this MemberInfo self, Type attribute)
        {
            return self.GetCustomAttributes(false).Any(v => v.GetType() == attribute);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ParameterInfo GetParameter(this MemberInfo self, string name)
        {
            if (self is MethodBase method)
            {
                return method.GetParameter(name);
            }
            else if (self is PropertyInfo property)
            {
                return property.GetIndexParameter(name);
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<ParameterInfo> GetAllParameters(this MemberInfo self)
        {
            if (self is MethodInfo method)
            {
                return method.GetAllParameters();
            }

            return self.GetParametersFast();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<ParameterInfo> GetParametersFast(this MemberInfo self)
        {
            if (self is MethodBase method)
            {
                return method.GetParametersFast();
            }
            else if (self is PropertyInfo property)
            {
                return property.GetIndexParametersFast();
            }

            return Array.Empty<ParameterInfo>();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetAllParameterTypes(this MemberInfo self)
        {
            if (self is MethodInfo method)
            {
                return method.GetAllParameterTypes();
            }

            return self.GetParameterTypes();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetParameterTypes(this MemberInfo self)
        {
            if (self is MethodBase method)
            {
                return method.GetParameterTypes();
            }
            else if (self is PropertyInfo property)
            {
                return property.GetIndexParameterTypes();
            }

            return ArrayCache.Types0;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetAllParameterCount(this MemberInfo self)
        {
            if (self is MethodInfo method)
            {
                return method.GetAllParameterCount();
            }

            return self.GetParameterCount();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetParameterCount(this MemberInfo self)
        {
            if (self is MethodBase method)
            {
                return method.GetParameterCount();
            }
            else if (self is PropertyInfo property)
            {
                return property.GetIndexParameterCount();
            }

            return 0;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasParameter(this MemberInfo self)
        {
            if (self is MethodBase method)
            {
                return method.HasParameter();
            }
            else if (self is PropertyInfo property)
            {
                return property.HasIndexParameter();
            }

            return false;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasParameterInAll(this MemberInfo self)
        {
            if (self is MethodInfo method)
            {
                return method.HasParameterInAll();
            }
            return false;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasByRefParameterInAll(this MemberInfo self)
        {
            if (self is MethodInfo method)
            {
                return method.HasByRefParameterInAll();
            }

            return self.HasByRefParameter();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasByRefParameter(this MemberInfo self)
        {
            if (self is MethodBase method)
            {
                return method.HasByRefParameter();
            }
            else if (self is PropertyInfo property)
            {
                return property.HasByRefIndexParameter();
            }

            return false;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSerializeField(this MemberInfo self)
        {
            if (self is FieldInfo f)
            {
                return f.IsSerializeField();
            }

            return false;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGenericDelegatable(this MemberInfo self)
        {
            if (self is MethodInfo m)
            {
                return m.IsGenericDelegatable();
            }

            return false;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPublicMember(this MemberInfo self)
        {
            if (self is Type t)
            {
                return t.IsPublic;
            }

            if (self is FieldInfo f)
            {
                return f.IsPublic;
            }

            if (self is PropertyInfo p)
            {
                return p.IsPublicMember();
            }

            if (self is MethodBase m)
            {
                return m.IsPublic;
            }

            if (self is EventInfo e)
            {
                return e.IsPublicMember();
            }

            return false;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsStaticMember(this MemberInfo self)
        {
            if (self is Type t)
            {
                return t.IsStaticMember();
            }

            if (self is FieldInfo f)
            {
                return f.IsStatic;
            }

            if (self is PropertyInfo p)
            {
                return p.IsStaticMember();
            }

            if (self is MethodBase m)
            {
                return m.IsStatic;
            }

            if (self is EventInfo e)
            {
                return e.IsStaticMember();
            }

            return false;
        }
    }
}
