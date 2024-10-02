using NUnit.Framework;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class EventInfoTest
    {
        [Test]
        public void GetOtherMethods()
        {
            var l = typeof(ClassTestFunctions).GetEventFast("InstanceEvent");
            TestUtils.AreBothContains(l.GetOtherMethodsFast(true), l.GetOtherMethods(true));
            TestUtils.AreBothContains(l.GetOtherMethodsFullAccess(), l.GetOtherMethods(true));
        }
        [Test]
        public void IsPublicMember()
        {
            var l = typeof(ClassTestFunctions).GetEventFast("InstanceEvent");
            Assert.IsTrue(l.IsPublicMember());
        }
        [Test]
        public void IsStaticMember()
        {
            {
                var l = typeof(ClassTestFunctions).GetEventFast("InstanceEvent");
                Assert.IsFalse(l.IsStaticMember());
            }
            {
                var l = typeof(ClassTestFunctions).GetEventFast("StaticEvent");
                Assert.IsTrue(l.IsStaticMember());
            }
        }
    }
}
