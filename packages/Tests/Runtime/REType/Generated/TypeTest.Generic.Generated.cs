using NUnit.Framework;
namespace Katuusagi.ReflectionEnhance.Tests
{
    public partial class TypeTest
    {
        [Test]
        public void GetMemberType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetMemberTypeFast();
            var r = t.MemberType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetMemberType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetMemberTypeFast();
            var r = typeof(ClassTestFunctions).MemberType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetName_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetNameFast();
            var r = t.Name;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetName_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetNameFast();
            var r = typeof(ClassTestFunctions).Name;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetDeclaringType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetDeclaringTypeFast();
            var r = t.DeclaringType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetDeclaringType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetDeclaringTypeFast();
            var r = typeof(ClassTestFunctions).DeclaringType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetReflectedType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetReflectedTypeFast();
            var r = t.ReflectedType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetReflectedType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetReflectedTypeFast();
            var r = typeof(ClassTestFunctions).ReflectedType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetModule_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetModuleFast();
            var r = t.Module;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetModule_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetModuleFast();
            var r = typeof(ClassTestFunctions).Module;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetCustomAttributes_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetCustomAttributesFast();
            var r = t.CustomAttributes;
            foreach (var v in l)
            {
                v.ToString();
            }
            foreach (var v in r)
            {
                v.ToString();
            }
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetCustomAttributes_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetCustomAttributesFast();
            var r = typeof(ClassTestFunctions).CustomAttributes;
            foreach (var v in l)
            {
                v.ToString();
            }
            foreach (var v in r)
            {
                v.ToString();
            }
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetMetadataToken_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetMetadataTokenFast();
            var r = t.MetadataToken;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetMetadataToken_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetMetadataTokenFast();
            var r = typeof(ClassTestFunctions).MetadataToken;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSerializable_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsSerializableFast();
            var r = t.IsSerializable;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSerializable_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsSerializableFast();
            var r = typeof(ClassTestFunctions).IsSerializable;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void ContainsGenericParameters_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.ContainsGenericParametersFast();
            var r = t.ContainsGenericParameters;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void ContainsGenericParameters_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).ContainsGenericParametersFast();
            var r = typeof(ClassTestFunctions).ContainsGenericParameters;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsVisible_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsVisibleFast();
            var r = t.IsVisible;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsVisible_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsVisibleFast();
            var r = typeof(ClassTestFunctions).IsVisible;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetNamespace_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetNamespaceFast();
            var r = t.Namespace;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetNamespace_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetNamespaceFast();
            var r = typeof(ClassTestFunctions).Namespace;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetAssemblyQualifiedName_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetAssemblyQualifiedNameFast();
            var r = t.AssemblyQualifiedName;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetAssemblyQualifiedName_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetAssemblyQualifiedNameFast();
            var r = typeof(ClassTestFunctions).AssemblyQualifiedName;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetFullName_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetFullNameFast();
            var r = t.FullName;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetFullName_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetFullNameFast();
            var r = typeof(ClassTestFunctions).FullName;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetAssembly_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetAssemblyFast();
            var r = t.Assembly;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetAssembly_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetAssemblyFast();
            var r = typeof(ClassTestFunctions).Assembly;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNested_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsNestedFast();
            var r = t.IsNested;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNested_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsNestedFast();
            var r = typeof(ClassTestFunctions).IsNested;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetUnderlyingSystemType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetUnderlyingSystemTypeFast();
            var r = t.UnderlyingSystemType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetUnderlyingSystemType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetUnderlyingSystemTypeFast();
            var r = typeof(ClassTestFunctions).UnderlyingSystemType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsTypeDefinition_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsTypeDefinitionFast();
            var r = t.IsTypeDefinition;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsTypeDefinition_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsTypeDefinitionFast();
            var r = typeof(ClassTestFunctions).IsTypeDefinition;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsArray_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsArrayFast();
            var r = t.IsArray;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsArray_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsArrayFast();
            var r = typeof(ClassTestFunctions).IsArray;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsByRef_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsByRefFast();
            var r = t.IsByRef;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsByRef_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsByRefFast();
            var r = typeof(ClassTestFunctions).IsByRef;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsPointer_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsPointerFast();
            var r = t.IsPointer;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsPointer_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsPointerFast();
            var r = typeof(ClassTestFunctions).IsPointer;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsConstructedGenericType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsConstructedGenericTypeFast();
            var r = t.IsConstructedGenericType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsConstructedGenericType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsConstructedGenericTypeFast();
            var r = typeof(ClassTestFunctions).IsConstructedGenericType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericParameter_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsGenericParameterFast();
            var r = t.IsGenericParameter;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericParameter_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsGenericParameterFast();
            var r = typeof(ClassTestFunctions).IsGenericParameter;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericTypeParameter_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsGenericTypeParameterFast();
            var r = t.IsGenericTypeParameter;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericTypeParameter_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsGenericTypeParameterFast();
            var r = typeof(ClassTestFunctions).IsGenericTypeParameter;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericMethodParameter_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsGenericMethodParameterFast();
            var r = t.IsGenericMethodParameter;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericMethodParameter_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsGenericMethodParameterFast();
            var r = typeof(ClassTestFunctions).IsGenericMethodParameter;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsGenericTypeFast();
            var r = t.IsGenericType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsGenericTypeFast();
            var r = typeof(ClassTestFunctions).IsGenericType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericTypeDefinition_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsGenericTypeDefinitionFast();
            var r = t.IsGenericTypeDefinition;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsGenericTypeDefinition_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsGenericTypeDefinitionFast();
            var r = typeof(ClassTestFunctions).IsGenericTypeDefinition;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSZArray_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsSZArrayFast();
            var r = t.IsSZArray;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSZArray_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsSZArrayFast();
            var r = typeof(ClassTestFunctions).IsSZArray;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsVariableBoundArray_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsVariableBoundArrayFast();
            var r = t.IsVariableBoundArray;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsVariableBoundArray_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsVariableBoundArrayFast();
            var r = typeof(ClassTestFunctions).IsVariableBoundArray;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsByRefLike_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsByRefLikeFast();
            var r = t.IsByRefLike;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsByRefLike_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsByRefLikeFast();
            var r = typeof(ClassTestFunctions).IsByRefLike;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void HasElementType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.HasElementTypeFast();
            var r = t.HasElementType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void HasElementType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).HasElementTypeFast();
            var r = typeof(ClassTestFunctions).HasElementType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetGenericTypeArguments_Fast()
        {
            var t = typeof(GenericClassTestFunctions<int>);
            var l = t.GetGenericTypeArgumentsFast();
            var r = t.GenericTypeArguments;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetGenericTypeArguments_Fast_Optimized()
        {
            var l = typeof(GenericClassTestFunctions<int>).GetGenericTypeArgumentsFast();
            var r = typeof(GenericClassTestFunctions<int>).GenericTypeArguments;
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetAttributes_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetAttributesFast();
            var r = t.Attributes;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetAttributes_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetAttributesFast();
            var r = typeof(ClassTestFunctions).Attributes;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsAbstract_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsAbstractFast();
            var r = t.IsAbstract;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsAbstract_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsAbstractFast();
            var r = typeof(ClassTestFunctions).IsAbstract;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsImport_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsImportFast();
            var r = t.IsImport;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsImport_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsImportFast();
            var r = typeof(ClassTestFunctions).IsImport;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSealed_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsSealedFast();
            var r = t.IsSealed;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSealed_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsSealedFast();
            var r = typeof(ClassTestFunctions).IsSealed;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSpecialName_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsSpecialNameFast();
            var r = t.IsSpecialName;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSpecialName_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsSpecialNameFast();
            var r = typeof(ClassTestFunctions).IsSpecialName;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsClass_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsClassFast();
            var r = t.IsClass;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsClass_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsClassFast();
            var r = typeof(ClassTestFunctions).IsClass;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedAssembly_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsNestedAssemblyFast();
            var r = t.IsNestedAssembly;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedAssembly_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsNestedAssemblyFast();
            var r = typeof(ClassTestFunctions).IsNestedAssembly;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedFamANDAssem_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsNestedFamANDAssemFast();
            var r = t.IsNestedFamANDAssem;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedFamANDAssem_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsNestedFamANDAssemFast();
            var r = typeof(ClassTestFunctions).IsNestedFamANDAssem;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedFamily_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsNestedFamilyFast();
            var r = t.IsNestedFamily;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedFamily_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsNestedFamilyFast();
            var r = typeof(ClassTestFunctions).IsNestedFamily;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedFamORAssem_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsNestedFamORAssemFast();
            var r = t.IsNestedFamORAssem;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedFamORAssem_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsNestedFamORAssemFast();
            var r = typeof(ClassTestFunctions).IsNestedFamORAssem;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedPrivate_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsNestedPrivateFast();
            var r = t.IsNestedPrivate;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedPrivate_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsNestedPrivateFast();
            var r = typeof(ClassTestFunctions).IsNestedPrivate;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedPublic_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsNestedPublicFast();
            var r = t.IsNestedPublic;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNestedPublic_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsNestedPublicFast();
            var r = typeof(ClassTestFunctions).IsNestedPublic;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNotPublic_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsNotPublicFast();
            var r = t.IsNotPublic;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsNotPublic_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsNotPublicFast();
            var r = typeof(ClassTestFunctions).IsNotPublic;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsPublic_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsPublicFast();
            var r = t.IsPublic;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsPublic_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsPublicFast();
            var r = typeof(ClassTestFunctions).IsPublic;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsAutoLayout_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsAutoLayoutFast();
            var r = t.IsAutoLayout;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsAutoLayout_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsAutoLayoutFast();
            var r = typeof(ClassTestFunctions).IsAutoLayout;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsExplicitLayout_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsExplicitLayoutFast();
            var r = t.IsExplicitLayout;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsExplicitLayout_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsExplicitLayoutFast();
            var r = typeof(ClassTestFunctions).IsExplicitLayout;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsLayoutSequential_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsLayoutSequentialFast();
            var r = t.IsLayoutSequential;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsLayoutSequential_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsLayoutSequentialFast();
            var r = typeof(ClassTestFunctions).IsLayoutSequential;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsAnsiClass_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsAnsiClassFast();
            var r = t.IsAnsiClass;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsAnsiClass_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsAnsiClassFast();
            var r = typeof(ClassTestFunctions).IsAnsiClass;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsAutoClass_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsAutoClassFast();
            var r = t.IsAutoClass;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsAutoClass_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsAutoClassFast();
            var r = typeof(ClassTestFunctions).IsAutoClass;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsUnicodeClass_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsUnicodeClassFast();
            var r = t.IsUnicodeClass;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsUnicodeClass_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsUnicodeClassFast();
            var r = typeof(ClassTestFunctions).IsUnicodeClass;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsCOMObject_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsCOMObjectFast();
            var r = t.IsCOMObject;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsCOMObject_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsCOMObjectFast();
            var r = typeof(ClassTestFunctions).IsCOMObject;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsContextful_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsContextfulFast();
            var r = t.IsContextful;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsContextful_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsContextfulFast();
            var r = typeof(ClassTestFunctions).IsContextful;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsEnum_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsEnumFast();
            var r = t.IsEnum;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsEnum_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsEnumFast();
            var r = typeof(ClassTestFunctions).IsEnum;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsMarshalByRef_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsMarshalByRefFast();
            var r = t.IsMarshalByRef;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsMarshalByRef_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsMarshalByRefFast();
            var r = typeof(ClassTestFunctions).IsMarshalByRef;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsPrimitive_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsPrimitiveFast();
            var r = t.IsPrimitive;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsPrimitive_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsPrimitiveFast();
            var r = typeof(ClassTestFunctions).IsPrimitive;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsValueType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsValueTypeFast();
            var r = t.IsValueType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsValueType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsValueTypeFast();
            var r = typeof(ClassTestFunctions).IsValueType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSignatureType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsSignatureTypeFast();
            var r = t.IsSignatureType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsSignatureType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsSignatureTypeFast();
            var r = typeof(ClassTestFunctions).IsSignatureType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetStructLayoutAttribute_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetStructLayoutAttributeFast();
            var r = t.StructLayoutAttribute;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetStructLayoutAttribute_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetStructLayoutAttributeFast();
            var r = typeof(ClassTestFunctions).StructLayoutAttribute;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetTypeInitializer_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetTypeInitializerFast();
            var r = t.TypeInitializer;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetTypeInitializer_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetTypeInitializerFast();
            var r = typeof(ClassTestFunctions).TypeInitializer;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetTypeHandle_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetTypeHandleFast();
            var r = t.TypeHandle;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetTypeHandle_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetTypeHandleFast();
            var r = typeof(ClassTestFunctions).TypeHandle;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetGUID_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetGUIDFast();
            var r = t.GUID;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetGUID_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetGUIDFast();
            var r = typeof(ClassTestFunctions).GUID;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetBaseType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetBaseTypeFast();
            var r = t.BaseType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetBaseType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetBaseTypeFast();
            var r = typeof(ClassTestFunctions).BaseType;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsInterface_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.IsInterfaceFast();
            var r = t.IsInterface;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void IsInterface_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).IsInterfaceFast();
            var r = typeof(ClassTestFunctions).IsInterface;
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetHashCode_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetHashCodeFast();
            var r = t.GetHashCode();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetHashCode_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetHashCodeFast();
            var r = typeof(ClassTestFunctions).GetHashCode();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void ToString_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.ToStringFast();
            var r = t.ToString();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void ToString_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).ToStringFast();
            var r = typeof(ClassTestFunctions).ToString();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetCustomAttributesData_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetCustomAttributesDataFast();
            var r = t.GetCustomAttributesData();
            foreach (var v in l)
            {
                v.ToString();
            }
            foreach (var v in r)
            {
                v.ToString();
            }
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetCustomAttributesData_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetCustomAttributesDataFast();
            var r = typeof(ClassTestFunctions).GetCustomAttributesData();
            foreach (var v in l)
            {
                v.ToString();
            }
            foreach (var v in r)
            {
                v.ToString();
            }
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetEnumNames_Fast()
        {
            var t = typeof(EnumFlags);
            var l = t.GetEnumNamesFast();
            var r = t.GetEnumNames();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetEnumNames_Fast_Optimized()
        {
            var l = typeof(EnumFlags).GetEnumNamesFast();
            var r = typeof(EnumFlags).GetEnumNames();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetElementType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetElementTypeFast();
            var r = t.GetElementType();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetElementType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetElementTypeFast();
            var r = typeof(ClassTestFunctions).GetElementType();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetArrayRank_Fast()
        {
            var t = typeof(int[]);
            var l = t.GetArrayRankFast();
            var r = t.GetArrayRank();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetArrayRank_Fast_Optimized()
        {
            var l = typeof(int[]).GetArrayRankFast();
            var r = typeof(int[]).GetArrayRank();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetGenericTypeDefinition_Fast()
        {
            var t = typeof(GenericClassTestFunctions<int>);
            var l = t.GetGenericTypeDefinitionFast();
            var r = t.GetGenericTypeDefinition();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetGenericTypeDefinition_Fast_Optimized()
        {
            var l = typeof(GenericClassTestFunctions<int>).GetGenericTypeDefinitionFast();
            var r = typeof(GenericClassTestFunctions<int>).GetGenericTypeDefinition();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetGenericArguments_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetGenericArgumentsFast();
            var r = t.GetGenericArguments();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetGenericArguments_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetGenericArgumentsFast();
            var r = typeof(ClassTestFunctions).GetGenericArguments();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetDefaultMembers_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetDefaultMembersFast();
            var r = t.GetDefaultMembers();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetDefaultMembers_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetDefaultMembersFast();
            var r = typeof(ClassTestFunctions).GetDefaultMembers();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetInterfaces_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.GetInterfacesFast();
            var r = t.GetInterfaces();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetInterfaces_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).GetInterfacesFast();
            var r = typeof(ClassTestFunctions).GetInterfaces();
            TestUtils.AreBothContains(l, r);
        }
        [Test]
        public void GetEnumUnderlyingType_Fast()
        {
            var t = typeof(EnumIntTest);
            var l = t.GetEnumUnderlyingTypeFast();
            var r = t.GetEnumUnderlyingType();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void GetEnumUnderlyingType_Fast_Optimized()
        {
            var l = typeof(EnumIntTest).GetEnumUnderlyingTypeFast();
            var r = typeof(EnumIntTest).GetEnumUnderlyingType();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void MakeArrayType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.MakeArrayTypeFast();
            var r = t.MakeArrayType();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void MakeArrayType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).MakeArrayTypeFast();
            var r = typeof(ClassTestFunctions).MakeArrayType();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void MakeByRefType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.MakeByRefTypeFast();
            var r = t.MakeByRefType();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void MakeByRefType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).MakeByRefTypeFast();
            var r = typeof(ClassTestFunctions).MakeByRefType();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void MakePointerType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            var l = t.MakePointerTypeFast();
            var r = t.MakePointerType();
            Assert.AreEqual(l, r);
        }
        [Test]
        public void MakePointerType_Fast_Optimized()
        {
            var l = typeof(ClassTestFunctions).MakePointerTypeFast();
            var r = typeof(ClassTestFunctions).MakePointerType();
            Assert.AreEqual(l, r);
        }
    }
}
