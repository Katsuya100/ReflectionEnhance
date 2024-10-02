using Katuusagi.ConstExpressionForUnity;
using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using Katuusagi.ReflectionEnhance.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REMethodBase
    {
        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<MethodBase> GetUsingGenericInstanceMethods(this MethodBase self)
        {
            if (GetUsingGenericInstanceMethodsMethodTable().TryGetValue(self.MethodHandle, out var result))
            {
                return result;
            }

            return Array.Empty<MethodBase>();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<MethodBase>> GetUsingGenericInstanceMethodsAsyncRaw(this MethodBase self)
        {
            return self.QueryMembersAsync(v => v.GetUsingGenericInstanceMethods());
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<RuntimeMethodHandle, ReadOnlyArray<MethodBase>> GetUsingGenericInstanceMethodsMethodTableRaw()
        {
            var result = REReflection.GetUsingGenericInstanceMethods()
                                .AsSafeParallel()
                                .OfType<MethodInfo>()
                                .GroupBy(v => v.GetGenericMethodDefinition().MethodHandle)
                                .ToDictionary(v => v.Key, v => (ReadOnlyArray<MethodBase>)v.OfType<MethodBase>().ToArray());
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncHandle<ReadOnlyArray<T>> QueryMembersAsync<T>(this MethodBase self, Func<MethodBase, ReadOnlyArray<T>> getMembers)
            where T : MemberInfo
        {
            var h = new MembersHandle<T>();
            Task.Run(() =>
            {
                var result = getMembers(self);
                h.SetResult(result);
            });
            return h;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr GetFunctionPointer(this MethodBase self)
        {
#if ENABLE_IL2CPP
            return self.MethodHandle.Value;
#else
            return self.MethodHandle.GetFunctionPointer();
#endif
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOverridable(this MethodBase self)
        {
            return self.IsVirtual || self.IsAbstract;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ParameterInfo GetParameterRaw(this MethodBase self, string name)
        {
            return self.GetParametersFast().FirstOrDefault(v => v.Name == name);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetParameterTypesRaw(this MethodBase self)
        {
            return self.GetParametersFast().Select(v => v.ParameterType).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetParameterCountRaw(this MethodBase self)
        {
            return self.GetParametersFastRaw().Count;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasParameterRaw(this MethodBase self)
        {
            return self.GetParametersFast().Any();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasByRefParameterRaw(this MethodBase self)
        {
            return self.GetParametersFastRaw().Any(v => v.ParameterType.IsByRef);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<string> GetGenericArgumentNamesRaw(this MethodBase self)
        {
            return self.GetGenericArgumentsFast().Select(v => v.IsGenericParameter ? v.Name : v.FullName).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetGenericArgumentRaw(MethodInfo method, string name)
        {
            if (method == null ||
                !method.IsGenericMethodDefinition)
            {
                return null;
            }

            var args = method.GetGenericArgumentsFast();
            return args.FirstOrDefault(v => v.Name == name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int IndexOf(ReadOnlyArray<Type> array, Type t)
        {
            for (int i = 0; i < array.Count; ++i)
            {
                if (array[i] == t)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
