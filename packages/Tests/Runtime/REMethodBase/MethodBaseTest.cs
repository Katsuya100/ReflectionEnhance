using NUnit.Framework;
using System;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class MethodBaseTest
    {
        [Test]
        public void InvokeClassInstance_LowAlloc()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.InvokeClassInstanceLowAlloc(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.InvokeClassInstanceFast<ClassTestFunctions, int, int>(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast_ArgUpCast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.InvokeClassInstanceFast<ClassTestFunctions, IComparable, object>(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast_ArgUpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.InvokeClassInstanceFast<ClassTestFunctions, int, object>(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast_ArgDownCast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            var result = method.InvokeClassInstanceFast<ClassTestFunctions, object, IComparable>(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast_ArgDownCastToStruct()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.InvokeClassInstanceFast<ClassTestFunctions, object, int>(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast_ResultUpCast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            var result = method.InvokeClassInstanceFast<ClassTestFunctions, IComparable, object>(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast_ResultUpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.InvokeClassInstanceFast<ClassTestFunctions, int, object>(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast_ResultDownCast()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.InvokeClassInstanceFast<ClassTestFunctions, object, IComparable>(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast_ResultDownCastToStruct()
        {
            var test = new ClassTestFunctions();
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.InvokeClassInstanceFast<ClassTestFunctions, object, int>(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_Fast_Virtual()
        {
            var test = new ClassTestFunctions();
            {
                var method = typeof(BaseFunctions).GetMethodFast("VirtualMethod");
                var result = method.InvokeClassInstanceFast<ClassTestFunctions, int>(test);
                Assert.AreEqual(result, 1);
            }
            {
                var method = typeof(IBaseFunctions).GetMethodFast("VirtualMethod");
                var result = method.InvokeClassInstanceFast<ClassTestFunctions, int>(test);
                Assert.AreEqual(result, 1);
            }
        }

        [Test]
        public void InvokeClassInstance_MethodPointer()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, int, int> method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.Invoke(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_MethodPointer_ArgUpCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, IComparable, object> method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.Invoke(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_MethodPointer_ArgUpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, int, object> method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.Invoke(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_MethodPointer_ArgDownCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, object, IComparable> method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            var result = method.Invoke(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_MethodPointer_ArgDownCastToStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, object, int> method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.Invoke(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_MethodPointer_ResultUpCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, IComparable, object> method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            var result = method.Invoke(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_MethodPointer_ResultUpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, int, object> method = typeof(ClassTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.Invoke(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_MethodPointer_ResultDownCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, object, IComparable> method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.Invoke(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_MethodPointer_ResultDownCastToStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceMethodPointerFunc<ClassTestFunctions, object, int> method = typeof(ClassTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.Invoke(test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeClassInstance_MethodPointer_Virtual()
        {
            var test = new ClassTestFunctions();
            {
                ClassInstanceMethodPointerFunc<ClassTestFunctions, int> method = typeof(BaseFunctions).GetMethodFast("VirtualMethod");
                var result = method.Invoke(test);
                Assert.AreEqual(result, 1);
            }

            {
                ClassInstanceMethodPointerFunc<ClassTestFunctions, int> method = typeof(IBaseFunctions).GetMethodFast("VirtualMethod");
                var result = method.Invoke(test);
                Assert.AreEqual(result, 1);
            }
        }

        [Test]
        public void InvokeStructInstance_LowAlloc()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.InvokeInstanceLowAlloc(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, int, int>(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast_ArgUpCast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, IComparable, object>(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast_ArgUpCastFromStruct()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, int, object>(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast_ArgDownCast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, object, IComparable>(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast_ArgDownCastToStruct()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, object, int>(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast_ResultUpCast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, IComparable, object>(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast_ResultUpCastFromStruct()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, int, object>(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast_ResultDownCast()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, object, IComparable>(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast_ResultDownCastToStruct()
        {
            var test = new StructTestFunctions();
            var method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, object, int>(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_Fast_Virtual()
        {
            var test = new StructTestFunctions();
            var method = typeof(IBaseFunctions).GetMethodFast("VirtualMethod");
            var result = method.InvokeStructInstanceFast<StructTestFunctions, int>(ref test);
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, int, int> method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.Invoke(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer_ArgUpCast()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, IComparable, object> method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.Invoke(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer_ArgUpCastFromStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, int, object> method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.Invoke(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer_ArgDownCast()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, object, IComparable> method = typeof(StructTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            var result = method.Invoke(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer_ArgDownCastToStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, object, int> method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.Invoke(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer_ResultUpCast()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, IComparable, object> method = typeof(StructTestFunctions).GetMethodFast<IComparable>("InstanceMethod");
            var result = method.Invoke(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer_ResultUpCastFromStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, int, object> method = typeof(StructTestFunctions).GetMethodFast<int>("InstanceMethod");
            var result = method.Invoke(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer_ResultDownCast()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, object, IComparable> method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.Invoke(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer_ResultDownCastToStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, object, int> method = typeof(StructTestFunctions).GetMethodFast<object>("InstanceMethod");
            var result = method.Invoke(ref test, 10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStructInstance_MethodPointer_Virtual()
        {
            var test = new StructTestFunctions();
            StructInstanceMethodPointerFunc<StructTestFunctions, int> method = typeof(IBaseFunctions).GetMethodFast("VirtualMethod");
            var result = method.Invoke(ref test);
            Assert.AreEqual(result, 1);
        }

        [Test]
        public void InvokeStatic_LowAlloc()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            var result = method.InvokeStaticLowAlloc(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_LowAlloc_Ref()
        {
            var amethod = typeof(ClassTestFunctions).GetMethodFast<ByRefLike<int>, ByRefLike<int>, ByRefLike<int>>("RefArgMethod");
            int a1 = 100;
            int a2 = 200;
            int a3 = 300;
            amethod.InvokeStaticLowAlloc(ByRefLike.As(ref a1), ByRefLike.As(ref a2), ByRefLike.As(ref a3));
            Assert.AreEqual(a1, 200);
            Assert.AreEqual(a2, 200);
            Assert.AreEqual(a3, 100);
        }

        [Test]
        public void InvokeStatic_LowAlloc_Generic()
        {
#if ENABLE_IL2CPP
            ClassTestFunctions.GenericMethod1(5);
#endif
            var method = typeof(ClassTestFunctions).GetMethodFast<GenericMethodParameterLike<_0>>("GenericMethod1", 1);
            var result = method.InvokeStaticLowAlloc(5);
            Assert.AreEqual(result, "5");
        }

        [Test]
        public void InvokeStatic_Fast()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            var result = method.InvokeStaticFast<int, int>(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_Fast_ArgUpCast()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            var result = method.InvokeStaticFast<IComparable, object>(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_Fast_ArgUpCastFromStruct()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            var result = method.InvokeStaticFast<int, object>(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_Fast_ArgDownCast()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("StaticMethod");
            var result = method.InvokeStaticFast<object, object>(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_Fast_ArgDownCastToStruct()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            var result = method.InvokeStaticFast<object, object>(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_Fast_ResultUpCast()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("StaticMethod");
            var result = method.InvokeStaticFast<IComparable, object>(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_Fast_ResultUpCastFromStruct()
        {
            var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            var result = method.InvokeStaticFast<int, object>(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_Fast_Ref()
        {
            var amethod = typeof(ClassTestFunctions).GetMethodFast<ByRefLike<int>, ByRefLike<int>, ByRefLike<int>>("RefArgMethod");
            int a1 = 100;
            int a2 = 200;
            int a3 = 300;
            amethod.InvokeStaticFast(ByRefLike.As(ref a1), ByRefLike.As(ref a2), ByRefLike.As(ref a3));
            Assert.AreEqual(a1, 200);
            Assert.AreEqual(a2, 200);
            Assert.AreEqual(a3, 100);

            var smethod = typeof(ClassTestFunctions).GetMethodFast<ByRefLike<int>>("RefStructMethod");
            var value = 10;
            ref var value2 = ref smethod.InvokeStaticFast<ByRefLike<int>, ByRefLike<int>>(ByRefLike.As(ref value)).As();
            Assert.AreEqual(value, value2);

            var cmethod = typeof(ClassTestFunctions).GetMethodFast<ByRefLike<string>>("RefClassMethod");
            var str = "hoge";
            ref var str2 = ref cmethod.InvokeStaticFast<ByRefLike<string>, ByRefLike<string>>(ByRefLike.As(ref str)).As();
            Assert.AreEqual(str, str2);
        }

        [Test]
        public void InvokeStatic_Fast_Pointer()
        {
            var amethod = typeof(ClassTestFunctions).GetMethodFast<PointerLike<int>>("PointerMethod");
            int a = 100;
            ref int b = ref amethod.InvokeStaticFast<PointerLike<int>, PointerLike<int>>(PointerLike.As(ref a)).As();
            b = 200;
            Assert.AreEqual(a, b);
        }

        [Test]
        public void InvokeStatic_Fast_Generic()
        {
#if ENABLE_IL2CPP
            ClassTestFunctions.GenericMethod2<int, float>(5);
#endif
            var method = typeof(ClassTestFunctions).GetMethodFast<GenericMethodParameterLike<_0>>("GenericMethod2", 2);
            var result = method.InvokeStaticFast<int, float>(5);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void InvokeStatic_MethodPointer()
        {
            StaticMethodPointerFunc<int, int> method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            var result = method.Invoke(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_MethodPointer_ArgUpCast()
        {
            StaticMethodPointerFunc<IComparable, object> method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            var result = method.Invoke(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_MethodPointer_ArgUpCastFromStruct()
        {
            StaticMethodPointerFunc<int, object> method = typeof(ClassTestFunctions).GetMethodFast<object>("StaticMethod");
            var result = method.Invoke(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_MethodPointer_ArgDownCast()
        {
            StaticMethodPointerFunc<object, object> method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("StaticMethod");
            var result = method.Invoke(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_MethodPointer_ArgDownCastToStruct()
        {
            StaticMethodPointerFunc<object, object> method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            var result = method.Invoke(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_MethodPointer_ResultUpCast()
        {
            StaticMethodPointerFunc<IComparable, object> method = typeof(ClassTestFunctions).GetMethodFast<IComparable>("StaticMethod");
            var result = method.Invoke(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_MethodPointer_ResultUpCastFromStruct()
        {
            StaticMethodPointerFunc<int, object> method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
            var result = method.Invoke(10);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void InvokeStatic_MethodPointer_Ref()
        {
            StaticMethodPointerAction<ByRefLike<int>, ByRefLike<int>, ByRefLike<int>> amethod = typeof(ClassTestFunctions).GetMethodFast<ByRefLike<int>, ByRefLike<int>, ByRefLike<int>>("RefArgMethod");
            int a1 = 100;
            int a2 = 200;
            int a3 = 300;
            amethod.Invoke(ByRefLike.As(ref a1), ByRefLike.As(ref a2), ByRefLike.As(ref a3));
            Assert.AreEqual(a1, 200);
            Assert.AreEqual(a2, 200);
            Assert.AreEqual(a3, 100);

            StaticMethodPointerFunc<ByRefLike<int>, ByRefLike<int>> smethod = typeof(ClassTestFunctions).GetMethodFast<ByRefLike<int>>("RefStructMethod");
            var value = 10;
            ref var value2 = ref smethod.Invoke(ByRefLike.As(ref value)).As();
            Assert.AreEqual(value, value2);

            StaticMethodPointerFunc<ByRefLike<string>, ByRefLike<string>> cmethod = typeof(ClassTestFunctions).GetMethodFast<ByRefLike<string>>("RefClassMethod");
            var str = "hoge";
            ref var str2 = ref cmethod.Invoke(ByRefLike.As(ref str)).As();
            Assert.AreEqual(str, str2);
        }

        [Test]
        public void InvokeStatic_MethodPointer_Pointer()
        {
            StaticMethodPointerFunc<PointerLike<int>, PointerLike<int>> amethod = typeof(ClassTestFunctions).GetMethodFast<PointerLike<int>>("PointerMethod");
            int a = 100;
            ref int b = ref amethod.Invoke(PointerLike.As(ref a)).As();
            b = 200;
            Assert.AreEqual(a, b);
        }

        [Test]
        public void InvokeStatic_MethodPointer_Generic()
        {
#if ENABLE_IL2CPP
            ClassTestFunctions.GenericMethod2<int, float>(5);
#endif
            StaticMethodPointerFunc<int, float> method = typeof(ClassTestFunctions).GetMethodFast<GenericMethodParameterLike<_0>>("GenericMethod2", 2);
            var result = method.Invoke(5);
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void GetParameter()
        {
            {
                var method = typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod");
                Assert.AreNotEqual(method.GetParameter("value"), null);
            }
        }
    }
}
