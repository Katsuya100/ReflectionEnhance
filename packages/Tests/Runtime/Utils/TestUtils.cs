using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class TestUtils
    {

        public static void AreBothContains<T>(IEnumerable<T> l, IEnumerable<T> r)
        {
            if (l == r)
            {
                return;
            }

            foreach (var v in l)
            {
                Assert.IsTrue(r.Contains(v), $"\"{v}\" is invalid.");
            }

            foreach (var v in r)
            {
                Assert.IsTrue(l.Contains(v), $"\"{v}\" is invalid.");
            }
        }
    }
}
