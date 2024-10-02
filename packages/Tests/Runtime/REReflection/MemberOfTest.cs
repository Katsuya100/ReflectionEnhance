using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class MemberOfTest
    {
        [Test]
        public void TypeOf()
        {
            Assert.AreEqual(REReflection.TypeOf("Katuusagi.ReflectionEnhance.Tests", "Katuusagi.ReflectionEnhance.Tests.ClassTestFunctions/InnerType"), typeof(ClassTestFunctions).GetNestedType("InnerType"));
            Assert.AreEqual(REReflection.TypeOf("Katuusagi.ReflectionEnhance.Tests", "Katuusagi.ReflectionEnhance.Tests.ClassTestFunctions").TypeOf("InnerType"), typeof(ClassTestFunctions).GetNestedType("InnerType"));
            Assert.AreEqual(typeof(ClassTestFunctions).TypeOf("InnerType"), typeof(ClassTestFunctions).GetNestedType("InnerType"));
        }

        [Test]
        public void FieldOf()
        {
            Assert.AreEqual(typeof(ClassTestFunctions).FieldOf("StaticField"), typeof(ClassTestFunctions).GetField("StaticField"));
        }

        [Test]
        public void MethodOf()
        {
            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf<int, int>("StaticMethod"), typeof(ClassTestFunctions).GetMethod("StaticMethod", new Type[] { typeof(int) }));
            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf("StaticMethod", typeof(int), typeof(int)), typeof(ClassTestFunctions).GetMethod("StaticMethod", new Type[] { typeof(int) }));

            Assert.AreEqual(typeof(List<int>).MethodOf<int, VoidLike>("Add"), typeof(List<int>).GetMethod("Add"));
            Assert.AreEqual(typeof(List<int>).MethodOf("Add", typeof(int), typeof(void)), typeof(List<int>).GetMethod("Add"));

            Assert.AreEqual(typeof(List<>).MethodOf<GenericTypeParameterLike<_0>, VoidLike>("Add"), typeof(List<>).GetMethod("Add"));
            Assert.AreEqual(typeof(List<>).MethodOf("Add", typeof(GenericTypeParameterLike<_0>), typeof(void)), typeof(List<>).GetMethod("Add"));

            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf<ByRefLike<int>, ByRefLike<int>>("RefStructMethod"), typeof(ClassTestFunctions).GetMethod("RefStructMethod"));
            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf("RefStructMethod", typeof(ByRefLike<int>), typeof(ByRefLike<int>)), typeof(ClassTestFunctions).GetMethod("RefStructMethod"));

            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf<PointerLike<int>, PointerLike<int>>("PointerMethod"), typeof(ClassTestFunctions).GetMethod("PointerMethod"));
            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf("PointerMethod", typeof(int*), typeof(int*)), typeof(ClassTestFunctions).GetMethod("PointerMethod"));

            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf<PointerLike<PointerLike<int>>, PointerLike<PointerLike<int>>>("DoublePointerMethod"), typeof(ClassTestFunctions).GetMethod("DoublePointerMethod"));
            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf("DoublePointerMethod", typeof(int**), typeof(int**)), typeof(ClassTestFunctions).GetMethod("DoublePointerMethod"));

            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf<PointerLike<VoidLike>, PointerLike<VoidLike>>("VoidPointerMethod"), typeof(ClassTestFunctions).GetMethod("VoidPointerMethod"));
            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf("VoidPointerMethod", typeof(void*), typeof(void*)), typeof(ClassTestFunctions).GetMethod("VoidPointerMethod"));

            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf<PointerLike<int>[], PointerLike<int>[]>("PointerArrayMethod"), typeof(ClassTestFunctions).GetMethod("PointerArrayMethod"));
            Assert.AreEqual(typeof(ClassTestFunctions).MethodOf("PointerArrayMethod", typeof(int*[]), typeof(int*[])), typeof(ClassTestFunctions).GetMethod("PointerArrayMethod"));
        }

        [Test]
        public void ConstructorOf()
        {
            Assert.AreEqual(typeof(ClassTestFunctions).ConstructorOf(), typeof(ClassTestFunctions).GetConstructor(Type.EmptyTypes));
            
            Assert.AreEqual(typeof(List<int>).ConstructorOf<int>(), typeof(List<int>).GetConstructor(new Type[] { typeof(int) }));
            Assert.AreEqual(typeof(List<int>).ConstructorOf(typeof(int)), typeof(List<int>).GetConstructor(new Type[] { typeof(int) }));

            Assert.AreEqual(typeof(List<>).ConstructorOf<int>(), typeof(List<>).GetConstructor(new Type[] { typeof(int) }));
            Assert.AreEqual(typeof(List<>).ConstructorOf(typeof(int)), typeof(List<>).GetConstructor(new Type[] { typeof(int) }));
        }
    }
}
