using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public partial class TypeTest
    {
        [Test]
        public void GetTypeWithMoved()
        {
            Assert.AreEqual(REType.GetTypeWithMoved("FugaFuga.HogeHoge,PiyoPiyo"), typeof(ClassTestFunctions).Assembly.GetType("Katuusagi.ReflectionEnhance.Tests.ClassTestFunctions"));
        }

        [Test]
        public void GetMember()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).GetMemberFast("StaticField"), typeof(ClassTestFunctions).GetMember("StaticField"));
            var t = typeof(ClassTestFunctions);
            TestUtils.AreBothContains(t.GetMemberFast("StaticField"), t.GetMember("StaticField"));
        }

        [Test]
        public void GetMembers()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).GetMembersFast(), typeof(ClassTestFunctions).GetMembers());
            var t = typeof(ClassTestFunctions);
            TestUtils.AreBothContains(t.GetMembersFast(), t.GetMembers());
        }

        [Test]
        public void GetNestedType()
        {
            Assert.AreEqual(typeof(ClassTestFunctions).GetNestedTypeFast("InnerType"), typeof(ClassTestFunctions).GetNestedType("InnerType"));
            var t = typeof(ClassTestFunctions);
            Assert.AreEqual(t.GetNestedTypeFast("InnerType"), t.GetNestedType("InnerType"));
        }

        [Test]
        public void GetNestedTypes()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).GetNestedTypesFast(), typeof(ClassTestFunctions).GetNestedTypes());
            var t = typeof(ClassTestFunctions);
            TestUtils.AreBothContains(t.GetNestedTypesFast(), t.GetNestedTypes());
        }

        [Test]
        public void GetConstructor()
        {
            {
                Assert.AreEqual(typeof(List<int>).GetConstructorFast<int>(), typeof(List<int>).GetConstructor(new Type[] { typeof(int) }));
                var t = typeof(List<int>);
                Assert.AreEqual(t.GetConstructorFast<int>(), t.GetConstructor(new Type[] { typeof(int) }));
            }
            {
                Assert.AreEqual(typeof(List<>).GetConstructorFast<int>(), typeof(List<>).GetConstructor(new Type[] { typeof(int) }));
                var t = typeof(List<>);
                Assert.AreEqual(t.GetConstructorFast<int>(), t.GetConstructor(new Type[] { typeof(int) }));
            }
        }

        [Test]
        public void GetConstructors()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).GetConstructorsFast(), typeof(ClassTestFunctions).GetConstructors());
            var t = typeof(ClassTestFunctions);
            TestUtils.AreBothContains(t.GetConstructorsFast(), t.GetConstructors());
        }

        [Test]
        public void GetField()
        {
            Assert.AreEqual(typeof(ClassTestFunctions).GetFieldFast("StaticField"), typeof(ClassTestFunctions).GetField("StaticField"));
            var t = typeof(ClassTestFunctions);
            Assert.AreEqual(t.GetFieldFast("StaticField"), t.GetField("StaticField"));
        }

        [Test]
        public void GetFields()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).GetFieldsFast(), typeof(ClassTestFunctions).GetFields());
            var t = typeof(ClassTestFunctions);
            TestUtils.AreBothContains(t.GetFieldsFast(), t.GetFields());
        }

        [Test]
        public void GetProperty()
        {
            Assert.AreEqual(typeof(ClassTestFunctions).GetPropertyFast("InstanceProperty"), typeof(ClassTestFunctions).GetProperty("InstanceProperty"));
            var t = typeof(ClassTestFunctions);
            Assert.AreEqual(t.GetPropertyFast("InstanceProperty"), t.GetProperty("InstanceProperty"));
        }

        [Test]
        public void GetProperties()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).GetPropertiesFast(), typeof(ClassTestFunctions).GetProperties());
            var t = typeof(ClassTestFunctions);
            TestUtils.AreBothContains(t.GetPropertiesFast(), t.GetProperties());
        }

        [Test]
        public void GetMethod()
        {
            {
                Assert.AreEqual(typeof(ClassTestFunctions).GetMethodFast<int>("StaticMethod"), typeof(ClassTestFunctions).GetMethod("StaticMethod", new Type[] { typeof(int) }));
                Assert.AreEqual(typeof(ClassTestFunctions).GetMethodFast("StaticMethod", new Type[] { typeof(int) }), typeof(ClassTestFunctions).GetMethod("StaticMethod", new Type[] { typeof(int) }));
                Assert.AreEqual(typeof(ClassTestFunctions).GetMethodFast<ByRefLike<int>>("RefStructMethod"), typeof(ClassTestFunctions).GetMethod("RefStructMethod"));
                Assert.AreEqual(typeof(ClassTestFunctions).GetMethodFast<PointerLike<int>>("PointerMethod"), typeof(ClassTestFunctions).GetMethod("PointerMethod"));
                Assert.AreEqual(typeof(ClassTestFunctions).GetMethodFast<PointerLike<PointerLike<int>>>("DoublePointerMethod"), typeof(ClassTestFunctions).GetMethod("DoublePointerMethod"));
                Assert.AreEqual(typeof(ClassTestFunctions).GetMethodFast<PointerLike<VoidLike>>("VoidPointerMethod"), typeof(ClassTestFunctions).GetMethod("VoidPointerMethod"));
                Assert.AreEqual(typeof(ClassTestFunctions).GetMethodFast<PointerLike<int>[]>("PointerArrayMethod"), typeof(ClassTestFunctions).GetMethod("PointerArrayMethod"));

                var t = typeof(ClassTestFunctions);
                Assert.AreEqual(t.GetMethodFast<int>("StaticMethod"), t.GetMethod("StaticMethod", new Type[] { typeof(int) }));
                Assert.AreEqual(t.GetMethodFast("StaticMethod", new Type[] { typeof(int) }), t.GetMethod("StaticMethod", new Type[] { typeof(int) }));
                Assert.AreEqual(t.GetMethodFast<ByRefLike<int>>("RefStructMethod"), t.GetMethod("RefStructMethod"));
                Assert.AreEqual(t.GetMethodFast<PointerLike<int>>("PointerMethod"), t.GetMethod("PointerMethod"));
                Assert.AreEqual(t.GetMethodFast<PointerLike<PointerLike<int>>>("DoublePointerMethod"), t.GetMethod("DoublePointerMethod"));
                Assert.AreEqual(t.GetMethodFast<PointerLike<VoidLike>>("VoidPointerMethod"), t.GetMethod("VoidPointerMethod"));
                Assert.AreEqual(t.GetMethodFast<PointerLike<int>[]>("PointerArrayMethod"), t.GetMethod("PointerArrayMethod"));
            }

            {
                Assert.AreEqual(typeof(List<int>).GetMethodFast("Add"), typeof(List<int>).GetMethod("Add"));
                Assert.AreEqual(typeof(List<int>).GetMethodFast<int>("Add"), typeof(List<int>).GetMethod("Add"));

                var t = typeof(List<int>);
                Assert.AreEqual(t.GetMethodFast("Add"), t.GetMethod("Add"));
                Assert.AreEqual(t.GetMethodFast<int>("Add"), t.GetMethod("Add"));
            }
            {
                Assert.AreEqual(typeof(List<>).GetMethodFast("Add"), typeof(List<>).GetMethod("Add"));
                Assert.AreEqual(typeof(List<>).GetMethodFast<GenericTypeParameterLike<_0>>("Add"), typeof(List<>).GetMethod("Add"));

                var t = typeof(List<>);
                Assert.AreEqual(t.GetMethodFast("Add"), t.GetMethod("Add"));
                Assert.AreEqual(t.GetMethodFast<GenericTypeParameterLike<_0>>("Add"), t.GetMethod("Add"));
            }
            {
                Assert.AreEqual(typeof(GenericClassTestFunctions<int>).GetMethodFast("GenericMethod"), typeof(GenericClassTestFunctions<int>).GetMethod("GenericMethod"));
                Assert.AreEqual(typeof(GenericClassTestFunctions<int>).GetMethodFast<int, GenericMethodParameterLike<_0>>("GenericMethod"), typeof(GenericClassTestFunctions<int>).GetMethod("GenericMethod"));

                var t = typeof(GenericClassTestFunctions<int>);
                Assert.AreEqual(t.GetMethodFast("GenericMethod"), t.GetMethod("GenericMethod"));
                Assert.AreEqual(t.GetMethodFast<int, GenericMethodParameterLike<_0>>("GenericMethod"), t.GetMethod("GenericMethod"));
            }
            {
                Assert.AreEqual(typeof(GenericClassTestFunctions<>).GetMethodFast("GenericMethod"), typeof(GenericClassTestFunctions<>).GetMethod("GenericMethod"));
                Assert.AreEqual(typeof(GenericClassTestFunctions<>).GetMethodFast<GenericTypeParameterLike<_0>, GenericMethodParameterLike<_0>>("GenericMethod"), typeof(GenericClassTestFunctions<>).GetMethod("GenericMethod"));

                var t = typeof(GenericClassTestFunctions<>);
                Assert.AreEqual(t.GetMethodFast("GenericMethod"), t.GetMethod("GenericMethod"));
                Assert.AreEqual(t.GetMethodFast<GenericTypeParameterLike<_0>, GenericMethodParameterLike<_0>>("GenericMethod"), t.GetMethod("GenericMethod"));
            }
        }

        [Test]
        public void GetMethods()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).GetMethodsFast(), typeof(ClassTestFunctions).GetMethods());

            var t = typeof(ClassTestFunctions);
            TestUtils.AreBothContains(t.GetMethodsFast(), t.GetMethods());
        }

        [Test]
        public void GetEvent()
        {
            Assert.AreEqual(typeof(ClassTestFunctions).GetEventFast("StaticEvent"), typeof(ClassTestFunctions).GetEvent("StaticEvent"));

            var t = typeof(ClassTestFunctions);
            Assert.AreEqual(t.GetEventFast("StaticEvent"), t.GetEvent("StaticEvent"));
        }

        [Test]
        public void GetEvents()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).GetEventsFast(), typeof(ClassTestFunctions).GetEvents());

            var t = typeof(ClassTestFunctions);
            TestUtils.AreBothContains(t.GetEventsFast(), t.GetEvents());
        }

        [Test]
        public void CreateClassInstance()
        {
            Assert.AreNotEqual(typeof(ClassTestFunctions).CreateInstance(), null);
            Assert.AreNotEqual(REType.CreateInstance<ClassTestFunctions>(), null);

            Assert.AreNotEqual(typeof(ClassTestFunctions).CreateInstance(10), null);
            Assert.AreNotEqual(REType.CreateInstance<ClassTestFunctions, int>(10), null);
        }

        [Test]
        public void CreateStructInstance()
        {
            Assert.AreNotEqual(typeof(StructTestFunctions).CreateInstance(), null);
            Assert.AreNotEqual(REType.CreateInstance<StructTestFunctions>(), null);

            Assert.AreNotEqual(typeof(StructTestFunctions).CreateInstance(10), null);
            Assert.AreNotEqual(REType.CreateInstance<StructTestFunctions, int>(10), null);
        }
    }
}
