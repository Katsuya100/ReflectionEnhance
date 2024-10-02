using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using Katuusagi.ReflectionEnhance.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine.Scripting.APIUpdating;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REAssembly
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Module GetModuleFastRaw(this Assembly asm, string name)
        {
#if ENABLE_IL2CPP
            return asm.GetModulesFast().FirstOrDefault(v => v.Name == name);
#else
            return asm.GetModule(name);
#endif
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetTypesFastRaw(this Assembly self)
        {
            return self.GetTypes();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetTypesFastAsyncRaw(this Assembly self)
        {
            return self.QueryMembersAsync(v => v.GetTypesFast());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetTypesAndUsingsRaw(this Assembly self)
        {
            return self.GetTypesAndUsingsInternal()
                        .AsSafeParallel()
                        .SelectMany(v => v)
                        .OrderBy(v => v.FullName)
                        .ToArray();
        }

        private static IEnumerable<ReadOnlyArray<Type>> GetTypesAndUsingsInternal(this Assembly self)
        {
            yield return self.GetTypesFast();
            yield return self.GetUsingGenericInstanceTypes();
            yield return self.GetUsingArrayTypes();
            yield return self.GetUsingByRefTypes();
            yield return self.GetUsingPointerTypes();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetTypesAndUsingsAsyncRaw(this Assembly self)
        {
            return self.QueryMembersAsync(v => v.GetTypesAndUsings());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingGenericInstanceTypes(this Assembly self)
        {
            if (GetUsingGenericInstanceTypesAssemblyTable().TryGetValue(self, out var result))
            {
                return result;
            }

            return ArrayCache.Types0;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingGenericInstanceTypesAsyncRaw(this Assembly self)
        {
            return self.QueryMembersAsync(v => v.GetUsingGenericInstanceTypes());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingArrayTypes(this Assembly self)
        {
            if (GetUsingArrayTypesAssemblyTable().TryGetValue(self, out var result))
            {
                return result;
            }

            return ArrayCache.Types0;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingArrayTypesAsyncRaw(this Assembly self)
        {
            return self.QueryMembersAsync(v => v.GetUsingArrayTypes());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingPointerTypes(this Assembly self)
        {
            if (GetUsingPointerTypesAssemblyTable().TryGetValue(self, out var result))
            {
                return result;
            }

            return ArrayCache.Types0;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingPointerTypesAsyncRaw(this Assembly self)
        {
            return self.QueryMembersAsync(v => v.GetUsingPointerTypes());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingByRefTypes(this Assembly self)
        {
            if (GetUsingByRefTypesAssemblyTable().TryGetValue(self, out var result))
            {
                return result;
            }

            return ArrayCache.Types0;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingByRefTypesAsyncRaw(this Assembly self)
        {
            return self.QueryMembersAsync(v => v.GetUsingByRefTypes());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<MethodBase> GetUsingGenericInstanceMethods(this Assembly self)
        {
            if (GetUsingGenericInstanceMethodsAssemblyTable().TryGetValue(self, out var result))
            {
                return result;
            }

            return Array.Empty<MethodBase>();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<MethodBase>> GetUsingGenericInstanceMethodsAsyncRaw(this Assembly self)
        {
            return self.QueryMembersAsync(v => v.GetUsingGenericInstanceMethods());
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<Assembly, ReadOnlyArray<Type>> GetUsingGenericInstanceTypesAssemblyTableRaw()
        {
            var result = REReflection.GetUsingGenericInstanceTypes().AsSafeParallel().GroupBy(v => v.Assembly).ToDictionary(v => v.Key, v => (ReadOnlyArray<Type>)v.ToArray());
            return result;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<Assembly, ReadOnlyArray<Type>> GetUsingArrayTypesAssemblyTableRaw()
        {
            var result = REReflection.GetUsingArrayTypes().AsSafeParallel().GroupBy(v => v.Assembly).ToDictionary(v => v.Key, v => (ReadOnlyArray<Type>)v.ToArray());
            return result;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<Assembly, ReadOnlyArray<Type>> GetUsingPointerTypesAssemblyTableRaw()
        {
            var result = REReflection.GetUsingPointerTypes().AsSafeParallel().GroupBy(v => v.Assembly).ToDictionary(v => v.Key, v => (ReadOnlyArray<Type>)v.ToArray());
            return result;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<Assembly, ReadOnlyArray<Type>> GetUsingByRefTypesAssemblyTableRaw()
        {
            var result = REReflection.GetUsingByRefTypes().AsSafeParallel().GroupBy(v => v.Assembly).ToDictionary(v => v.Key, v => (ReadOnlyArray<Type>)v.ToArray());
            return result;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<Assembly, ReadOnlyArray<MethodBase>> GetUsingGenericInstanceMethodsAssemblyTableRaw()
        {
            var result = REReflection.GetUsingGenericInstanceMethods().AsSafeParallel().GroupBy(v => v.DeclaringType.Assembly).ToDictionary(v => v.Key, v => (ReadOnlyArray<MethodBase>)v.ToArray());
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetTypeFastRaw(this Assembly self, string name)
        {
            return self.GetType(name);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetTypeFastRaw(this Assembly self, string name, bool throwOnError, bool ignoreCase)
        {
            return self.GetType(name, throwOnError, ignoreCase);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetTypesWithMovedRaw(this Assembly self, string typeName)
        {
            var types = GetMovedTypes(self, typeName);
            var type = self.GetTypeFast(typeName, false, false);
            if (type == null)
            {
                return types;
            }

            return types.Prepend(type).ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncHandle<ReadOnlyArray<T>> QueryMembersAsync<T>(this Assembly self, Func<Assembly, ReadOnlyArray<T>> getMembers)
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

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsReferenceToRaw(this Assembly self, Assembly cmp)
        {
            var referenced = self.GetReferencedAssembliesFast();
            var name = cmp.GetName().FullName;
            foreach (var reference in referenced)
            {
                if (reference.FullName == name)
                {
                    return true;
                }
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsReferenceFrom(this Assembly self, Assembly cmp)
        {
            return cmp.IsReferenceTo(self);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetMovedTypes(this Assembly assembly, string typeName)
        {
            var movedTypes = GetMovedTypes();
            typeName = typeName.Replace("+", "/");
            movedTypes.TryGetValue((assembly, typeName), out var result);
            return result ?? Array.Empty<Type>();
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<(Assembly, string), ReadOnlyArray<Type>> GetMovedTypesRaw()
        {
            var dataField = REType.GetInstanceFieldFullAccess<MovedFromAttribute>("data");
            var classNameField = dataField.FieldType.GetInstanceFieldFullAccess("className");
            var nameSpaceField = dataField.FieldType.GetInstanceFieldFullAccess("nameSpace");

            var result = REReflection.GetAllTypes()
                                         .AsSafeParallel()
                                         .SelectMany(type => type.GetCustomAttributes<MovedFromAttribute>(false).Select(attr => (type, attr)))
                                         .Select(v =>
                                         {
                                             var data = dataField.GetInstanceValueLowAlloc(v.attr);
                                             var sourceNamespace = nameSpaceField.GetInstanceValueFast<object, string>(ref data);
                                             if (sourceNamespace == null)
                                             {
                                                 sourceNamespace = v.type.Namespace;
                                             }

                                             var sourceClassName = classNameField.GetInstanceValueFast<object, string>(ref data);
                                             if (sourceClassName == null)
                                             {
                                                 sourceClassName = v.type.Name;
                                             }

                                             string sourceTypeName = sourceClassName;
                                             if (!string.IsNullOrEmpty(sourceNamespace))
                                             {
                                                 sourceTypeName = $"{sourceNamespace}.{sourceClassName}";
                                             }

                                             return (v.type, sourceTypeName);
                                         })
                                         .GroupBy(v => (v.type.Assembly, v.sourceTypeName))
                                         .ToDictionary(v => v.Key, v => (ReadOnlyArray<Type>)v.Select(v => v.type).ToArray());
            return result;
        }
    }
}
