using NUnit.Framework;
using System;
using Unity.PerformanceTesting;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class FieldInfoPerformanceTest
    {
        [Test]
        [Performance]
        public void GetClassInstanceValue_Legacy()
        {
            var test = new ClassTestFunctions();
            test.InstanceField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetValue(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_LowAlloc()
        {
            var test = new ClassTestFunctions();
            test.InstanceField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetInstanceValueLowAlloc(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_Fast()
        {
            var test = new ClassTestFunctions();
            test.InstanceField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetClassInstanceValueFast<ClassTestFunctions, int>(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_Fast_UpCast()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldComp = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldComp");
            Measure.Method(() =>
            {
                field.GetClassInstanceValueFast<ClassTestFunctions, object>(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_Fast_UpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            test.InstanceField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetClassInstanceValueFast<ClassTestFunctions, object>(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_Fast_DownCast()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldObj = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.GetClassInstanceValueFast<ClassTestFunctions, IComparable>(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_Fast_DownCastToStruct()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldObj = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.GetClassInstanceValueFast<ClassTestFunctions, int>(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_FieldPointer()
        {
            var test = new ClassTestFunctions();
            test.InstanceField = 10;
            ClassInstanceFieldPointer<ClassTestFunctions, int> field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetValue(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_FieldPointer_UpCast()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldComp = 10;
            ClassInstanceFieldPointer<ClassTestFunctions, object> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldComp");
            Measure.Method(() =>
            {
                field.GetValue(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_FieldPointer_UpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            test.InstanceField = 10;
            ClassInstanceFieldPointer<ClassTestFunctions, object> field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetValue(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_FieldPointer_DownCast()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldObj = 10;
            ClassInstanceFieldPointer<ClassTestFunctions, IComparable> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.GetValue(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetClassInstanceValue_FieldPointer_DownCastToStruct()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldObj = 10;
            ClassInstanceFieldPointer<ClassTestFunctions, int> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.GetValue(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_Legacy()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetValue(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_LowAlloc()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetClassInstanceValueLowAlloc(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_Fast()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetClassInstanceValueFast(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_Fast_UpCast()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.SetClassInstanceValueFast(test, (IComparable)10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_Fast_UpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.SetClassInstanceValueFast(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_Fast_DownCast()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldComp");
            Measure.Method(() =>
            {
                field.SetClassInstanceValueFast(test, (object)10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_Fast_DownCastToStruct()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetClassInstanceValueFast(test, (object)10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_FieldPointer()
        {
            var test = new ClassTestFunctions();
            ClassInstanceFieldPointer<ClassTestFunctions, int> field =  typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetValue(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_FieldPointer_UpCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceFieldPointer<ClassTestFunctions, IComparable> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.SetValue(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_FieldPointer_UpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceFieldPointer<ClassTestFunctions, int> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.SetValue(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_FieldPointer_DownCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceFieldPointer<ClassTestFunctions, object> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldComp");
            Measure.Method(() =>
            {
                field.SetValue(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetClassInstanceValue_FieldPointer_DownCastToStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceFieldPointer<ClassTestFunctions, object> field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetValue(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_Legacy()
        {
            var test = new StructTestFunctions();
            test.InstanceField = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetValue(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_LowAlloc()
        {
            var test = new StructTestFunctions();
            test.InstanceField = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetInstanceValueLowAlloc(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_Fast()
        {
            var test = new StructTestFunctions();
            test.InstanceField = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetStructInstanceValueFast<StructTestFunctions, int>(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_Fast_UpCast()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldComp = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldComp");
            Measure.Method(() =>
            {
                field.GetStructInstanceValueFast<StructTestFunctions, object>(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_Fast_UpCastFromStruct()
        {
            var test = new StructTestFunctions();
            test.InstanceField = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetStructInstanceValueFast<StructTestFunctions, object>(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_Fast_DownCast()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldObj = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.GetStructInstanceValueFast<StructTestFunctions, IComparable>(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_Fast_DownCastToStruct()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldObj = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.GetStructInstanceValueFast<StructTestFunctions, int>(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_FieldPointer()
        {
            var test = new StructTestFunctions();
            test.InstanceField = 10;
            StructInstanceFieldPointer<StructTestFunctions, int> field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetValue(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_FieldPointer_UpCast()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldComp = 10;
            StructInstanceFieldPointer<StructTestFunctions, object> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldComp");
            Measure.Method(() =>
            {
                field.GetValue(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_FieldPointer_UpCastFromStruct()
        {
            var test = new StructTestFunctions();
            test.InstanceField = 10;
            StructInstanceFieldPointer<StructTestFunctions, object> field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.GetValue(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_FieldPointer_DownCast()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldObj = 10;
            StructInstanceFieldPointer<StructTestFunctions, IComparable> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.GetValue(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStructInstanceValue_FieldPointer_DownCastToStruct()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldObj = 10;
            StructInstanceFieldPointer<StructTestFunctions, int> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.GetValue(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_Legacy()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetValue(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_LowAlloc()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetInstanceValueLowAlloc(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_Fast()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetStructInstanceValueFast(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_Fast_UpCast()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.SetStructInstanceValueFast(ref test, (IComparable)10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_Fast_UpCastFromStruct()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.SetStructInstanceValueFast(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_Fast_DownCast()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldComp");
            Measure.Method(() =>
            {
                field.SetStructInstanceValueFast(ref test, (object)10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_Fast_DownCastToStruct()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetStructInstanceValueFast(ref test, (object)10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_FieldPointer()
        {
            var test = new StructTestFunctions();
            StructInstanceFieldPointer<StructTestFunctions, int> field =  typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetValue(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_FieldPointer_UpCast()
        {
            var test = new StructTestFunctions();
            StructInstanceFieldPointer<StructTestFunctions, IComparable> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.SetValue(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_FieldPointer_UpCastFromStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceFieldPointer<StructTestFunctions, int> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            Measure.Method(() =>
            {
                field.SetValue(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_FieldPointer_DownCast()
        {
            var test = new StructTestFunctions();
            StructInstanceFieldPointer<StructTestFunctions, object> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldComp");
            Measure.Method(() =>
            {
                field.SetValue(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStructInstanceValue_FieldPointer_DownCastToStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceFieldPointer<StructTestFunctions, object> field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            Measure.Method(() =>
            {
                field.SetValue(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
        [Test]
        [Performance]
        public void GetStaticValue_Legacy()
        {
            ClassTestFunctions.StaticField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.GetValue(null);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_Fast()
        {
            ClassTestFunctions.StaticField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.GetStaticValueFast<int>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_Fast_UpCast()
        {
            ClassTestFunctions.StaticFieldComp = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldComp");
            Measure.Method(() =>
            {
                field.GetStaticValueFast<object>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_Fast_UpCastFromStruct()
        {
            ClassTestFunctions.StaticField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.GetStaticValueFast<object>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_Fast_DownCast()
        {
            ClassTestFunctions.StaticFieldObj = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            Measure.Method(() =>
            {
                field.GetStaticValueFast<IComparable>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_Fast_DownCastToStruct()
        {
            ClassTestFunctions.StaticFieldObj = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            Measure.Method(() =>
            {
                field.GetStaticValueFast<int>();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_FieldPointer()
        {
            ClassTestFunctions.StaticField = 10;
            StaticFieldPointer<int> field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.GetValue();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_FieldPointer_UpCast()
        {
            ClassTestFunctions.StaticFieldComp = 10;
            StaticFieldPointer<object> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldComp");
            Measure.Method(() =>
            {
                field.GetValue();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_FieldPointer_UpCastFromStruct()
        {
            ClassTestFunctions.StaticField = 10;
            StaticFieldPointer<object> field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.GetValue();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_FieldPointer_DownCast()
        {
            ClassTestFunctions.StaticFieldObj = 10;
            StaticFieldPointer<IComparable> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            Measure.Method(() =>
            {
                field.GetValue();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void GetStaticValue_FieldPointer_DownCastToStruct()
        {
            ClassTestFunctions.StaticFieldObj = 10;
            StaticFieldPointer<int> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            Measure.Method(() =>
            {
                field.GetValue();
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_Legacy()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.SetValue(null, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_LowAlloc()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.SetStaticValueLowAlloc(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_Fast()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.SetStaticValueFast(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_Fast_UpCast()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            Measure.Method(() =>
            {
                field.SetStaticValueFast((IComparable)10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_Fast_UpCastFromStruct()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            Measure.Method(() =>
            {
                field.SetStaticValueFast(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_Fast_DownCast()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldComp");
            Measure.Method(() =>
            {
                field.SetStaticValueFast((object)10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_Fast_DownCastToStruct()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.SetStaticValueFast((object)10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_FieldPointer()
        {
            StaticFieldPointer<int> field =  typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.SetValue(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_FieldPointer_UpCast()
        {
            StaticFieldPointer<IComparable> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            Measure.Method(() =>
            {
                field.SetValue(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_FieldPointer_UpCastFromStruct()
        {
            StaticFieldPointer<int> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            Measure.Method(() =>
            {
                field.SetValue(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_FieldPointer_DownCast()
        {
            StaticFieldPointer<object> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldComp");
            Measure.Method(() =>
            {
                field.SetValue(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void SetStaticValue_FieldPointer_DownCastToStruct()
        {
            StaticFieldPointer<object> field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            Measure.Method(() =>
            {
                field.SetValue(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
    }
}
