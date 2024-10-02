using NUnit.Framework;
using System;
using System.Reflection;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class MethodBasePerformanceTest
    {
        [Test]
        [Performance]
        public void InvokeClassInstance_Legacy()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, new object[] { 10 });
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_LowAlloc()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceLowAlloc(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, int, int>(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast_ArgUpCast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, IComparable, object>(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast_ArgUpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, int, object>(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast_ArgDownCast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, object, IComparable>(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast_ArgDownCastToStruct()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, object, int>(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast_ResultUpCast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, IComparable, object>(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast_ResultUpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, int, object>(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast_ResultDownCast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, object, IComparable>(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast_ResultDownCastToStruct()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, object, int>(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Fast_Virtual()
        {
            var test = new ClassTestFunctions();
            var method = typeof(BaseFunctions).GetMethodFast("VirtualMethod");
            Measure.Method(() =>
            {
                method.InvokeClassInstanceFast<ClassTestFunctions, int>(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, int, int> method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer_ArgUpCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, IComparable, object> method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer_ArgUpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, int, object> method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer_ArgDownCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, object, IComparable> method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer_ArgDownCastToStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, object, int> method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer_ResultUpCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, IComparable, object> method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer_ResultUpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, int, object> method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer_ResultDownCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, object, IComparable> method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer_ResultDownCastToStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, object, int> method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_MethodPointer_Virtual()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, int> method = typeof(BaseFunctions).GetMethodFast("VirtualMethod");
            Measure.Method(() =>
            {
                method.Invoke(test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeClassInstance_Delegate()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            var del = method.CreateDelegateFast<Func<int, int>>(test);
            Measure.Method(() =>
            {
                del.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public unsafe void InvokeClassInstance_FunctionPointer()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            var del = (delegate* <ClassTestFunctions, int, int>)method.GetFunctionPointer();
            Measure.Method(() =>
            {
                del(test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Legacy()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, new object[] { 10 });
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_LowAlloc()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeInstanceLowAlloc(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, int, int>(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast_ArgUpCast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, IComparable, object>(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast_ArgUpCastFromStruct()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, int, object>(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast_ArgDownCast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, object, IComparable>(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast_ArgDownCastToStruct()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, object, int>(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast_ResultUpCast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, IComparable, object>(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast_ResultUpCastFromStruct()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, int, object>(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast_ResultDownCast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, object, IComparable>(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast_ResultDownCastToStruct()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, object, int>(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Fast_Virtual()
        {
            var test = new StructTestFunctions();
            var method = typeof(IBaseFunctions).GetMethodFast("VirtualMethod");
            Measure.Method(() =>
            {
                method.InvokeStructInstanceFast<StructTestFunctions, int>(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, int, int> method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer_ArgUpCast()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, IComparable, object> method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer_ArgUpCastFromStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, int, object> method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer_ArgDownCast()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, object, IComparable> method = typeof(StructTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer_ArgDownCastToStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, object, int> method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer_ResultUpCast()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, IComparable, object> method = typeof(StructTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer_ResultUpCastFromStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, int, object> method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer_ResultDownCast()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, object, IComparable> method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer_ResultDownCastToStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, object, int> method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_MethodPointer_Virtual()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, int> method = typeof(IBaseFunctions).GetMethodFast("VirtualMethod");
            Measure.Method(() =>
            {
                method.Invoke(ref test);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStructInstance_Delegate()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            var del = method.CreateDelegateFast<Func<int, int>>(test);
            Measure.Method(() =>
            {
                del.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public unsafe void InvokeStructInstance_FunctionPointer()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            var del = (delegate* <ref StructTestFunctions, int, int>)method.GetFunctionPointer();
            Measure.Method(() =>
            {
                del(ref test, 10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Legacy()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(test, new object[] { 10 });
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_LowAlloc()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticLowAlloc(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Fast()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticFast<int, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Fast_ArgUpCast()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticFast<IComparable, object>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Fast_ArgUpCastFromStruct()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticFast<int, object>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Fast_ArgDownCast()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticFast<object, IComparable>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Fast_ArgDownCastToStruct()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticFast<object, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Fast_ResultUpCast()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticFast<IComparable, object>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Fast_ResultUpCastFromStruct()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticFast<int, object>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Fast_ResultDownCast()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticFast<object, IComparable>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Fast_ResultDownCastToStruct()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            Measure.Method(() =>
            {
                method.InvokeStaticFast<object, int>(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_MethodPointer()
        {
            StaticMethodPointerFunc<int, int> method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_MethodPointer_ArgUpCast()
        {
            StaticMethodPointerFunc<IComparable, object> method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_MethodPointer_ArgUpCastFromStruct()
        {
            StaticMethodPointerFunc<int, object> method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_MethodPointer_ArgDownCast()
        {
            StaticMethodPointerFunc<object, IComparable> method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_MethodPointer_ArgDownCastToStruct()
        {
            StaticMethodPointerFunc<object, int> method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_MethodPointer_ResultUpCast()
        {
            StaticMethodPointerFunc<IComparable, object> method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_MethodPointer_ResultUpCastFromStruct()
        {
            StaticMethodPointerFunc<int, object> method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_MethodPointer_ResultDownCast()
        {
            StaticMethodPointerFunc<object, IComparable> method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_MethodPointer_ResultDownCastToStruct()
        {
            StaticMethodPointerFunc<object, int> method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            Measure.Method(() =>
            {
                method.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public void InvokeStatic_Delegate()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            var del = method.CreateDelegateFast<Func<int, int>>();
            Measure.Method(() =>
            {
                del.Invoke(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }

        [Test]
        [Performance]
        public unsafe void InvokeStatic_FunctionPointer()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            var del = (delegate* <int, int>)method.GetFunctionPointer();
            Measure.Method(() =>
            {
                del(10);
            })
            .WarmupCount(1)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(20)
            .Run();
        }
    }
}
