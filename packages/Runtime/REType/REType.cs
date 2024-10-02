using Katuusagi.ConstExpressionForUnity;
using Katuusagi.ILPostProcessorCommon;
using Katuusagi.MemoizationForUnity;
using Katuusagi.ReflectionEnhance.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Katuusagi.ReflectionEnhance
{
    public static partial class REType
    {
        private class CalcHeaderDummy
        {
            public long DummyMember = 0;
        }

        private struct ClearInfo
        {
            public int Count64;
            public bool Copy32;
            public bool Copy16;
            public bool Copy8;
        }

        private static readonly Type[] SerializableFieldPrimitiveTypes = new Type[]
        {
            typeof(bool),
            typeof(sbyte),
            typeof(byte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(char),
            typeof(string),
            typeof(Enum),
            typeof(UnityEngine.Object),
            typeof(Vector2),
            typeof(Vector3),
            typeof(Vector4),
            typeof(Vector2Int),
            typeof(Vector3Int),
            typeof(Quaternion),
            typeof(Rect),
            typeof(RectInt),
            typeof(Bounds),
            typeof(BoundsInt),
            typeof(Color),
            typeof(AnimationCurve),
            typeof(ExposedReference<>)
        };

        private static readonly HashSet<Type> SerializableTypesWithHasNotSerializableAttribute = new HashSet<Type>()
        {
            typeof(Color32),
            typeof(Gradient),
            typeof(Matrix4x4),
            typeof(PropertyName),
            typeof(LayerMask),
            typeof(SphericalHarmonicsL2),
        };

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetScriptingFullNameRaw<T>()
        {
            return typeof(T).GetScriptingFullName();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetScriptingFullNameRaw(this Type self)
        {
            var stringBuilder = new StringBuilder();
            if (self.IsArray)
            {
                stringBuilder.Append(self.GetElementType().GetScriptingFullName());
                stringBuilder.Append("[");
                stringBuilder.Append(string.Join(",", Enumerable.Range(0, self.GetArrayRank()).Select(v => "")));
                stringBuilder.Append("]");
                return stringBuilder.ToString();
            }

            if (self.IsByRef)
            {
                stringBuilder.Append("ref ");
                stringBuilder.Append(self.GetElementType().GetScriptingFullName());
                return stringBuilder.ToString();
            }

            if (self.IsPointer)
            {
                stringBuilder.Append(self.GetElementType().GetScriptingFullName());
                stringBuilder.Append("*");
                return stringBuilder.ToString();
            }

            stringBuilder.Append("global::");
            if (self.ReflectedType != null)
            {
                stringBuilder.Append(self.ReflectedType.GetScriptingFullName());
                stringBuilder.Append(".");
            }
            else
            {
                if (!string.IsNullOrEmpty(self.Namespace))
                {
                    stringBuilder.Append(self.Namespace);
                    stringBuilder.Append(".");
                }
            }

            stringBuilder.Append(self.Name);

            var args = self.GetGenericArgumentsFast();
            if (args.Any())
            {
                var len = (int)Math.Log10(args.Count) + 2;
                stringBuilder.Remove(stringBuilder.Length - len, len);
                stringBuilder.Append("<");
                stringBuilder.Append(string.Join(", ", args.Select(v => v.GetScriptingFullName())));
                stringBuilder.Append(">");
            }

            return stringBuilder.ToString();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetScriptingShortNameRaw<T>()
        {
            return typeof(T).GetScriptingShortName();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetScriptingShortNameRaw(this Type self)
        {
            var stringBuilder = new StringBuilder();
            if (self.IsArray)
            {
                stringBuilder.Append(self.GetElementType().GetScriptingShortName());
                stringBuilder.Append("[");
                stringBuilder.Append(string.Join(",", Enumerable.Range(0, self.GetArrayRank()).Select(v => "")));
                stringBuilder.Append("]");
                return stringBuilder.ToString();
            }

            if (self.IsByRef)
            {
                stringBuilder.Append("ref ");
                stringBuilder.Append(self.GetElementType().GetScriptingShortName());
                return stringBuilder.ToString();
            }

            if (self.IsPointer)
            {
                stringBuilder.Append(self.GetElementType().GetScriptingShortName());
                stringBuilder.Append("*");
                return stringBuilder.ToString();
            }

            if (self == typeof(bool))
            {
                stringBuilder.Append("bool");
            }
            else if (self == typeof(sbyte))
            {
                stringBuilder.Append("sbyte");
            }
            else if (self == typeof(byte))
            {
                stringBuilder.Append("byte");
            }
            else if (self == typeof(short))
            {
                stringBuilder.Append("short");
            }
            else if (self == typeof(ushort))
            {
                stringBuilder.Append("ushort");
            }
            else if (self == typeof(int))
            {
                stringBuilder.Append("int");
            }
            else if (self == typeof(uint))
            {
                stringBuilder.Append("uint");
            }
            else if (self == typeof(long))
            {
                stringBuilder.Append("long");
            }
            else if (self == typeof(ulong))
            {
                stringBuilder.Append("ulong");
            }
            else if (self == typeof(float))
            {
                stringBuilder.Append("float");
            }
            else if (self == typeof(double))
            {
                stringBuilder.Append("double");
            }
            else if (self == typeof(decimal))
            {
                stringBuilder.Append("decimal");
            }
            else if (self == typeof(char))
            {
                stringBuilder.Append("char");
            }
            else if (self == typeof(string))
            {
                stringBuilder.Append("string");
            }
            else if (self == typeof(object))
            {
                stringBuilder.Append("object");
            }
            else
            {
                stringBuilder.Append(self.Name);
            }

            var args = self.GetGenericArgumentsFast();
            if (args.Any())
            {
                var len = (int)Math.Log10(args.Count) + 2;
                stringBuilder.Remove(stringBuilder.Length - len, len);
                stringBuilder.Append("<");
                stringBuilder.Append(string.Join(", ", args.Select(v => v.GetScriptingShortName())));
                stringBuilder.Append(">");
            }

            return stringBuilder.ToString();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetTypeFastRaw(string assemblyQualifiedName)
        {
            return Type.GetType(assemblyQualifiedName, name =>
            {
                try
                {
                    return REReflection.LoadAssemblyFast(name.FullName);
                }
                catch
                {
                    return null;
                }
            },
            (asm, name, ignore) => asm.GetTypeFast(name, false, false), false, false);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetTypeWithMovedRaw(string assemblyQualifiedName)
        {
            var index = GetTypeSeparator(assemblyQualifiedName);
            string typeName;
            ReadOnlyArray<Assembly> assemblies;
            if (index >= 0)
            {
                typeName = assemblyQualifiedName.Substring(0, index).Trim();
                var asmName = assemblyQualifiedName.Substring(index + 1).Trim();
                assemblies = REReflection.GetAssembliesWithMoved(asmName);
            }
            else
            {
                typeName = assemblyQualifiedName;
                assemblies = REReflection.GetAssembliesFast();
            }

            var result = assemblies.AsSafeParallel()
                                .SelectMany(v => v.GetTypesWithMoved(typeName))
                                .FirstOrDefault();
            if (result == null)
            {
                result = GetTypeFast(assemblyQualifiedName);
            }
            return result;
        }

        private static int GetTypeSeparator(string assemblyQualifiedName)
        {
            int index = 0;
            int separatorCount = 0;
            foreach (var c in assemblyQualifiedName)
            {
                if (c == '[')
                {
                    ++separatorCount;
                }
                else if (c == ']')
                {
                    -- separatorCount;
                }
                else if (c == ',' && separatorCount == 0)
                {
                    return index;
                }
                ++index;
            }

            return -1;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingGenericInstanceTypesRaw<T>()
        {
            return typeof(T).GetUsingGenericInstanceTypes();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingGenericInstanceTypesAsyncRaw<T>()
        {
            return typeof(T).GetUsingGenericInstanceTypesAsync();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingGenericInstanceTypes(this Type self)
        {
            if (GetUsingGenericInstanceTypesTypeTable().TryGetValue(self, out var result))
            {
                return result;
            }

            return ArrayCache.Types0;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingGenericInstanceTypesAsyncRaw(this Type self)
        {
            return self.QueryMembersAsync(v => v.GetUsingGenericInstanceTypes());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingArrayTypesRaw<T>()
        {
            return typeof(T).GetUsingArrayTypes();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingArrayTypesAsyncRaw<T>()
        {
            return typeof(T).GetUsingGenericInstanceTypesAsync();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingArrayTypes(this Type self)
        {
            if (GetUsingArrayTypesTypeTable().TryGetValue(self, out var result))
            {
                return result;
            }

            return ArrayCache.Types0;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingArrayTypesAsyncRaw(this Type self)
        {
            return self.QueryMembersAsync(v => v.GetUsingArrayTypes());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingPointerTypesRaw<T>()
        {
            return typeof(T).GetUsingPointerTypes();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingPointerTypesAsyncRaw<T>()
        {
            return typeof(T).GetUsingPointerTypesAsync();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingPointerTypes(this Type self)
        {
            if (GetUsingPointerTypesTypeTable().TryGetValue(self, out var result))
            {
                return result;
            }

            return ArrayCache.Types0;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingPointerTypesAsyncRaw(this Type self)
        {
            return self.QueryMembersAsync(v => v.GetUsingPointerTypes());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingByRefTypesRaw<T>()
        {
            return typeof(T).GetUsingByRefTypes();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingByRefTypesAsyncRaw<T>()
        {
            return typeof(T).GetUsingByRefTypesAsync();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyArray<Type> GetUsingByRefTypes(this Type self)
        {
            if (GetUsingByRefTypesTypeTable().TryGetValue(self, out var result))
            {
                return result;
            }

            return ArrayCache.Types0;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetUsingByRefTypesAsyncRaw(this Type self)
        {
            return self.QueryMembersAsync(v => v.GetUsingByRefTypes());
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<Type, ReadOnlyArray<Type>> GetUsingGenericInstanceTypesTypeTableRaw()
        {
            var result = REReflection.GetUsingGenericInstanceTypes().AsSafeParallel().GroupBy(v => v.GetGenericTypeDefinition()).ToDictionary(v => v.Key, v => (ReadOnlyArray<Type>)v.ToArray());
            return result;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<Type, ReadOnlyArray<Type>> GetUsingArrayTypesTypeTableRaw()
        {
            var result = REReflection.GetUsingArrayTypes().AsSafeParallel().GroupBy(v => v.GetGenericTypeDefinition()).ToDictionary(v => v.Key, v => (ReadOnlyArray<Type>)v.ToArray());
            return result;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<Type, ReadOnlyArray<Type>> GetUsingPointerTypesTypeTableRaw()
        {
            var result = REReflection.GetUsingPointerTypes().AsSafeParallel().GroupBy(v => v.GetGenericTypeDefinition()).ToDictionary(v => v.Key, v => (ReadOnlyArray<Type>)v.ToArray());
            return result;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Dictionary<Type, ReadOnlyArray<Type>> GetUsingByRefTypesTypeTableRaw()
        {
            var result = REReflection.GetUsingByRefTypes().AsSafeParallel().GroupBy(v => v.GetGenericTypeDefinition()).ToDictionary(v => v.Key, v => (ReadOnlyArray<Type>)v.ToArray());
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldWithMovedFullAccessRaw<T>(string name)
        {
            return typeof(T).GetFieldWithMovedFullAccess(name);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static FieldInfo GetFieldWithMovedFullAccessRaw(this Type self, string name)
        {
            var field = self.GetFieldFullAccess(name);
            if (field != null)
            {
                return field;
            }

            field = self.GetFieldsFullAccess()
                            .Select(v => (v, v.GetCustomAttribute<FormerlySerializedAsAttribute>()))
                            .Where(v => v.Item2 != null)
                            .FirstOrDefault(v => v.Item2.oldName == name).v;
            return field;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<FieldInfo> GetSerializeFieldsRaw<T>()
        {
            return typeof(T).GetSerializeFields();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<FieldInfo> GetSerializeFieldsRaw(this Type self)
        {
            if (!self.HasAttribute<SerializableAttribute>() && !self.IsUnityObject())
            {
                return Array.Empty<FieldInfo>();
            }

            var fields = self.GetFieldsFullAccess();
            return fields.Where(v => v.IsSerializeField()).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetBaseTypesRaw<T>()
        {
            return typeof(T).GetBaseTypes();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetBaseTypesRaw(this Type type)
        {
            if (type.BaseType == null)
            {
                return ArrayCache.Types0;
            }

            var baseTypes = type.BaseType.GetBaseTypes();
            var resultList = new List<Type>(baseTypes.Count + 1) { type.BaseType };
            resultList.AddRange(baseTypes);
            return resultList.ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetBaseTypesAndSelfRaw<T>()
        {
            return typeof(T).GetBaseTypesAndSelf();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetBaseTypesAndSelfRaw(this Type type)
        {
            var baseTypes = type.GetBaseTypes();
            var resultList = new List<Type>(baseTypes.Count + 1) { type };
            resultList.AddRange(baseTypes);
            return resultList.ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetSubTypesRaw<T>()
        {
            return typeof(T).GetSubTypes();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetSubTypesAsyncRaw<T>()
        {
            return typeof(T).GetSubTypesAsync();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetSubTypesRaw(this Type type)
        {
            var assembly = type.Assembly;
            var result = REReflection.GetAssembliesFast()
                            .AsSafeParallel()
                            .Where(v => v == assembly || v.IsReferenceTo(assembly))
                            .SelectMany(REAssembly.GetTypesFast)
                            .Where(v => v.IsSubclassOf(type))
                            .ToArray();
            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static AsyncHandle<ReadOnlyArray<Type>> GetSubTypesAsyncRaw(this Type self)
        {
            return self.QueryMembersAsync(v => v.GetSubTypes());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncHandle<ReadOnlyArray<T>> QueryMembersAsync<T>(this Type self, Func<Type, ReadOnlyArray<T>> getMembers)
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
        private static ReadOnlyArray<T> GetEnumValuesFastRaw<T>()
            where T : Enum
        {
            return REEnum.GetValuesFast<T>();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericParameterDeclaringFromRaw<T>(MemberInfo owner)
        {
            if (owner is MethodBase method)
            {
                return IsGenericParameterDeclaringFrom<T>(method);
            }
            else if (owner is Type type)
            {
                return IsGenericParameterDeclaringFrom<T>(type);
            }

            return false;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericParameterDeclaringFromRaw(this Type self, MemberInfo owner)
        {
            if (owner is MethodBase method)
            {
                return self.IsGenericParameterDeclaringFrom(method);
            }
            else if (owner is Type type)
            {
                return self.IsGenericParameterDeclaringFrom(type);
            }

            return false;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericParameterDeclaringFromRaw<T>(Type owner)
        {
            if (!IsGenericParameterFast<T>())
            {
                return false;
            }

            var args = owner.GetGenericArgumentsFast();
            if (typeof(T).GenericParameterPosition >= args.Count)
            {
                return false;
            }

            return args[typeof(T).GenericParameterPosition] == typeof(T);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericParameterDeclaringFromRaw(this Type self, Type owner)
        {
            if (!self.IsGenericParameter)
            {
                return false;
            }

            var args = owner.GetGenericArgumentsFast();
            if (self.GenericParameterPosition >= args.Count)
            {
                return false;
            }

            return args[self.GenericParameterPosition] == self;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericParameterDeclaringFromRaw<T>(MethodBase owner)
        {
            if (!IsGenericParameterFast<T>())
            {
                return false;
            }

            var args = GetGenericArgumentsFast<T>();
            if (typeof(T).GenericParameterPosition >= args.Count)
            {
                return false;
            }

            return args[typeof(T).GenericParameterPosition] == typeof(T);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericParameterDeclaringFromRaw(this Type self, MethodBase owner)
        {
            if (!self.IsGenericParameter)
            {
                return false;
            }

            var args = owner.GetGenericArgumentsFast();
            if (self.GenericParameterPosition >= args.Count)
            {
                return false;
            }

            return args[self.GenericParameterPosition] == self;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericTypeParameterFastRaw<T>()
        {
            return typeof(T).IsGenericTypeParameterFast();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericTypeParameterFastRaw(this Type self)
        {
#if ENABLE_IL2CPP
            if (!self.IsGenericParameter)
            {
                return false;
            }

            var declaringType = self.DeclaringType;
            if (declaringType == null &&
                !declaringType.IsGenericType)
            {
                return false;
            }

            var args = self.DeclaringType.GetGenericArgumentsFast();
            if (self.GenericParameterPosition >= args.Count)
            {
                return false;
            }

            return args[self.GenericParameterPosition] == self;
#else
            return self.IsGenericTypeParameter;
#endif
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericMethodParameterFastRaw<T>()
        {
            return IsGenericParameterFast<T>() && !IsGenericTypeParameterFast<T>();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericMethodParameterFastRaw(this Type self)
        {
#if ENABLE_IL2CPP
            if (!self.IsGenericParameter)
            {
                return false;
            }

            var declaringType = self.DeclaringType;
            if (declaringType == null)
            {
                return false;
            }

            if (!declaringType.IsGenericType)
            {
                return true;
            }

            var args = self.DeclaringType.GetGenericArgumentsFast();
            if (self.GenericParameterPosition >= args.Count)
            {
                return true;
            }

            return args[self.GenericParameterPosition] != self;
#else
            return self.IsGenericMethodParameter;
#endif
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsTypeRaw<T>(Type type)
        {
            if (typeof(T) == type)
            {
                return true;
            }

            if (IsGenericTypeFast<T>())
            {
                if (!IsGenericTypeDefinitionFast<T>())
                {
                    foreach (var arg in GetGenericTypeArgumentsFast<T>())
                    {
                        if (arg.ContainsType(type))
                        {
                            return true;
                        }
                    }
                }

                if (GetGenericTypeDefinitionFast<T>().ContainsType(type))
                {
                    return true;
                }
            }

            if (HasElementTypeFast<T>())
            {
                return GetElementTypeFast<T>().ContainsType(type);
            }

            return false;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ContainsTypeRaw(this Type self, Type type)
        {
            if (self == type)
            {
                return true;
            }

            if (self.IsGenericType)
            {
                if (!self.IsGenericTypeDefinition)
                {
                    foreach (var arg in self.GenericTypeArguments)
                    {
                        if (arg.ContainsType(type))
                        {
                            return true;
                        }
                    }
                }

                if (self.GetGenericTypeDefinition().ContainsType(type))
                {
                    return true;
                }
            }

            if (self.HasElementType)
            {
                return self.GetElementType().ContainsType(type);
            }

            return false;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasAttributeRaw<T, TAttribute>()
            where TAttribute : Attribute
        {
            return typeof(T).GetCustomAttributes<TAttribute>(false).Any();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsStaticMemberRaw<T>()
        {
            return IsSealedFast<T>() && IsAbstractFast<T>();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsStaticMember(this Type self)
        {
            return self.IsSealed && self.IsAbstract;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsAddressTypeRaw<T>()
        {
            return typeof(T).IsAddressType();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAddressType(this Type self)
        {
            return self.IsPointer || self.IsByRef;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGenericDefinitionOf<T>(Type genericTypeDefinition)
        {
            return IsGenericTypeFast<T>() && GetGenericTypeDefinitionFast<T>() == genericTypeDefinition;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGenericDefinitionOf(this Type self, Type genericTypeDefinition)
        {
            return self.IsGenericType && self.GetGenericTypeDefinition() == genericTypeDefinition;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsByRefLikeRaw<T>()
        {
            return IsGenericDefinitionOf<T>(typeof(ByRefLike<>));
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsByRefLike(this Type self)
        {
            return self.IsGenericDefinitionOf(typeof(ByRefLike<>));
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsPointerLikeRaw<T>()
        {
            return IsGenericDefinitionOf<T>(typeof(PointerLike<>));
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPointerLike(this Type self)
        {
            return self.IsGenericDefinitionOf(typeof(PointerLike<>));
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsListRaw<T>()
        {
            return IsGenericDefinitionOf<T>(typeof(List<>));
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsList(this Type self)
        {
            return self.IsGenericDefinitionOf(typeof(List<>));
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEnumerableRaw<T>()
        {
            return IsAssignableFromFast<IEnumerable, T>();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEnumerable(this Type self)
        {
            return self.IsAssignableTo(typeof(IEnumerable));
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsArrayOfUnitySerializeRaw<T>()
        {
            return IsArrayFast<T>() || IsList<T>();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsArrayOfUnitySerialize(this Type self)
        {
            return self.IsArray || self.IsList();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsUnityObjectRaw<T>()
        {
            return IsAssignableFromFast<UnityEngine.Object, T>();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUnityObject(this Type self)
        {
            return self.IsAssignableTo<UnityEngine.Object>();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsJsonErrorTypeRaw<T>()
        {
            var elem = GetElementTypeOfUnitySerialize<T>();
            return elem.IsValueType && elem.IsAssignableTo<ISerializationCallbackReceiver>();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsJsonErrorTypeRaw(this Type self)
        {
            var elem = self.GetElementTypeOfUnitySerialize();
            return elem.IsValueType && elem.IsAssignableTo<ISerializationCallbackReceiver>();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsCreatableInstanceRaw<T>()
        {
            return !IsInterfaceFast<T>() && !IsAbstractFast<T>() && !ContainsGenericParametersFast<T>();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsCreatableInstance(this Type self)
        {
            return !self.IsInterface && !self.IsAbstract && !self.ContainsGenericParameters;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSerializablePrimitiveTypeAsFieldRaw<T>()
        {
            var self = GetElementTypeOfUnitySerialize<T>();
            if (self.IsGenericType)
            {
                self = self.GetGenericTypeDefinition();
            }

            foreach (var type in SerializableFieldPrimitiveTypes)
            {
                if (type.IsAssignableFrom(self))
                {
                    return true;
                }
            }

            return false;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSerializablePrimitiveTypeAsFieldRaw(this Type self)
        {
            self = self.GetElementTypeOfUnitySerialize();
            if (self.IsGenericType)
            {
                self = self.GetGenericTypeDefinition();
            }

            foreach (var type in SerializableFieldPrimitiveTypes)
            {
                if (type.IsAssignableFrom(self))
                {
                    return true;
                }
            }

            return false;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSerializableDefinedTypeAsFieldRaw<T>()
        {
            var elemType = GetElementTypeOfUnitySerialize<T>();
            return elemType.IsSerializableTypeAsRoot();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSerializableDefinedTypeAsField(this Type self)
        {
            var elemType = self.GetElementTypeOfUnitySerialize();
            return elemType.IsSerializableTypeAsRoot();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSerializableTypeAsFieldRaw<T>()
        {
            return IsSerializablePrimitiveTypeAsField<T>() || IsSerializableDefinedTypeAsField<T>();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSerializableTypeAsField(this Type self)
        {
            return self.IsSerializablePrimitiveTypeAsField() || self.IsSerializableDefinedTypeAsField();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsSerializableTypeAsRootRaw<T>()
        {
            return SerializableTypesWithHasNotSerializableAttribute.Contains(typeof(T)) ||
                   (!IsArrayOfUnitySerialize<T>() && HasAttribute<T, SerializableAttribute>() && !IsSerializablePrimitiveTypeAsField<T>() && IsCreatableInstance<T>());
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSerializableTypeAsRoot(this Type self)
        {
            return SerializableTypesWithHasNotSerializableAttribute.Contains(self) ||
                   (!self.IsArrayOfUnitySerialize() && self.HasAttribute<SerializableAttribute>() && !self.IsSerializablePrimitiveTypeAsField() && self.IsCreatableInstance());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasSerializeFieldRaw<T>()
        {
            return GetFieldsWithBaseFullAccess<T>().Any(v => v.IsSerializeField());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasSerializeFieldRaw(this Type self)
        {
            return self.GetFieldsWithBaseFullAccess().Any(v => v.IsSerializeField());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasDefaultConstructorRaw<T>()
        {
            return GetInstanceConstructorsFullAccess<T>().Any(v => !v.HasParameter());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasDefaultConstructorRaw(this Type self)
        {
            return self.GetInstanceConstructorsFullAccess().Any(v => !v.HasParameter());
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetElementTypeOfEnumerableRaw<T>()
        {
            if (IsArrayFast<T>())
            {
                return GetElementTypeFast<T>();
            }

            var interfaces = GetInterfacesFast<T>();
            foreach (var inter in interfaces)
            {
                if (inter.IsGenericDefinitionOf(typeof(IEnumerable<>)))
                {
                    return inter.GetFirstGenericArgument();
                }
            }

            foreach (var inter in interfaces)
            {
                if (inter == typeof(IEnumerable))
                {
                    return typeof(object);
                }
            }

            return null;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementTypeOfEnumerable(this Type self)
        {
            if (self.IsArray)
            {
                return self.GetElementType();
            }

            if (self.IsGenericDefinitionOf(typeof(IEnumerable<>)))
            {
                return self.GetFirstGenericArgument();
            }

            var interfaces = self.GetInterfacesFast();
            foreach (var inter in interfaces)
            {
                if (inter.IsGenericDefinitionOf(typeof(IEnumerable<>)))
                {
                    return inter.GetFirstGenericArgument();
                }
            }

            if (self.IsGenericDefinitionOf(typeof(IEnumerable)))
            {
                return self.GetFirstGenericArgument();
            }

            foreach (var inter in interfaces)
            {
                if (inter == typeof(IEnumerable))
                {
                    return typeof(object);
                }
            }

            return self;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetElementTypeOfUnitySerializeRaw<T>()
        {
            if (IsArrayFast<T>())
            {
                return GetElementTypeFast<T>();
            }

            if (IsList<T>())
            {
                return GetFirstGenericArgument<T>();
            }

            return typeof(T);
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementTypeOfUnitySerialize(this Type self)
        {
            if (self.IsArray)
            {
                return self.GetElementType();
            }

            if (self.IsList())
            {
                return self.GetFirstGenericArgument();
            }

            return self;
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubclassOf<T>(this Type self)
        {
            return self.IsSubclassOf(typeof(T));
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBaseTypeOf<T>(this Type self)
        {
            return typeof(T).IsSubclassOf(self);
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBaseTypeOf(this Type self, Type t)
        {
            return t.IsSubclassOf(self);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNullAssignableFromFastRaw<T>(Type c)
        {
            return typeof(T).IsNullAssignableFromFast(c);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNullAssignableFromFastRaw(this Type self, Type c)
        {
            if (c == null)
            {
                return !self.IsValueType;
            }

            return self.IsAssignableFrom(c);
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAssignableFromFast(this Type self, Type type)
        {
#if ENABLE_IL2CPP
            if (self.IsPointer || self.IsByRef || self.IsGenericParameter)
            {
                return self == type;
            }

            if (type.IsPointer || type.IsByRef || type.IsGenericParameter)
            {
                return false;
            }
#endif
            return self.IsAssignableFrom(type);
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAssignableFromFast<T>(this Type self)
        {
            return self.IsAssignableFromFast(typeof(T));
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsAssignableFromFastRaw<TFrom, TTo>()
        {
            return typeof(TFrom).IsAssignableFrom(typeof(TTo));
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAssignableTo(this Type self, Type c)
        {
            return c.IsAssignableFromFast(self);
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAssignableTo<T>(this Type self)
        {
            return typeof(T).IsAssignableFromFast(self);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsAssignableToRaw<TTo, TFrom>()
        {
            return typeof(TFrom).IsAssignableFrom(typeof(TTo));
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEqualsFastRaw<T1, T2>()
        {
            return typeof(T1) == typeof(T2);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEqualByRefElementRaw<T>(this Type type)
        {
            if (!IsByRefLike<T>() && !type.IsByRef)
            {
                return false;
            }

            return GetFirstGenericArgument<T>() == type.GetElementType();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEqualPointerElementRaw<T>(this Type type)
        {
            if (!IsPointerLike<T>() && !type.IsPointer)
            {
                return false;
            }

            return GetFirstGenericArgument<T>() == type.GetElementType();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEqualAddressElementRaw<T>(this Type type)
        {
            if (!IsByRefLike<T>() && !IsPointerLike<T>() && !type.IsAddressType())
            {
                return false;
            }

            return GetFirstGenericArgument<T>() == type.GetElementType();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsGenericInstanceTypeRaw<T>()
        {
            return !IsGenericTypeDefinitionFast<T>() && IsGenericTypeFast<T>();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsGenericInstanceType(this Type type)
        {
            return !type.IsGenericTypeDefinition && type.IsGenericType;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetMyGenericArgmentsRaw<T>()
        {
            var parent = typeof(T).ReflectedType;
            var count = parent?.GetGenericArgumentsFast()?.Count ?? 0;
            var args = GetGenericArgumentsFast<T>();
            return args.Take(count).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetMyGenericArgmentsRaw(this Type self)
        {
            var parent = self.ReflectedType;
            var count = parent?.GetGenericArgumentsFast()?.Count ?? 0;
            var args = self.GetGenericArgumentsFast();
            return args.Take(count).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetParentGenericArgmentsRaw<T>()
        {
            var parent = typeof(T).ReflectedType;
            var count = parent?.GetGenericArgumentsFast()?.Count ?? 0;
            var args = GetGenericArgumentsFast<T>();
            return args.Skip(count).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlyArray<Type> GetParentGenericArgmentsRaw(this Type self)
        {
            var parent = self.ReflectedType;
            var count = parent?.GetGenericArgumentsFast()?.Count ?? 0;
            var args = self.GetGenericArgumentsFast();
            return args.Skip(count).ToArray();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetGenericArgumentRaw<T>(string genArgName)
        {
            if (!IsGenericTypeDefinitionFast<T>())
            {
                return null;
            }

            var args = GetGenericArgumentsFast<T>();
            return args.FirstOrDefault(v => v.Name == genArgName);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetGenericArgumentRaw(this Type type, string genArgName)
        {
            if (!type.IsGenericTypeDefinition)
            {
                return null;
            }

            var args = type.GetGenericArgumentsFast();
            return args.FirstOrDefault(v => v.Name == genArgName);
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetFirstGenericArgumentRaw<T>()
        {
            return GetGenericArgumentsFast<T>().FirstOrDefault();
        }

        [StaticExpression(CalculationFailedWarning = false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type GetFirstGenericArgument(this Type self)
        {
            return self.GetGenericArgumentsFast().FirstOrDefault();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static object GetDefaultRaw(this Type self)
        {
            if (!self.IsValueType)
            {
                return null;
            }

            return self.CreateInstance();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T GetDefaultRaw<T>()
        {
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateInstance<T>()
        {
            if (IsValueTypeFast<T>())
            {
                return default;
            }

            var ctor = GetInstanceConstructorFullAccess<T>();
            if (ctor == null)
            {
                try
                {
                    return Activator.CreateInstance<T>();
                }
                catch
                {
                    return (T)Activator.CreateInstance(typeof(T), true);
                }
            }

            return ctor.InvokeInstanceFast<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateInstance(this Type self)
        {
            var ctor = self.GetInstanceConstructorFullAccess();
            if (ctor == null)
            {
                return Activator.CreateInstance(self, true);
            }

            return ctor.InvokeInstanceFast<object>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateDummyInstance<T>()
        {
            if (IsValueTypeFast<T>())
            {
                return default;
            }

            try
            {
                if (IsSZArrayFast<T>())
                {
                    return (T)(object)Array.CreateInstance(GetElementTypeFast<T>(), 0);
                }

                if (IsArrayFast<T>())
                {
                    var size = GetArrayRankFast<T>();
                    var length = ArrayCache.GetDefaultArrayCache<int>(size);
                    return (T)(object)Array.CreateInstance(GetElementTypeFast<T>(), length);
                }

                return CreateInstance<T>();
            }
            catch
            {
            }

            if (IsJsonErrorType<T>() || !HasAttribute<T, SerializableAttribute>())
            {
                return default;
            }

            return JsonUtility.FromJson<T>("{}");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static object CreateDummyInstance(this Type self)
        {
            if (self == null)
            {
                return null;
            }

            try
            {
                if (self.IsSZArray)
                {
                    return Array.CreateInstance(self.GetElementType(), 0);
                }

                if (self.IsArray)
                {
                    var size = self.GetArrayRank();
                    var length = ArrayCache.GetDefaultArrayCache<int>(size);
                    return Array.CreateInstance(self.GetElementType(), length);
                }

                return self.CreateInstance();
            }
            catch
            {
            }

            if (self.IsJsonErrorType() || !self.HasAttribute<SerializableAttribute>())
            {
                return null;
            }

            return JsonUtility.FromJson("{}", self);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void Clear<T>(T obj)
            where T : class
        {
            if (obj == null)
            {
                return;
            }

            var headerSize = CalcClassHeaderSize();
            var top = (byte*)(UnsafeUtility.As<T, IntPtr>(ref obj) + headerSize);
            var clearInfo = GetClearInfo<T>();
            for (int i = 0; i < clearInfo.Count64; ++i)
            {
                ((long*)top)[i] = 0;
            }

            top += clearInfo.Count64 * sizeof(long);
            if (clearInfo.Copy32)
            {
                (*(int*)top) = 0;
                top += sizeof(int);
            }
            if (clearInfo.Copy16)
            {
                (*(short*)top) = 0;
                top += sizeof(short);
            }
            if (clearInfo.Copy8)
            {
                *top = 0;
            }
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ClearInfo GetClearInfoRaw<T>()
        {
            var classBodySize = CalcClassBodySize<T>();
            var result = new ClearInfo();

            result.Count64 = classBodySize / sizeof(long);

            var remain = classBodySize - (result.Count64 * sizeof(long));
            if (remain >= sizeof(int))
            {
                result.Copy32 = true;
                remain -= sizeof(int);
            }

            if (remain >= sizeof(short))
            {
                result.Copy16 = true;
                remain -= sizeof(short);
            }

            if (remain >= sizeof(byte))
            {
                result.Copy8 = true;
            }

            return result;
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe int CalcClassHeaderSizeRaw()
        {
            var field = GetFieldFast<CalcHeaderDummy>(nameof(CalcHeaderDummy.DummyMember));
            return (int)field.GetFieldPointerOffset();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic, Attributes = new string[] { "Katuusagi.ConstExpressionForUnity.StaticExpression(CalculationFailedWarning = false)" })]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CalcClassBodySizeRaw<T>()
        {
            var max = typeof(T).GetInstanceFieldsWithBaseFullAccess()
                            .AsSafeParallel()
                            .Select<FieldInfo, (FieldInfo field, int offset)>(v => (v, (int)v.GetFieldPointerOffset()))
                            .OrderBy(v => -v.offset)
                            .FirstOrDefault();
            var maxFieldOffset = max.offset;
            var maxFieldSize = max.field.FieldType.IsValueType ? Marshal.SizeOf(max.field.FieldType) : IntPtr.Size;

            return maxFieldOffset + maxFieldSize - CalcClassHeaderSize();
        }

        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type MakeGenericTypeFastRaw(this Type self, params Type[] types)
        {
            return self.MakeGenericType(types);
        }
    }
}
