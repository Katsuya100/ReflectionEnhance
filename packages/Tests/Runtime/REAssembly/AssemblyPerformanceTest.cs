using NUnit.Framework;
using Unity.PerformanceTesting;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class AssemblyPerformanceTest
    {
        [Test]
        [Performance]
        public void GetModule_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).Assembly.GetModule("Katuusagi.ReflectionEnhance.Tests.dll");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetModule_Fast()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).Assembly.GetModuleFast("Katuusagi.ReflectionEnhance.Tests.dll");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetModules_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).Assembly.GetModules();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetModules_Fast()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).Assembly.GetModulesFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetType_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).Assembly.GetType("Katuusagi.ReflectionEnhance.Tests.ClassTestFunctions");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetType_Fast()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).Assembly.GetTypeFast("Katuusagi.ReflectionEnhance.Tests.ClassTestFunctions");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetTypes_Legacy()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).Assembly.GetTypes();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetTypes_Fast()
        {
            Measure.Method(() =>
            {
                typeof(ClassTestFunctions).Assembly.GetTypesFast();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
    }
}
