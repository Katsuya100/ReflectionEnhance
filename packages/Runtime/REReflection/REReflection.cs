using Katuusagi.ConstExpressionForUnity;
using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using Katuusagi.Pool;
using Katuusagi.ReflectionEnhance.Utils;
using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

[assembly: IgnoreConstExpression]
[assembly: IgnoreStaticExpression]

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REReflection
    {
        public const BindingFlags DefaultLookUp = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
        public const BindingFlags InstanceLookUp = BindingFlags.Instance | BindingFlags.Public;
        public const BindingFlags StaticLookUp = BindingFlags.Static | BindingFlags.Public;
        public const BindingFlags FullAccessLookUp = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        public const BindingFlags FullAccessInstanceLookUp = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        public const BindingFlags FullAccessStaticLookUp = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
#if !ENABLE_IL2CPP
        private static readonly ClassInstanceMethodPointerAction<DynamicMethod> CreateDynMethod = typeof(DynamicMethod).GetInstanceMethodFullAccess("CreateDynMethod");
#endif

        public static Type TypeOf(string assembly, string name)
        {
            return null;
        }

        public static Type TypeOf(this Type type, string name)
        {
            return null;
        }

        public static FieldInfo FieldOf(this Type type, string name)
        {
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryCast<T, U>(ref T v, out U result)
        {
            if (REType.IsEqualsFast<T, U>())
            {
                result = Unsafe.As<T, U>(ref v);
                return true;
            }

            if (v is U value)
            {
                result = value;
                return true;
            }

            result = default;
            return false;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Assembly> GetAssembliesFastRaw()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Assembly LoadAssemblyFastRaw(string assemblyString)
        {
            return AppDomain.CurrentDomain.Load(assemblyString);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Assembly LoadAssemblyFastRaw(AssemblyName assemblyName)
        {
            return AppDomain.CurrentDomain.Load(assemblyName);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Assembly> GetAssembliesWithMovedRaw(string assemblyString)
        {
            var asms = GetMovedAssemblies(assemblyString);
            try
            {
                var asm = LoadAssemblyFast(assemblyString);
                if (asm == null)
                {
                    return asms;
                }
                return asms.Prepend(asm).ToArray();
            }
            catch
            {
                return asms;
            }
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetAllTypesRaw()
        {
            return GetAssembliesFast().AsSafeParallel().SelectMany(v => v.GetTypesFast()).OrderBy(v => v.FullName).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetAllTypesAsyncRaw()
        {
            return QueryMembersAsync(() => GetAllTypes());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetAllTypesAndUsingsRaw()
        {
            return GetAllTypesAndUsingsInternal()
                        .AsSafeParallel()
                        .SelectMany(v => v)
                        .OrderBy(v => v.FullName)
                        .ToArray();
        }

        private static IEnumerable<ReadOnlyArray<Type>> GetAllTypesAndUsingsInternal()
        {
            yield return GetAllTypes();
            yield return GetUsingGenericInstanceTypes();
            yield return GetUsingArrayTypes();
            yield return GetUsingByRefTypes();
            yield return GetUsingPointerTypes();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetAllTypesAndUsingsAsyncRaw()
        {
            return QueryMembersAsync(() => GetAllTypesAndUsings());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetUsingGenericInstanceTypesRaw()
        {
            return GetUsingTypes("GenericInstanceType");
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingGenericInstanceTypesAsyncRaw()
        {
            return QueryMembersAsync(() => GetUsingGenericInstanceTypes());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetUsingArrayTypesRaw()
        {
            return GetUsingTypes("ArrayType");
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingArrayTypesAsyncRaw()
        {
            return QueryMembersAsync(() => GetUsingArrayTypes());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetUsingPointerTypesRaw()
        {
            return GetUsingTypes("PointerType");
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingPointerTypesAsyncRaw()
        {
            return QueryMembersAsync(() => GetUsingPointerTypes());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetUsingByRefTypesRaw()
        {
            return GetUsingTypes("ByReferenceType");
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingByRefTypesAsyncRaw()
        {
            return QueryMembersAsync(() => GetUsingByRefTypes());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodBase> GetUsingGenericInstanceMethodsRaw()
        {
            return GetUsingMethods("GenericInstanceMethod");
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<MethodBase>> GetUsingGenericInstanceMethodsAsyncRaw()
        {
            return QueryMembersAsync(() => GetUsingGenericInstanceMethods());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetUsingTypes(string name)
        {
            var methodName = $"$CollectUsing{name}s";
            var result = new ConcurrentBag<Type>();
            Parallel.ForEach(GetAssembliesFast(), assembly =>
            {
                var type = assembly.GetTypeFast("Katuusagi.ReflectionEnhance.Generated.$$Collector");
                if (type == null)
                {
                    return;
                }

                Parallel.ForEach(GetCollectUsingTypesMethods(type, methodName), method =>
                {
                    method.InvokeStaticFast(result);
                });
            });
            var ret = result.AsSafeParallel().OrderBy(v => v.FullName).Distinct().ToArray();
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IEnumerable<MethodInfo> GetCollectUsingTypesMethods(Type type, string methodName)
        {
            for (int i = 0; true; ++i)
            {
                var method = type.GetStaticMethodFullAccess($"{methodName}{i}");
                if (method == null)
                {
                    break;
                }

                yield return method;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<MethodBase> GetUsingMethods(string name)
        {
            var methodName = $"$CollectUsing{name}s";
            var result = new ConcurrentBag<MethodBase>();
            Parallel.ForEach(GetAssembliesFast(), assembly =>
            {
                var type = assembly.GetTypeFast("Katuusagi.ReflectionEnhance.Generated.$$Collector");
                if (type == null)
                {
                    return;
                }

                Parallel.ForEach(GetCollectUsingMethodsMethods(type, methodName), method =>
                {
                    method.InvokeStaticFast(result);
                });
            });
            var ret = result.AsSafeParallel().OrderBy(v => v.Name).Distinct().ToArray();
            return ret;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static IEnumerable<MethodInfo> GetCollectUsingMethodsMethods(Type type, string methodName)
        {
            for (int i = 0; true; ++i)
            {
                var method = type.GetStaticMethodFullAccess($"{methodName}{i}");
                if (method == null)
                {
                    break;
                }

                yield return method;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncHandle<ReadOnlyArray<T>> QueryMembersAsync<T>(Func<ReadOnlyArray<T>> getMembers)
            where T : MemberInfo
        {
            var h = new MembersHandle<T>();
            Task.Run(() =>
            {
                var result = getMembers();
                h.SetResult(result);
            });
            return h;
        }

#if !ENABLE_IL2CPP
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void InitDynamicMethod(DynamicMethod method)
        {
            CreateDynMethod.Invoke(method);
        }
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsValidInputWithoutRef<T>(this Type type, int bit, ref nint pAddress)
        {
            if (REType.IsValueTypeFast<T>() || type.IsValueType)
            {
                if (type != typeof(T))
                {
                    return false;
                }
            }
            else if (!type.IsAssignableFromFast<T>())
            {
                pAddress |= bit;
                return true;
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsValidInput<T>(this Type type, int bit, ref nint pAddress)
        {
            if (type.IsEqualByRefElement<T>())
            {
                return true;
            }

            if (type.IsEqualPointerElement<T>())
            {
                return true;
            }

            return IsValidInputWithoutRef<T>(type, bit, ref pAddress);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsValidVirtualInput<TTarget>(this Type type, Type targetType, out bool isVirtualCall)
        {
            isVirtualCall = false;
            if (REType.IsValueTypeFast<TTarget>())
            {
                if (type != typeof(TTarget))
                {
                    return false;
                }
            }
            else if (!type.IsNullAssignableFromFast(targetType))
            {
                return false;
            }
            else if (type != targetType)
            {
                isVirtualCall = true;
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsValidOutput<T>(this Type type)
        {
            if (type.IsEqualByRefElement<T>())
            {
                return true;
            }

            if (type.IsEqualPointerElement<T>())
            {
                return true;
            }

            if (REType.IsValueTypeFast<T>() || type.IsValueType)
            {
                if (type != typeof(T))
                {
                    return false;
                }
            }
            else if (!type.IsAssignableTo<T>())
            {
                return false;
            }

            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object GetBox<T>(in T value, ParameterInfo parameter, out IAddressLike refValue)
        {
            refValue = null;
            if (value is IAddressLike)
            {
                var tmp = ThreadStaticBoxingPool<T>.Get(value);
                refValue = tmp as IAddressLike;
                var boxed = refValue.AsBoxed();
                return boxed;
            }

            if (!REType.IsValueTypeFast<T>() ||
                (parameter != null && !parameter.ParameterType.IsValueType))
            {
                return value;
            }

            return ThreadStaticBoxingPool<T>.Get(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static object GetBoxWithoutRef<T>(in T value)
        {
            return ThreadStaticBoxingPool<T>.Get(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Unbox<T>(object o, out T result)
        {
            ThreadStaticBoxingPool<T>.Unbox(o, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReturnBox<T>(object o)
        {
            ThreadStaticBoxingPool<T>.Return(o);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReturnBox<T>(object o, ParameterInfo parameter, IAddressLike refValue)
        {
            if (refValue != null)
            {
                refValue.ReturnBox(o);
                ThreadStaticBoxingPool<T>.Return(refValue);
                return;
            }

            if (!REType.IsValueTypeFast<T>() ||
                (parameter != null && !parameter.ParameterType.IsValueType))
            {
                return;
            }

            ThreadStaticBoxingPool<T>.Return(o);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReturnBoxWithoutRef<T>(object o)
        {
            ThreadStaticBoxingPool<T>.Return(o);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint BitCount(uint bits)
        {
            bits = (bits & 0x55555555u) + (bits >> 1 & 0x55555555u);
            bits = (bits & 0x33333333u) + (bits >> 2 & 0x33333333u);
            bits = (bits & 0x0f0f0f0fu) + (bits >> 4 & 0x0f0f0f0fu);
            bits = (bits & 0x00ff00ffu) + (bits >> 8 & 0x00ff00ffu);
            return (bits & 0x0000ffffu) + (bits >> 16 & 0x0000ffffu);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Assembly> GetMovedAssemblies(string assembly)
        {
            var movedAssemblies = GetMovedAssemblies();

            if (!movedAssemblies.TryGetValue(assembly, out var result))
            {
                var index = assembly.IndexOf(',');
                if (index >= 0)
                {
                    assembly = assembly.Substring(0, index).Trim();
                    movedAssemblies.TryGetValue(assembly, out result);
                }
            }

            return result ?? Array.Empty<Assembly>();
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<string, ReadOnlyArray<Assembly>> GetMovedAssembliesRaw()
        {
            var dataField = REType.GetInstanceFieldFullAccess<MovedFromAttribute>("data");
            var assemblyField = REType.GetInstanceFieldFullAccess(dataField.FieldType, "assembly");

            var result = GetAssembliesFast()
                                .AsSafeParallel()
                                .SelectMany(REAssembly.GetTypesFast)
                                .SelectMany(type => type.GetCustomAttributes<MovedFromAttribute>(false).Select(attr => (type, attr)))
                                .Select(v =>
                                {
                                    var data = dataField.GetInstanceValueLowAlloc(v.attr);
                                    var sourceAssembly = assemblyField.GetInstanceValueFast<object, string>(ref data);
                                    return (sourceAssembly, v.type);
                                })
                                .Where(v => !string.IsNullOrEmpty(v.sourceAssembly))
                                .GroupBy(v => v.sourceAssembly)
                                .ToDictionary(v => v.Key, v => (ReadOnlyArray<Assembly>)v.Select(v => v.type.Assembly).ToArray());
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T[] GetArrayCache<T>(ReadOnlyArray<T> types)
        {
            var result = GetArrayCache<T>(types.Count);
            types.CopyTo(result);
            return result;
        }

        [Memoization(Modifier = "internal static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T[] GetArrayCacheRaw<T>(int size)
        {
            return new T[size];
        }
    }
}
