using NUnit.Framework;
using System;
using System.Reflection;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class ConstructorInfoTest
    {
        [Test]
        public void Invoke_LowAlloc()
        {
            {
                var ctor = typeof(ClassTestFunctions).GetConstructorFast();
                var result = ctor.InvokeInstanceLowAlloc() as ClassTestFunctions;
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.InstanceField, -1);
            }
            {
                var ctor = typeof(ClassTestFunctions).GetConstructorFast<int>();
                var result = (ClassTestFunctions)ctor.InvokeInstanceLowAlloc(10);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.InstanceField, 10);
            }
        }

        [Test]
        public void Invoke_Fast()
        {
            {
                var ctor = typeof(ClassTestFunctions).GetConstructorFast();
                var result = ctor.InvokeInstanceFast<ClassTestFunctions>();
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.InstanceField, -1);
            }
            {
                var ctor = typeof(ClassTestFunctions).GetConstructorFast<int>();
                var result = ctor.InvokeInstanceFast<ClassTestFunctions, int>(10);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.InstanceField, 10);
            }
        }

        [Test]
        public void Invoke_Fast_Struct()
        {
            {
                var ctor = typeof(StructTestFunctions).GetConstructorFast<int>();
                var result = ctor.InvokeInstanceFast<StructTestFunctions, int>(10);
                Assert.AreEqual(result.InstanceField, 10);
            }
        }

        [Test]
        public void Invoke_Fast_ArgUpCast()
        {
            {
                var ctor = typeof(ClassTestFunctions).GetConstructorFast<object>();
                var result = ctor.InvokeInstanceFast<ClassTestFunctions, IComparable>(10);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.InstanceField, 10);
            }
        }

        [Test]
        public void Invoke_Fast_ArgUpCastFromStruct()
        {
            {
                var ctor = typeof(ClassTestFunctions).GetConstructorFast<object>();
                var result = ctor.InvokeInstanceFast<ClassTestFunctions, int>(10);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.InstanceField, 10);
            }
        }

        [Test]
        public void Invoke_Fast_ArgDownCast()
        {
            {
                var ctor = typeof(ClassTestFunctions).GetConstructorFast<IComparable>();
                var result = ctor.InvokeInstanceFast<ClassTestFunctions, object>(10);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.InstanceField, 10);
            }
        }

        [Test]
        public void Invoke_Fast_ArgDownCastToStruct()
        {
            {
                var ctor = typeof(ClassTestFunctions).GetConstructorFast<int>();
                var result = ctor.InvokeInstanceFast<ClassTestFunctions, object>(10);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.InstanceField, 10);
            }
        }

        [Test]
        public void Invoke_Fast_ResultUpCast()
        {

            {
                var ctor = typeof(ClassTestFunctions).GetConstructorFast<int>();
                var result = ctor.InvokeInstanceFast<object, int>(10);
                Assert.AreNotEqual(result, null);
            }
        }

        [Test]
        public void Invoke_Fast_ResultUpCastFromStruct()
        {

            {
                var ctor = typeof(StructTestFunctions).GetConstructorFast<int>();
                var result = ctor.InvokeInstanceFast<object, int>(10);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(((StructTestFunctions)result).InstanceField, 10);
            }
        }
    }
}
