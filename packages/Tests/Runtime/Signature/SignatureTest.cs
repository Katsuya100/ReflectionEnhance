using Katuusagi.ReflectionEnhance.Signature;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class SignatureTest
    {
        [Test]
        public void Assembly()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                var before = new ReflectionSignature(asm);
                ReflectionSignature after = (ReflectionSignature)before.ToString();
                Assert.AreEqual(before, after);
            }
        }

        [Test]
        public void Module()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                foreach (var module in asm.GetModulesFast())
                {
                    var before = new ReflectionSignature(module);
                    ReflectionSignature after = (ReflectionSignature)before.ToString();
                    Assert.AreEqual(before, after);
                }
            }
        }

        [Test]
        public void Type()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                foreach (var type in asm.GetTypesFast())
                {
                    var before = new ReflectionSignature(type);
                    ReflectionSignature after = (ReflectionSignature)before.ToString();
                    Assert.AreEqual(before, after);
                }
            }
        }

        [Test]
        public void Constructor()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                foreach (var type in asm.GetTypesFast())
                {
                    foreach (var ctor in type.GetConstructorsFullAccess())
                    {
                        var before = new ReflectionSignature(ctor);
                        ReflectionSignature after = (ReflectionSignature)before.ToString();
                        Assert.AreEqual(before, after);
                    }
                }
            }
        }

        [Test]
        public void Field()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                foreach (var type in asm.GetTypesFast())
                {
                    foreach (var field in type.GetFieldsFullAccess())
                    {
                        var before = new ReflectionSignature(field);
                        ReflectionSignature after = (ReflectionSignature)before.ToString();
                        Assert.AreEqual(before, after);
                    }
                }
            }
        }

        [Test]
        public void Property()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                foreach (var type in asm.GetTypesFast())
                {
                    foreach (var property in type.GetPropertiesFullAccess())
                    {
                        var before = new ReflectionSignature(property);
                        ReflectionSignature after = (ReflectionSignature)before.ToString();
                        Assert.AreEqual(before, after);
                    }
                }
            }
        }

        [Test]
        public void Method()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                foreach (var type in asm.GetTypesFast())
                {
                    foreach (var method in type.GetMethodsFullAccess())
                    {
                        var before = new ReflectionSignature(method);
                        ReflectionSignature after = (ReflectionSignature)before.ToString();
                        Assert.AreEqual(before, after);
                    }
                }
            }
        }

        [Test]
        public void Event()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                foreach (var type in asm.GetTypesFast())
                {
                    foreach (var @event in type.GetEventsFullAccess())
                    {
                        var before = new ReflectionSignature(@event);
                        ReflectionSignature after = (ReflectionSignature)before.ToString();
                        Assert.AreEqual(before, after);
                    }
                }
            }
        }

        [Test]
        public void GenericInstanceType()
        {
            foreach (var type in REReflection.GetUsingGenericInstanceTypes())
            {
                var before = new ReflectionSignature(type);
                ReflectionSignature after = (ReflectionSignature)before.ToString();
                Assert.AreEqual(before, after);
            }
        }

        [Test]
        public void GenericInstanceMethod()
        {
            foreach (var method in REReflection.GetUsingGenericInstanceMethods())
            {
                var before = new ReflectionSignature(method);
                var str = before.ToString();
                ReflectionSignature after = (ReflectionSignature)str;
                Assert.AreEqual(before, after);
            }
        }

        [Test]
        public void Array()
        {
            foreach (var type in REReflection.GetUsingArrayTypes())
            {
                var before = new ReflectionSignature(type);
                var str = before.ToString();
                ReflectionSignature after = (ReflectionSignature)str;
                Assert.AreEqual(before, after);
            }
        }

        [Test]
        public void Pointer()
        {
            foreach (var type in REReflection.GetUsingPointerTypes())
            {
                var before = new ReflectionSignature(type);
                var str = before.ToString();
                ReflectionSignature after = (ReflectionSignature)str;
                Assert.AreEqual(before, after);
            }
        }

        [Test]
        public void ByRef()
        {
            foreach (var type in REReflection.GetUsingByRefTypes())
            {
                var before = new ReflectionSignature(type);
                var str = before.ToString();
                ReflectionSignature after = (ReflectionSignature)str;
                Assert.AreEqual(before, after);
            }
        }

        [Test]
        public void GenericTypeParameter()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                foreach (var type in asm.GetTypesFast())
                {
                    if (!type.IsGenericTypeDefinition)
                    {
                        continue;
                    }

                    foreach (var genericParameter in type.GetGenericArgumentsFast())
                    {
                        var before = new ReflectionSignature(genericParameter);
                        ReflectionSignature after = (ReflectionSignature)before.ToString();
                        Assert.AreEqual(before, after);
                    }
                }
            }
        }

        [Test]
        public void GenericMethodParameter()
        {
            foreach (var asm in REReflection.GetAssembliesFast().Where(IsTarget))
            {
                foreach (var type in asm.GetTypesFast())
                {
                    foreach (var method in type.GetMethodsFullAccess())
                    {
                        if (method.IsGenericMethodDefinition)
                        {
                            continue;
                        }

                        foreach (var genericParameter in method.GetGenericArgumentsFast())
                        {
                            var before = new ReflectionSignature(genericParameter);
                            ReflectionSignature after = (ReflectionSignature)before.ToString();
                            Assert.AreEqual(before, after);
                        }
                    }
                }
            }
        }

        private static bool IsTarget(Assembly asm)
        {
            var name = asm.GetName().Name;
            if (name == "netstandard" ||
                name == "mscorlib" ||
                name == "System" ||
                name == "System.Runtime" ||
                name == "System.Core" ||
                name == "System.Private.CoreLib" ||
                name == "Assembly-CSharp" ||
                name == "Assembly-CSharp-Editor" ||
                name == "UnityEngine.CoreModule" ||
                name == "UnityEditor.CoreModule")
            {
                return true;
            }

            return false;
        }
    }
}
