using NUnit.Framework;
using Unity.PerformanceTesting;
namespace Katuusagi.ReflectionEnhance.Tests
{
    public partial class TypePerformanceTest
    {
        [Test]
        [Performance]
        public void GetMemberType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.MemberType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetMemberType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetMemberTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetMemberType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMemberTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetName_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.Name;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetName_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetNameFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetName_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetNameFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetDeclaringType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.DeclaringType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetDeclaringType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetDeclaringTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetDeclaringType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetDeclaringTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetReflectedType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.ReflectedType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetReflectedType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetReflectedTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetReflectedType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetReflectedTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetModule_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.Module;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetModule_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetModuleFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetModule_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetModuleFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetCustomAttributes_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.CustomAttributes;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetCustomAttributes_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetCustomAttributesFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetCustomAttributes_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetCustomAttributesFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetMetadataToken_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.MetadataToken;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetMetadataToken_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetMetadataTokenFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetMetadataToken_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMetadataTokenFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSerializable_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsSerializable;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSerializable_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsSerializableFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSerializable_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsSerializableFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void ContainsGenericParameters_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.ContainsGenericParameters;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void ContainsGenericParameters_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.ContainsGenericParametersFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void ContainsGenericParameters_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).ContainsGenericParametersFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsVisible_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsVisible;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsVisible_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsVisibleFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsVisible_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsVisibleFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetNamespace_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.Namespace;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetNamespace_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetNamespaceFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetNamespace_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetNamespaceFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetAssemblyQualifiedName_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.AssemblyQualifiedName;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetAssemblyQualifiedName_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetAssemblyQualifiedNameFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetAssemblyQualifiedName_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetAssemblyQualifiedNameFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetFullName_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.FullName;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetFullName_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetFullNameFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetFullName_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetFullNameFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetAssembly_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.Assembly;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetAssembly_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetAssemblyFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetAssembly_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetAssemblyFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNested_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsNested;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNested_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsNestedFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNested_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsNestedFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetUnderlyingSystemType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.UnderlyingSystemType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetUnderlyingSystemType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetUnderlyingSystemTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetUnderlyingSystemType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetUnderlyingSystemTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsTypeDefinition_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsTypeDefinition;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsTypeDefinition_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsTypeDefinitionFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsTypeDefinition_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsTypeDefinitionFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsArray_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsArray;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsArray_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsArrayFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsArray_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsArrayFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsByRef_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsByRef;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsByRef_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsByRefFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsByRef_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsByRefFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsPointer_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsPointer;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsPointer_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsPointerFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsPointer_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsPointerFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsConstructedGenericType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsConstructedGenericType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsConstructedGenericType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsConstructedGenericTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsConstructedGenericType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsConstructedGenericTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericParameter_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsGenericParameter;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericParameter_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsGenericParameterFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericParameter_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsGenericParameterFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericTypeParameter_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsGenericTypeParameter;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericTypeParameter_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsGenericTypeParameterFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericTypeParameter_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsGenericTypeParameterFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericMethodParameter_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsGenericMethodParameter;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericMethodParameter_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsGenericMethodParameterFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericMethodParameter_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsGenericMethodParameterFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsGenericType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsGenericTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsGenericTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericTypeDefinition_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsGenericTypeDefinition;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericTypeDefinition_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsGenericTypeDefinitionFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsGenericTypeDefinition_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsGenericTypeDefinitionFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSZArray_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsSZArray;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSZArray_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsSZArrayFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSZArray_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsSZArrayFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsVariableBoundArray_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsVariableBoundArray;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsVariableBoundArray_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsVariableBoundArrayFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsVariableBoundArray_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsVariableBoundArrayFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsByRefLike_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsByRefLike;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsByRefLike_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsByRefLikeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsByRefLike_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsByRefLikeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void HasElementType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.HasElementType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void HasElementType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.HasElementTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void HasElementType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).HasElementTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGenericTypeArguments_Legacy()
        {
            var t = typeof(GenericClassTestFunctions<int>);
            Measure.Method(() =>
            {
                _ = t.GenericTypeArguments;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGenericTypeArguments_Fast()
        {
            var t = typeof(GenericClassTestFunctions<int>);
            Measure.Method(() =>
            {
                t.GetGenericTypeArgumentsFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGenericTypeArguments_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(GenericClassTestFunctions<int>).GetGenericTypeArgumentsFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetAttributes_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.Attributes;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetAttributes_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetAttributesFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetAttributes_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetAttributesFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAbstract_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsAbstract;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAbstract_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsAbstractFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAbstract_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsAbstractFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsImport_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsImport;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsImport_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsImportFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsImport_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsImportFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSealed_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsSealed;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSealed_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsSealedFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSealed_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsSealedFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSpecialName_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsSpecialName;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSpecialName_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsSpecialNameFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSpecialName_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsSpecialNameFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsClass_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsClass;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsClass_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsClassFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsClass_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsClassFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedAssembly_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsNestedAssembly;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedAssembly_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsNestedAssemblyFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedAssembly_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsNestedAssemblyFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedFamANDAssem_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsNestedFamANDAssem;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedFamANDAssem_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsNestedFamANDAssemFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedFamANDAssem_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsNestedFamANDAssemFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedFamily_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsNestedFamily;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedFamily_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsNestedFamilyFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedFamily_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsNestedFamilyFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedFamORAssem_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsNestedFamORAssem;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedFamORAssem_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsNestedFamORAssemFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedFamORAssem_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsNestedFamORAssemFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedPrivate_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsNestedPrivate;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedPrivate_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsNestedPrivateFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedPrivate_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsNestedPrivateFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedPublic_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsNestedPublic;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedPublic_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsNestedPublicFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNestedPublic_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsNestedPublicFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNotPublic_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsNotPublic;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNotPublic_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsNotPublicFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsNotPublic_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsNotPublicFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsPublic_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsPublic;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsPublic_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsPublicFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsPublic_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsPublicFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAutoLayout_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsAutoLayout;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAutoLayout_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsAutoLayoutFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAutoLayout_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsAutoLayoutFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsExplicitLayout_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsExplicitLayout;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsExplicitLayout_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsExplicitLayoutFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsExplicitLayout_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsExplicitLayoutFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsLayoutSequential_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsLayoutSequential;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsLayoutSequential_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsLayoutSequentialFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsLayoutSequential_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsLayoutSequentialFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAnsiClass_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsAnsiClass;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAnsiClass_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsAnsiClassFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAnsiClass_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsAnsiClassFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAutoClass_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsAutoClass;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAutoClass_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsAutoClassFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsAutoClass_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsAutoClassFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsUnicodeClass_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsUnicodeClass;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsUnicodeClass_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsUnicodeClassFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsUnicodeClass_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsUnicodeClassFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsCOMObject_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsCOMObject;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsCOMObject_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsCOMObjectFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsCOMObject_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsCOMObjectFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsContextful_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsContextful;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsContextful_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsContextfulFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsContextful_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsContextfulFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsEnum_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsEnum;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsEnum_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsEnumFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsEnum_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsEnumFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsMarshalByRef_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsMarshalByRef;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsMarshalByRef_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsMarshalByRefFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsMarshalByRef_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsMarshalByRefFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsPrimitive_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsPrimitive;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsPrimitive_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsPrimitiveFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsPrimitive_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsPrimitiveFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsValueType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsValueType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsValueType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsValueTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsValueType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsValueTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSignatureType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsSignatureType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSignatureType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsSignatureTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsSignatureType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsSignatureTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetStructLayoutAttribute_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.StructLayoutAttribute;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetStructLayoutAttribute_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetStructLayoutAttributeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetStructLayoutAttribute_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetStructLayoutAttributeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetTypeInitializer_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.TypeInitializer;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetTypeInitializer_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetTypeInitializerFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetTypeInitializer_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetTypeInitializerFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetTypeHandle_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.TypeHandle;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetTypeHandle_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetTypeHandleFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetTypeHandle_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetTypeHandleFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGUID_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.GUID;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGUID_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetGUIDFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGUID_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetGUIDFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetBaseType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.BaseType;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetBaseType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetBaseTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetBaseType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetBaseTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsInterface_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                _ = t.IsInterface;
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsInterface_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.IsInterfaceFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void IsInterface_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).IsInterfaceFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetHashCode_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetHashCode();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetHashCode_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetHashCodeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetHashCode_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetHashCodeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void ToString_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.ToString();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void ToString_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.ToStringFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void ToString_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).ToStringFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetCustomAttributesData_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetCustomAttributesData();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetCustomAttributesData_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetCustomAttributesDataFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetCustomAttributesData_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetCustomAttributesDataFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetEnumNames_Legacy()
        {
            var t = typeof(EnumFlags);
            Measure.Method(() =>
            {
                t.GetEnumNames();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetEnumNames_Fast()
        {
            var t = typeof(EnumFlags);
            Measure.Method(() =>
            {
                t.GetEnumNamesFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetEnumNames_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(EnumFlags).GetEnumNamesFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetElementType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetElementType();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetElementType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetElementTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetElementType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetElementTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetArrayRank_Legacy()
        {
            var t = typeof(int[]);
            Measure.Method(() =>
            {
                t.GetArrayRank();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetArrayRank_Fast()
        {
            var t = typeof(int[]);
            Measure.Method(() =>
            {
                t.GetArrayRankFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetArrayRank_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(int[]).GetArrayRankFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGenericTypeDefinition_Legacy()
        {
            var t = typeof(GenericClassTestFunctions<int>);
            Measure.Method(() =>
            {
                t.GetGenericTypeDefinition();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGenericTypeDefinition_Fast()
        {
            var t = typeof(GenericClassTestFunctions<int>);
            Measure.Method(() =>
            {
                t.GetGenericTypeDefinitionFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGenericTypeDefinition_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(GenericClassTestFunctions<int>).GetGenericTypeDefinitionFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGenericArguments_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetGenericArguments();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGenericArguments_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetGenericArgumentsFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetGenericArguments_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetGenericArgumentsFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetDefaultMembers_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetDefaultMembers();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetDefaultMembers_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetDefaultMembersFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetDefaultMembers_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetDefaultMembersFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetInterfaces_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetInterfaces();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetInterfaces_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetInterfacesFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetInterfaces_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetInterfacesFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetEnumUnderlyingType_Legacy()
        {
            var t = typeof(EnumIntTest);
            Measure.Method(() =>
            {
                t.GetEnumUnderlyingType();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetEnumUnderlyingType_Fast()
        {
            var t = typeof(EnumIntTest);
            Measure.Method(() =>
            {
                t.GetEnumUnderlyingTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetEnumUnderlyingType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(EnumIntTest).GetEnumUnderlyingTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void MakeArrayType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.MakeArrayType();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void MakeArrayType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.MakeArrayTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void MakeArrayType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).MakeArrayTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void MakeByRefType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.MakeByRefType();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void MakeByRefType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.MakeByRefTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void MakeByRefType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).MakeByRefTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void MakePointerType_Legacy()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.MakePointerType();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void MakePointerType_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.MakePointerTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void MakePointerType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).MakePointerTypeFast();
            }
            )
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
    }
}
