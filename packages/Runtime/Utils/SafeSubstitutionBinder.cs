using Katuusagi.MemoizationForUnity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Pool;

namespace Katuusagi.ReflectionEnhance.Utils
{
    internal partial class SafeSubstitutionBinder : Binder
    {
        public static readonly SafeSubstitutionBinder Default = new SafeSubstitutionBinder();
        public Type[] ParameterTypes { get; set; }

        public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, object value, CultureInfo culture)
        {
            return Type.DefaultBinder.BindToField(bindingAttr, match, value, culture);
        }

        public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, ref object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] names, out object state)
        {
            return Type.DefaultBinder.BindToMethod(bindingAttr, match, ref args, modifiers, culture, names, out state);
        }

        public override object ChangeType(object value, Type type, CultureInfo culture)
        {
            return Type.DefaultBinder.ChangeType(value, type, culture);
        }

        public override void ReorderArgumentArray(ref object[] args, object state)
        {
            Type.DefaultBinder.ReorderArgumentArray(ref args, state);
        }

        public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, Type[] types, ParameterModifier[] modifiers)
        {
            if (match == null || match.Length == 0)
            {
                throw new ArgumentException("Array may not be empty.", "match");
            }

            types = GetArrayCache(types);
            ReplaceSubstitution(types);
            using (ListPool<MethodBase>.Get(out var methods))
            {
                Query(match, types, (l, r) => l == r, methods);
                if (methods.Count >= 1)
                {
                    return methods[0];
                }

                methods.Clear();
                Query(match, types, (l, r) => l.IsAssignableFromFast(r), methods);
                if (methods.Count >= 1)
                {
                    return methods[0];
                }
            }

            return null;
        }

        public override PropertyInfo SelectProperty(BindingFlags bindingAttr, PropertyInfo[] match, Type returnType, Type[] indexes, ParameterModifier[] modifiers)
        {
            if (indexes != null && !Contract.ForAll(indexes, (Type t) => t != null))
            {
                throw new ArgumentNullException("indexes");
            }

            if (match == null || match.Length == 0)
            {
                throw new ArgumentException("Array may not be empty.", "match");
            }

            indexes = GetArrayCache(indexes);
            ReplaceSubstitution(ref returnType);
            ReplaceSubstitution(indexes);
            using (ListPool<PropertyInfo>.Get(out var properties))
            {
                Query(match, indexes, returnType, (l, r) => l == r, properties);
                if (properties.Count >= 2)
                {
                    return properties[0];
                }
                if (properties.Count >= 1)
                {
                    return properties[0];
                }

                properties.Clear();
                Query(match, indexes, returnType, (l, r) => l.IsAssignableFromFast(r), properties);
                if (properties.Count >= 2)
                {
                    return properties[0];
                }
                if (properties.Count >= 1)
                {
                    return properties[0];
                }
            }

            return null;
        }

        private static void Query(IEnumerable<MethodBase> match, Type[] types, Func<Type, Type, bool> isEqualType, List<MethodBase> result)
        {
            int baseCount = 0;
            foreach (var method in match)
            {
                var parameterTypes = method.GetParameterTypes();
                if (parameterTypes.Count != types.Length)
                {
                    break;
                }

                bool isMatched = true;
                for (int i = 0; i < types.Length; ++i)
                {
                    var parameterType = parameterTypes[i];
                    var type = types[i];
                    if (!isEqualType(parameterType, type) &&
                        (!ReplaceGenericParameterLike(ref type, method) || !isEqualType(parameterType, type)))
                    {
                        isMatched = false;
                        break;
                    }
                }

                if (isMatched)
                {
                    var t = method.DeclaringType;
                    var baseTypesAndSelf = t.GetBaseTypesAndSelf();
                    var count = baseTypesAndSelf.Count;
                    if (count > baseCount)
                    {
                        result.Clear();
                        baseCount = count;
                    }
                    
                    if (count == baseCount)
                    {
                        result.Add(method);
                    }
                }
            }
        }

        private static void Query(IEnumerable<PropertyInfo> match, Type[] indexes, Type returnType, Func<Type, Type, bool> isEqualType, List<PropertyInfo> result)
        {
            int baseCount = 0;
            foreach (var property in match)
            {
                var propertyType = property.PropertyType;
                if (!isEqualType(propertyType, returnType) &&
                    (!ReplaceGenericParameterLike(ref returnType, property) || !isEqualType(propertyType, returnType)))
                {
                    continue;
                }

                var parameterTypes = property.GetParameterTypes();
                if (parameterTypes.Count != indexes.Length)
                {
                    break;
                }

                bool isMatched = true;
                for (int i = 0; i < indexes.Length; ++i)
                {
                    var parameterType = parameterTypes[i];
                    var index = indexes[i];
                    if (!isEqualType(parameterType, index) &&
                        (!ReplaceGenericParameterLike(ref index, property) || !isEqualType(parameterType, index)))
                    {
                        isMatched = false;
                        break;
                    }
                }

                if (isMatched)
                {
                    var t = property.DeclaringType;
                    var baseTypesAndSelf = t.GetBaseTypesAndSelf();
                    var count = baseTypesAndSelf.Count;
                    if (count > baseCount)
                    {
                        result.Clear();
                        baseCount = count;
                    }

                    if (count == baseCount)
                    {
                        result.Add(property);
                    }
                }
            }
        }

        public static bool ReplaceSubstitution(Type[] types)
        {
            bool result = false;
            for (int i = 0; i < types.Length; ++i)
            {
                if (ReplaceSubstitution(ref types[i]))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool ReplaceSubstitution(ref Type t)
        {
            if (t == typeof(ISubstitution))
            {
                return false;
            }

            bool replaced = false;
            if (t.IsAssignableTo<ISubstitution>())
            {
                if (t == typeof(VoidLike))
                {
                    t = typeof(void);
                    return true;
                }
                
                if (t.IsGenericInstanceType())
                {
                    var definition = t.GetGenericTypeDefinition();
                    if (definition == typeof(ByRefLike<>))
                    {
                        var element = t.GetGenericArguments()[0];
                        t = element.MakeByRefType();
                        replaced = true;
                    }
                    else if (definition == typeof(PointerLike<>))
                    {
                        var element = t.GetGenericArguments()[0];
                        t = element.MakePointerType();
                        replaced = true;
                    }
                }
            }

            if (t.IsGenericInstanceType())
            {
                var check = false;
                var genArgs = t.GetGenericArgumentsFast().ToArray();
                for (int i = 0; i < genArgs.Length; ++i)
                {
                    if (ReplaceSubstitution(ref genArgs[i]))
                    {
                        check = true;
                    }
                }

                if (check)
                {
                    t = t.GetGenericTypeDefinition().MakeGenericTypeFast(genArgs);
                    return true;
                }

                return replaced;
            }

            if (t.HasElementType)
            {
                var element = t.GetElementType();
                if (ReplaceSubstitution(ref element))
                {
                    if (t.IsSZArray)
                    {
                        t = element.MakeArrayType();
                    }
                    else if (t.IsArray)
                    {
                        t = element.MakeArrayType(t.GetArrayRank());
                    }
                    else if (t.IsByRef)
                    {
                        t = element.MakeByRefType();
                    }
                    else if (t.IsPointer)
                    {
                        t = element.MakePointerType();
                    }
                    return true;
                }
                return replaced;
            }

            return replaced;
        }

        private static bool ReplaceGenericParameterLike(ref Type t, MethodBase method)
        {
            if (t.FullName != null)
            {
                if (t.IsGenericDefinitionOf(typeof(GenericTypeParameterLike<>)))
                {
                    var declaringType = method.DeclaringType;
                    if (!declaringType.IsGenericTypeDefinition)
                    {
                        return false;
                    }

                    var positionField = t.GetFieldFast("Position");
                    var position = positionField.GetStaticValueFast<int>();
                    var genericArguments = declaringType.GetGenericArgumentsFast();
                    if (genericArguments.Count <= position)
                    {
                        return false;
                    }

                    t = genericArguments[position];
                    return true;
                }

                if (t.IsGenericDefinitionOf(typeof(GenericMethodParameterLike<>)))
                {
                    if (!method.IsGenericMethod)
                    {
                        return false;
                    }

                    var positionField = t.GetFieldFast("Position");
                    var position = positionField.GetStaticValueFast<int>();
                    var genericArguments = method.GetGenericArgumentsFast();
                    if (genericArguments.Count <= position)
                    {
                        return false;
                    }

                    t = genericArguments[position];
                    return true;
                }
            }

            if (t.IsGenericInstanceType())
            {
                var check = false;
                var genArgs = t.GetGenericArgumentsFast().ToArray();
                for (int i = 0; i < genArgs.Length; ++i)
                {
                    if (ReplaceGenericParameterLike(ref genArgs[i], method))
                    {
                        check = true;
                    }
                }

                if (check)
                {
                    t = t.GetGenericTypeDefinition().MakeGenericTypeFast(genArgs);
                    return true;
                }

                return false;
            }

            if (t.HasElementType)
            {
                var element = t.GetElementType();
                var check = false;
                if (ReplaceGenericParameterLike(ref element, method))
                {
                    check = true;
                }

                if (check)
                {
                    if (t.IsSZArray)
                    {
                        t = element.MakeArrayType();
                    }
                    else if (t.IsArray)
                    {
                        t = element.MakeArrayType(t.GetArrayRank());
                    }
                    else if (t.IsByRef)
                    {
                        t = element.MakeByRefType();
                    }
                    else if (t.IsPointer)
                    {
                        t = element.MakePointerType();
                    }
                    return true;
                }
                return false;
            }

            return false;
        }

        private static bool ReplaceGenericParameterLike(ref Type t, PropertyInfo property)
        {
            if (t.FullName != null)
            {
                if (t.IsGenericDefinitionOf(typeof(GenericTypeParameterLike<>)))
                {
                    var declaringType = property.DeclaringType;
                    if (!declaringType.IsGenericTypeDefinition)
                    {
                        return false;
                    }

                    var positionField = t.GetFieldFast("Position");
                    var position = positionField.GetStaticValueFast<int>();
                    var genericArguments = declaringType.GetGenericArgumentsFast();
                    if (genericArguments.Count <= position)
                    {
                        return false;
                    }

                    t = genericArguments[position];
                    return true;
                }

                if (t.IsGenericDefinitionOf(typeof(GenericMethodParameterLike<>)))
                {
                    return false;
                }
            }

            if (t.IsGenericInstanceType())
            {
                var check = false;
                var genArgs = t.GetGenericArgumentsFast().ToArray();
                for (int i = 0; i < genArgs.Length; ++i)
                {
                    if (ReplaceGenericParameterLike(ref genArgs[i], property))
                    {
                        check = true;
                    }
                }

                if (check)
                {
                    t = t.GetGenericTypeDefinition().MakeGenericTypeFast(genArgs);
                    return true;
                }

                return false;
            }

            if (t.HasElementType)
            {
                var element = t.GetElementType();
                var check = false;
                if (ReplaceGenericParameterLike(ref element, property))
                {
                    check = true;
                }

                if (check)
                {
                    if (t.IsSZArray)
                    {
                        t = element.MakeArrayType();
                    }
                    else if (t.IsArray)
                    {
                        t = element.MakeArrayType(t.GetArrayRank());
                    }
                    else if (t.IsByRef)
                    {
                        t = element.MakeByRefType();
                    }
                    else if (t.IsPointer)
                    {
                        t = element.MakePointerType();
                    }
                    return true;
                }
                return false;
            }

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Type[] GetArrayCache(Type[] types)
        {
            var cache = GetArrayCache<Type>(types.Length);
            types.CopyTo(cache, 0);
            return cache;
        }

        [Memoization(ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T[] GetArrayCacheRaw<T>(int size)
        {
            return new T[size];
        }
    }
}
