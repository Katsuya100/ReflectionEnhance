using Katuusagi.MemoizationForUnity;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
namespace Katuusagi.ReflectionEnhance
{
    public static partial class REType
    {
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Reflection.MemberTypes GetMemberTypeFastRaw<T>()
        {
            return typeof(T).MemberType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Reflection.MemberTypes GetMemberTypeFast(this Type self)
        {
            return self.MemberType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.String GetNameFastRaw<T>()
        {
            return typeof(T).Name;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.String GetNameFast(this Type self)
        {
            return self.Name;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type GetDeclaringTypeFastRaw<T>()
        {
            return typeof(T).DeclaringType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type GetDeclaringTypeFast(this Type self)
        {
            return self.DeclaringType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type GetReflectedTypeFastRaw<T>()
        {
            return typeof(T).ReflectedType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type GetReflectedTypeFast(this Type self)
        {
            return self.ReflectedType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Reflection.Module GetModuleFastRaw<T>()
        {
            return typeof(T).Module;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Reflection.Module GetModuleFast(this Type self)
        {
            return self.Module;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.CustomAttributeData> GetCustomAttributesFastRaw<T>()
        {
            return typeof(T).CustomAttributes.ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.CustomAttributeData> GetCustomAttributesFastRaw(this Type self)
        {
            return self.CustomAttributes.ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Int32 GetMetadataTokenFastRaw<T>()
        {
            return typeof(T).MetadataToken;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Int32 GetMetadataTokenFast(this Type self)
        {
            return self.MetadataToken;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsSerializableFastRaw<T>()
        {
            return typeof(T).IsSerializable;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsSerializableFast(this Type self)
        {
            return self.IsSerializable;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean ContainsGenericParametersFastRaw<T>()
        {
            return typeof(T).ContainsGenericParameters;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean ContainsGenericParametersFast(this Type self)
        {
            return self.ContainsGenericParameters;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsVisibleFastRaw<T>()
        {
            return typeof(T).IsVisible;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsVisibleFast(this Type self)
        {
            return self.IsVisible;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.String GetNamespaceFastRaw<T>()
        {
            return typeof(T).Namespace;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.String GetNamespaceFast(this Type self)
        {
            return self.Namespace;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.String GetAssemblyQualifiedNameFastRaw<T>()
        {
            return typeof(T).AssemblyQualifiedName;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.String GetAssemblyQualifiedNameFast(this Type self)
        {
            return self.AssemblyQualifiedName;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.String GetFullNameFastRaw<T>()
        {
            return typeof(T).FullName;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.String GetFullNameFast(this Type self)
        {
            return self.FullName;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Reflection.Assembly GetAssemblyFastRaw<T>()
        {
            return typeof(T).Assembly;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Reflection.Assembly GetAssemblyFast(this Type self)
        {
            return self.Assembly;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsNestedFastRaw<T>()
        {
            return typeof(T).IsNested;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsNestedFast(this Type self)
        {
            return self.IsNested;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type GetUnderlyingSystemTypeFastRaw<T>()
        {
            return typeof(T).UnderlyingSystemType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type GetUnderlyingSystemTypeFast(this Type self)
        {
            return self.UnderlyingSystemType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsTypeDefinitionFastRaw<T>()
        {
            return typeof(T).IsTypeDefinition;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsTypeDefinitionFast(this Type self)
        {
            return self.IsTypeDefinition;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsArrayFastRaw<T>()
        {
            return typeof(T).IsArray;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsArrayFast(this Type self)
        {
            return self.IsArray;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsByRefFastRaw<T>()
        {
            return typeof(T).IsByRef;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsByRefFast(this Type self)
        {
            return self.IsByRef;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsPointerFastRaw<T>()
        {
            return typeof(T).IsPointer;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsPointerFast(this Type self)
        {
            return self.IsPointer;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsConstructedGenericTypeFastRaw<T>()
        {
            return typeof(T).IsConstructedGenericType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsConstructedGenericTypeFast(this Type self)
        {
            return self.IsConstructedGenericType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsGenericParameterFastRaw<T>()
        {
            return typeof(T).IsGenericParameter;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsGenericParameterFast(this Type self)
        {
            return self.IsGenericParameter;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsGenericTypeFastRaw<T>()
        {
            return typeof(T).IsGenericType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsGenericTypeFast(this Type self)
        {
            return self.IsGenericType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsGenericTypeDefinitionFastRaw<T>()
        {
            return typeof(T).IsGenericTypeDefinition;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsGenericTypeDefinitionFast(this Type self)
        {
            return self.IsGenericTypeDefinition;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsSZArrayFastRaw<T>()
        {
            return typeof(T).IsSZArray;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsSZArrayFast(this Type self)
        {
            return self.IsSZArray;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsVariableBoundArrayFastRaw<T>()
        {
            return typeof(T).IsVariableBoundArray;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsVariableBoundArrayFast(this Type self)
        {
            return self.IsVariableBoundArray;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsByRefLikeFastRaw<T>()
        {
            return typeof(T).IsByRefLike;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsByRefLikeFast(this Type self)
        {
            return self.IsByRefLike;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean HasElementTypeFastRaw<T>()
        {
            return typeof(T).HasElementType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean HasElementTypeFast(this Type self)
        {
            return self.HasElementType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetGenericTypeArgumentsFastRaw<T>()
        {
            return typeof(T).GenericTypeArguments;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetGenericTypeArgumentsFastRaw(this Type self)
        {
            return self.GenericTypeArguments;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Reflection.TypeAttributes GetAttributesFastRaw<T>()
        {
            return typeof(T).Attributes;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Reflection.TypeAttributes GetAttributesFast(this Type self)
        {
            return self.Attributes;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsAbstractFastRaw<T>()
        {
            return typeof(T).IsAbstract;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsAbstractFast(this Type self)
        {
            return self.IsAbstract;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsImportFastRaw<T>()
        {
            return typeof(T).IsImport;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsImportFast(this Type self)
        {
            return self.IsImport;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsSealedFastRaw<T>()
        {
            return typeof(T).IsSealed;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsSealedFast(this Type self)
        {
            return self.IsSealed;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsSpecialNameFastRaw<T>()
        {
            return typeof(T).IsSpecialName;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsSpecialNameFast(this Type self)
        {
            return self.IsSpecialName;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsClassFastRaw<T>()
        {
            return typeof(T).IsClass;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsClassFast(this Type self)
        {
            return self.IsClass;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsNestedAssemblyFastRaw<T>()
        {
            return typeof(T).IsNestedAssembly;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsNestedAssemblyFast(this Type self)
        {
            return self.IsNestedAssembly;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsNestedFamANDAssemFastRaw<T>()
        {
            return typeof(T).IsNestedFamANDAssem;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsNestedFamANDAssemFast(this Type self)
        {
            return self.IsNestedFamANDAssem;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsNestedFamilyFastRaw<T>()
        {
            return typeof(T).IsNestedFamily;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsNestedFamilyFast(this Type self)
        {
            return self.IsNestedFamily;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsNestedFamORAssemFastRaw<T>()
        {
            return typeof(T).IsNestedFamORAssem;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsNestedFamORAssemFast(this Type self)
        {
            return self.IsNestedFamORAssem;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsNestedPrivateFastRaw<T>()
        {
            return typeof(T).IsNestedPrivate;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsNestedPrivateFast(this Type self)
        {
            return self.IsNestedPrivate;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsNestedPublicFastRaw<T>()
        {
            return typeof(T).IsNestedPublic;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsNestedPublicFast(this Type self)
        {
            return self.IsNestedPublic;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsNotPublicFastRaw<T>()
        {
            return typeof(T).IsNotPublic;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsNotPublicFast(this Type self)
        {
            return self.IsNotPublic;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsPublicFastRaw<T>()
        {
            return typeof(T).IsPublic;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsPublicFast(this Type self)
        {
            return self.IsPublic;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsAutoLayoutFastRaw<T>()
        {
            return typeof(T).IsAutoLayout;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsAutoLayoutFast(this Type self)
        {
            return self.IsAutoLayout;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsExplicitLayoutFastRaw<T>()
        {
            return typeof(T).IsExplicitLayout;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsExplicitLayoutFast(this Type self)
        {
            return self.IsExplicitLayout;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsLayoutSequentialFastRaw<T>()
        {
            return typeof(T).IsLayoutSequential;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsLayoutSequentialFast(this Type self)
        {
            return self.IsLayoutSequential;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsAnsiClassFastRaw<T>()
        {
            return typeof(T).IsAnsiClass;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsAnsiClassFast(this Type self)
        {
            return self.IsAnsiClass;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsAutoClassFastRaw<T>()
        {
            return typeof(T).IsAutoClass;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsAutoClassFast(this Type self)
        {
            return self.IsAutoClass;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsUnicodeClassFastRaw<T>()
        {
            return typeof(T).IsUnicodeClass;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsUnicodeClassFast(this Type self)
        {
            return self.IsUnicodeClass;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsCOMObjectFastRaw<T>()
        {
            return typeof(T).IsCOMObject;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsCOMObjectFast(this Type self)
        {
            return self.IsCOMObject;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsContextfulFastRaw<T>()
        {
            return typeof(T).IsContextful;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsContextfulFast(this Type self)
        {
            return self.IsContextful;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsEnumFastRaw<T>()
        {
            return typeof(T).IsEnum;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsEnumFast(this Type self)
        {
            return self.IsEnum;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsMarshalByRefFastRaw<T>()
        {
            return typeof(T).IsMarshalByRef;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsMarshalByRefFast(this Type self)
        {
            return self.IsMarshalByRef;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsPrimitiveFastRaw<T>()
        {
            return typeof(T).IsPrimitive;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsPrimitiveFast(this Type self)
        {
            return self.IsPrimitive;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsValueTypeFastRaw<T>()
        {
            return typeof(T).IsValueType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsValueTypeFast(this Type self)
        {
            return self.IsValueType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsSignatureTypeFastRaw<T>()
        {
            return typeof(T).IsSignatureType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsSignatureTypeFast(this Type self)
        {
            return self.IsSignatureType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsSecurityCriticalFastRaw<T>()
        {
            return typeof(T).IsSecurityCritical;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsSecurityCriticalFast(this Type self)
        {
            return self.IsSecurityCritical;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsSecuritySafeCriticalFastRaw<T>()
        {
            return typeof(T).IsSecuritySafeCritical;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsSecuritySafeCriticalFast(this Type self)
        {
            return self.IsSecuritySafeCritical;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsSecurityTransparentFastRaw<T>()
        {
            return typeof(T).IsSecurityTransparent;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsSecurityTransparentFast(this Type self)
        {
            return self.IsSecurityTransparent;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Runtime.InteropServices.StructLayoutAttribute GetStructLayoutAttributeFastRaw<T>()
        {
            return typeof(T).StructLayoutAttribute;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Runtime.InteropServices.StructLayoutAttribute GetStructLayoutAttributeFast(this Type self)
        {
            return self.StructLayoutAttribute;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Reflection.ConstructorInfo GetTypeInitializerFastRaw<T>()
        {
            return typeof(T).TypeInitializer;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Reflection.ConstructorInfo GetTypeInitializerFast(this Type self)
        {
            return self.TypeInitializer;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.RuntimeTypeHandle GetTypeHandleFastRaw<T>()
        {
            return typeof(T).TypeHandle;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.RuntimeTypeHandle GetTypeHandleFast(this Type self)
        {
            return self.TypeHandle;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Guid GetGUIDFastRaw<T>()
        {
            return typeof(T).GUID;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Guid GetGUIDFast(this Type self)
        {
            return self.GUID;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type GetBaseTypeFastRaw<T>()
        {
            return typeof(T).BaseType;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type GetBaseTypeFast(this Type self)
        {
            return self.BaseType;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Boolean IsInterfaceFastRaw<T>()
        {
            return typeof(T).IsInterface;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Boolean IsInterfaceFast(this Type self)
        {
            return self.IsInterface;
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Int32 GetHashCodeFastRaw<T>()
        {
            return typeof(T).GetHashCode();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Int32 GetHashCodeFast(this Type self)
        {
            return self.GetHashCode();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.String ToStringFastRaw<T>()
        {
            return typeof(T).ToString();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.String ToStringFast(this Type self)
        {
            return self.ToString();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.CustomAttributeData> GetCustomAttributesDataFastRaw<T>()
        {
            return typeof(T).GetCustomAttributesData().ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.CustomAttributeData> GetCustomAttributesDataFastRaw(this Type self)
        {
            return self.GetCustomAttributesData().ToArray();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.String> GetEnumNamesFastRaw<T>()
        {
            return typeof(T).GetEnumNames();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.String> GetEnumNamesFastRaw(this Type self)
        {
            return self.GetEnumNames();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type GetElementTypeFastRaw<T>()
        {
            return typeof(T).GetElementType();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type GetElementTypeFast(this Type self)
        {
            return self.GetElementType();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Int32 GetArrayRankFastRaw<T>()
        {
            return typeof(T).GetArrayRank();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Int32 GetArrayRankFast(this Type self)
        {
            return self.GetArrayRank();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type GetGenericTypeDefinitionFastRaw<T>()
        {
            return typeof(T).GetGenericTypeDefinition();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type GetGenericTypeDefinitionFast(this Type self)
        {
            return self.GetGenericTypeDefinition();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetGenericArgumentsFastRaw<T>()
        {
            return typeof(T).GetGenericArguments();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetGenericArgumentsFastRaw(this Type self)
        {
            return self.GetGenericArguments();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetGenericParameterConstraintsFastRaw<T>()
        {
            return typeof(T).GetGenericParameterConstraints();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetGenericParameterConstraintsFastRaw(this Type self)
        {
            return self.GetGenericParameterConstraints();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.MemberInfo> GetDefaultMembersFastRaw<T>()
        {
            return typeof(T).GetDefaultMembers();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.MemberInfo> GetDefaultMembersFastRaw(this Type self)
        {
            return self.GetDefaultMembers();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetInterfacesFastRaw<T>()
        {
            return typeof(T).GetInterfaces();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> GetInterfacesFastRaw(this Type self)
        {
            return self.GetInterfaces();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type GetEnumUnderlyingTypeFastRaw<T>()
        {
            return typeof(T).GetEnumUnderlyingType();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type GetEnumUnderlyingTypeFast(this Type self)
        {
            return self.GetEnumUnderlyingType();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type MakeArrayTypeFastRaw<T>()
        {
            return typeof(T).MakeArrayType();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type MakeArrayTypeFast(this Type self)
        {
            return self.MakeArrayType();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type MakeByRefTypeFastRaw<T>()
        {
            return typeof(T).MakeByRefType();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type MakeByRefTypeFast(this Type self)
        {
            return self.MakeByRefType();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::System.Type MakePointerTypeFastRaw<T>()
        {
            return typeof(T).MakePointerType();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static global::System.Type MakePointerTypeFast(this Type self)
        {
            return self.MakePointerType();
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Object> GetCustomAttributesFastRaw<T>(global::System.Boolean inherit)
        {
            return typeof(T).GetCustomAttributes(inherit);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Object> GetCustomAttributesFastRaw(this Type self, global::System.Boolean inherit)
        {
            return self.GetCustomAttributes(inherit);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Object> GetCustomAttributesFastRaw<T>(global::System.Type attributeType, global::System.Boolean inherit)
        {
            return typeof(T).GetCustomAttributes(attributeType, inherit);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Object> GetCustomAttributesFastRaw(this Type self, global::System.Type attributeType, global::System.Boolean inherit)
        {
            return self.GetCustomAttributes(attributeType, inherit);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> FindInterfacesFastRaw<T>(global::System.Reflection.TypeFilter filter, global::System.Object filterCriteria)
        {
            return typeof(T).FindInterfaces(filter, filterCriteria);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Type> FindInterfacesFastRaw(this Type self, global::System.Reflection.TypeFilter filter, global::System.Object filterCriteria)
        {
            return self.FindInterfaces(filter, filterCriteria);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.MemberInfo> FindMembersFastRaw<T>(global::System.Reflection.MemberTypes memberType, global::System.Reflection.BindingFlags bindingAttr, global::System.Reflection.MemberFilter filter, global::System.Object filterCriteria)
        {
            return typeof(T).FindMembers(memberType, bindingAttr, filter, filterCriteria);
        }
        [Memoization(Modifier = "public static", ThreadSafeType = ThreadSafeType.ThreadStatic)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static global::Katuusagi.ILPostProcessorCommon.ReadOnlyArray<global::System.Reflection.MemberInfo> FindMembersFastRaw(this Type self, global::System.Reflection.MemberTypes memberType, global::System.Reflection.BindingFlags bindingAttr, global::System.Reflection.MemberFilter filter, global::System.Object filterCriteria)
        {
            return self.FindMembers(memberType, bindingAttr, filter, filterCriteria);
        }
    }
}
