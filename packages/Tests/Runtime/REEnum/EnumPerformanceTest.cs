using NUnit.Framework;
using System;
using Unity.PerformanceTesting;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class EnumPerformanceTest
    {
        [Test]
        [Performance]
        public void GetValues_Legacy()
        {
            Measure.Method(() =>
            {
                Enum.GetValues(typeof(EnumFlags));
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetValues_Fast()
        {
            Measure.Method(() =>
            {
                REEnum.GetValuesFast<EnumFlags>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetNames_Legacy()
        {
            Measure.Method(() =>
            {
                Enum.GetNames(typeof(EnumFlags));
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetNames_Fast()
        {
            Measure.Method(() =>
            {
                REEnum.GetNamesFast<EnumFlags>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetName_Legacy()
        {
            Measure.Method(() =>
            {
                Enum.GetName(typeof(EnumFlags), EnumFlags.A);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetName_Fast()
        {
            Measure.Method(() =>
            {
                REEnum.GetNameFast(EnumFlags.A);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Parse_Legacy()
        {
            Measure.Method(() =>
            {
                Enum.Parse<EnumFlags>("A");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void Parse_Fast()
        {
            Measure.Method(() =>
            {
                REEnum.ParseFast<EnumFlags>("A");
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void IsDefined_Legacy()
        {
            Measure.Method(() =>
            {
                Enum.IsDefined(typeof(EnumFlags), EnumFlags.A);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void IsDefined_Fast()
        {
            Measure.Method(() =>
            {
                REEnum.IsDefinedFast(EnumFlags.A);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetUnderlyingType_Legacy()
        {
            Measure.Method(() =>
            {
                Enum.GetUnderlyingType(typeof(EnumFlags));
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetUnderlyingType_Fast()
        {
            Measure.Method(() =>
            {
                REEnum.GetUnderlyingTypeFast<EnumFlags>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void HasFlags_Legacy()
        {
            var v = EnumFlags.A | EnumFlags.C;
            Measure.Method(() =>
            {
                v.HasFlag(EnumFlags.A);
                v.HasFlag(EnumFlags.B);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void HasFlags_LowAlloc()
        {
            var v = EnumFlags.A | EnumFlags.C;
            Measure.Method(() =>
            {
                v.HasFlagLowAlloc(EnumFlags.A);
                v.HasFlagLowAlloc(EnumFlags.B);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void ToObject()
        {
            Measure.Method(() =>
            {
                Enum.ToObject(typeof(EnumFlags), 1);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void ToEnum()
        {
            Measure.Method(() =>
            {
                REEnum.ToEnum<int, EnumFlags>(1);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void EnumTo()
        {
            Measure.Method(() =>
            {
                REEnum.EnumTo<EnumFlags, int>(EnumFlags.C);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(100000)
            .MeasurementCount(20)
            .Run();
        }
    }
}
