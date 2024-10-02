using NUnit.Framework;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class PropertyInfoTest
    {
        [Test]
        public void GetAccessorsFast()
        {
            var l = typeof(ClassTestFunctions).GetPropertyFast("InstanceProperty");
            var r = typeof(ClassTestFunctions).GetProperty("InstanceProperty");
            TestUtils.AreBothContains(l.GetAccessorsFast(true), r.GetAccessors(true));
        }
        [Test]
        public void IsPublicMember()
        {
            var l = typeof(ClassTestFunctions).GetPropertyFast("InstanceProperty");
            Assert.IsTrue(l.IsPublicMember());
        }
        [Test]
        public void IsStaticMember()
        {
            {
                var l = typeof(ClassTestFunctions).GetPropertyFast("InstanceProperty");
                Assert.IsFalse(l.IsStaticMember());
            }
            {
                var l = typeof(ClassTestFunctions).GetPropertyFast("StaticProperty");
                Assert.IsTrue(l.IsStaticMember());
            }
        }
        [Test]
        public void GetIndexParameter()
        {
            {
                var l = typeof(ClassTestFunctions).GetPropertyFast("Item");
                Assert.AreNotEqual(l.GetIndexParameter("a"), null);
            }
        }
        [Test]
        public void GetIndexParameterTypes()
        {
            {
                var l = typeof(ClassTestFunctions).GetPropertyFast("Item");
                Assert.AreEqual(l.GetIndexParameterTypes()[0], typeof(int));
            }
        }
        [Test]
        public void GetIndexParameterCount()
        {
            {
                var l = typeof(ClassTestFunctions).GetPropertyFast("Item");
                Assert.AreEqual(l.GetIndexParameterCount(), 1);
            }
        }
        [Test]
        public void HasIndexParameter()
        {
            {
                var l = typeof(ClassTestFunctions).GetPropertyFast("Item");
                Assert.IsTrue(l.HasIndexParameter());
            }
        }
    }
}
