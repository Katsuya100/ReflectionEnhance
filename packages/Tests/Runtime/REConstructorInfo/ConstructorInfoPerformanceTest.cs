using NUnit.Framework;
using System;
using Unity.PerformanceTesting;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class ConstructorInfoPerformanceTest
    {
        [Test]
        [Performance]
        public void Invoke_Legacy_Class()
        {
            var ctor = typeof(ClassTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                ctor.Invoke(new object[] { 10 });
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Legacy_Struct()
        {
            var ctor = typeof(StructTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                ctor.Invoke(new object[] { 10 });
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_LowAlloc_Class()
        {
            var ctor = typeof(ClassTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceLowAlloc(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_LowAlloc_Struct()
        {
            var ctor = typeof(StructTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceLowAlloc(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Class()
        {
            var ctor = typeof(ClassTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceFast<ClassTestFunctions, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Class_ArgUpCast()
        {
            var ctor = typeof(ClassTestFunctions).GetConstructorFast<object>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceFast<ClassTestFunctions, IComparable>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Class_ArgUpCastFromStruct()
        {
            var ctor = typeof(ClassTestFunctions).GetConstructorFast<IComparable>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceFast<ClassTestFunctions, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Class_ArgDownCast()
        {
            var ctor = typeof(ClassTestFunctions).GetConstructorFast<IComparable>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceFast<ClassTestFunctions, object>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Class_ArgDownCastToStruct()
        {
            var ctor = typeof(ClassTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceFast<ClassTestFunctions, object>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Class_ResultUpCast()
        {
            var ctor = typeof(ClassTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                var result = ctor.InvokeInstanceFast<object, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Struct()
        {
            var ctor = typeof(StructTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                var result = ctor.InvokeInstanceFast<StructTestFunctions, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Struct_ArgUpCast()
        {
            var ctor = typeof(StructTestFunctions).GetConstructorFast<object>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceFast<StructTestFunctions, IComparable>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Struct_ArgUpCastFromStruct()
        {
            var ctor = typeof(StructTestFunctions).GetConstructorFast<IComparable>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceFast<StructTestFunctions, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Struct_ArgDownCast()
        {
            var ctor = typeof(StructTestFunctions).GetConstructorFast<IComparable>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceFast<StructTestFunctions, object>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Struct_ArgDownCastToStruct()
        {
            var ctor = typeof(StructTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                ctor.InvokeInstanceFast<StructTestFunctions, object>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_Fast_Struct_ResultUpCast()
        {
            var ctor = typeof(StructTestFunctions).GetConstructorFast<int>();
            Measure.Method(() =>
            {
                var result = ctor.InvokeInstanceFast<object, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_New_Class()
        {
            Measure.Method(() =>
            {
                new ClassTestFunctions(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Invoke_New_Struct()
        {
            Measure.Method(() =>
            {
                new StructTestFunctions(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
    }
}
