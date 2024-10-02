using NUnit.Framework;
using System;
using Unity.PerformanceTesting;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public partial class TypePerformanceTest
    {
        [Test]
        [Performance]
        public void IsAssignableFrom_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(object).IsAssignableFrom(typeof(int));
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void IsAssignableFrom_Fast()
        {
            Measure.Method(() =>
            {
                REType.IsAssignableFromFast<object, int>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMembers_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMembers();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMembers_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetMembersFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMembers_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMembersFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetNestedTypes_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetNestedTypes();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetNestedTypes_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetNestedTypesFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetNestedTypes_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetNestedTypesFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructors_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetConstructors();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructors_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetConstructorsFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructors_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetConstructorsFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetFields_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetFields();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetFields_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetFieldsFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetFields_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetFieldsFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetProperties_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetProperties();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetProperties_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetPropertiesFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetProperties_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetPropertiesFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethods_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMethods();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethods_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetMethodsFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethods_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMethodsFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetEvents_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetEvents();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetEvents_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetEventsFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetEvents_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetEventsFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMember_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMember("InstanceField");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMember_Fast()
        {
            var name = "InstanceField";
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMemberFast(name);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMember_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMemberFast("InstanceField");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetNestedType_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetNestedType("InnerType");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetNestedType_Fast()
        {
            string typeName = "InnerType";
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetNestedTypeFast(typeName);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetNestedType_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetNestedTypeFast("InnerType");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetNestedType_TypeOf()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).TypeOf("InnerType");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructor_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetConstructor(Type.EmptyTypes);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructor_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetConstructorFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructor_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetConstructorFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructor_ConstructorOf()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).ConstructorOf();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructorWithArg_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetConstructor(new Type[] { typeof(int) });
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructorWithArg_Fast()
        {
            var t = typeof(ClassTestFunctions);
            Measure.Method(() =>
            {
                t.GetConstructorFast<int>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructorWithArg_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetConstructorFast<int>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetConstructorWithArg_ConstructorOf()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).ConstructorOf<int>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetField_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetField("InstanceField");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetField_Fast()
        {
            var name = "InstanceProperty";
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetFieldFast(name);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetField_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetField_FieldOf()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).FieldOf("InstanceField");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetProperty_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetProperty("InstanceProperty");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetProperty_Fast()
        {
            var name = "InstanceProperty";
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetPropertyFast(name);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetProperty_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetPropertyFast("InstanceProperty");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethod_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMethod("UniqueMethod");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethod_Fast()
        {
            var name = "UniqueMethod";
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMethodFast(name);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethod_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMethodFast("UniqueMethod");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethod_MethodOf()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).MethodOf<VoidLike>("UniqueMethod");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethodWithArg_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMethod("InstanceMethod", new Type[] { typeof(int) });
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethodWithArg_Fast()
        {
            var name = "InstanceMethod";
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMethodFast<int>(name);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethodWithArg_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetMethodWithArg_MethodOf()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).MethodOf<int, int>("InstanceMethod");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetEvent_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetEvent("InstanceEvent");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetEvent_Fast()
        {
            var name = "InstanceEvent";
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetEventFast(name);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetEvent_Fast_Optimized()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).GetEventFast("InstanceEvent");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateClassInstance_Legacy()
        {
            Measure.Method(() =>
            {
                Activator.CreateInstance<ClassTestFunctions>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateClassInstance_Fast()
        {
            Measure.Method(() =>
            {
                REType.CreateInstance<ClassTestFunctions>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateClassInstanceWithArg_Legacy()
        {
            Measure.Method(() =>
            {
                Activator.CreateInstance(typeof(ClassTestFunctions), 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateClassInstanceWithArg_Fast()
        {
            Measure.Method(() =>
            {
                REType.CreateInstance<ClassTestFunctions, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateStructInstance_Legacy()
        {
            Measure.Method(() =>
            {
                Activator.CreateInstance<StructTestFunctions>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateStructInstance_Fast()
        {
            Measure.Method(() =>
            {
                REType.CreateInstance<StructTestFunctions>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateStructInstanceWrapped_Legacy()
        {
            T Wrapped<T>()
                where T : struct
            {
                return Activator.CreateInstance<T>();
            }
            Measure.Method(() =>
            {
                Wrapped<StructTestFunctions>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateStructInstanceWrapped_Fast()
        {
            T Wrapped<T>()
                where T : struct
            {
                return REType.CreateInstance<T>();
            }
            Measure.Method(() =>
            {
                Wrapped<StructTestFunctions>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateStructInstanceWithArg_Legacy()
        {
            Measure.Method(() =>
            {
                Activator.CreateInstance(typeof(StructTestFunctions), 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void CreateStructInstanceWithArg_Fast()
        {
            Measure.Method(() =>
            {
                REType.CreateInstance<StructTestFunctions, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
    }
}
