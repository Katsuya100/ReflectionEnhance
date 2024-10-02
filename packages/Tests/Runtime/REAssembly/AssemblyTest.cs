using NUnit.Framework;
using UnityEngine;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class AssemblyTest
    {
        [Test]
        public void GetUsingGenericInstanceTypes()
        {
            REReflection.GetUsingGenericInstanceTypes();
        }

        [Test]
        public void GetUsingGenericInstanceMethods()
        {
            REReflection.GetUsingGenericInstanceMethods();
        }

        [Test]
        public void GetModule()
        {
            Assert.AreEqual(typeof(ClassTestFunctions).Assembly.GetModuleFast("Katuusagi.ReflectionEnhance.Tests.dll"), typeof(ClassTestFunctions).Assembly.GetModule("Katuusagi.ReflectionEnhance.Tests.dll"));
        }

        [Test]
        public void GetModules()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).Assembly.GetModulesFast(), typeof(ClassTestFunctions).Assembly.GetModules());
        }

        [Test]
        public void GetType_()
        {
            Assert.AreEqual(typeof(ClassTestFunctions).Assembly.GetTypeFast("Katuusagi.ReflectionEnhance.Tests.ClassTestFunctions"), typeof(ClassTestFunctions).Assembly.GetType("Katuusagi.ReflectionEnhance.Tests.ClassTestFunctions"));
        }

        [Test]
        public void GetTypes()
        {
            TestUtils.AreBothContains(typeof(ClassTestFunctions).Assembly.GetTypesFast(), typeof(ClassTestFunctions).Assembly.GetTypes());
        }

        [Test]
        public void IsReferenceTo()
        {
            Assert.IsTrue(typeof(ClassTestFunctions).Assembly.IsReferenceTo(typeof(GameObject).Assembly));
        }

        [Test]
        public void IsReferenceFrom()
        {
            Assert.IsTrue(typeof(GameObject).Assembly.IsReferenceFrom(typeof(ClassTestFunctions).Assembly));
        }
    }
}
