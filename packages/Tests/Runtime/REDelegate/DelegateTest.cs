using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class DelegateTest
    {
        [Test]
        public void CreateDelegate()
        {
            {
                var method = typeof(int).GetMethodFast<string>("Parse");
                var del = method.CreateDelegateFast<Func<string, int>>();
                var result = del("20");
                Assert.AreEqual(result, 20);
            }
            {
                var method = typeof(int).GetMethodFast<string>("Parse");
                var del = method.CreateDelegateFast(typeof(Func<string, int>)) as Func<string, int>;
                var result = del("20");
                Assert.AreEqual(result, 20);
            }
            {
                var list = new List<int>();
                var method = typeof(List<int>).GetMethodFast<int>("Add");
                var del = method.CreateDelegateFast<Action<int>>(list);
                del(1);
                Assert.AreEqual(list[0], 1);
            }
            {
                var list = new List<int>();
                var method = typeof(List<int>).GetMethodFast<int>("Add");
                var del = method.CreateDelegateFast(typeof(Action<int>), list) as Action<int>;
                del(1);
                Assert.AreEqual(list[0], 1);
            }
            {
                var del = REDelegate.CreateDelegateFast<Func<string, int>, int>("Parse");
                var result = del("20");
                Assert.AreEqual(result, 20);
            }
            {
                var del = REDelegate.CreateDelegateFast<Func<string, int>>(typeof(int), "Parse");
                var result = del("20");
                Assert.AreEqual(result, 20);
            }
            {
                var del = REDelegate.CreateDelegateFast(typeof(Func<string, int>), typeof(int), "Parse") as Func<string, int>;
                var result = del("20");
                Assert.AreEqual(result, 20);
            }
            {
                var list = new List<int>();
                var del = REDelegate.CreateDelegateFast<Action<int>>(list, "Add");
                del(1);
                Assert.AreEqual(list[0], 1);
            }
            {
                var list = new List<int>();
                var del = REDelegate.CreateDelegateFast(typeof(Action<int>), list, "Add") as Action<int>;
                del(1);
                Assert.AreEqual(list[0], 1);
            }
            {
                var method = typeof(int).GetMethodFast<string>("Parse");
                var del = REDelegate.CreateDelegateFast<Func<string, int>>(method.GetFunctionPointer());
                var result = del("20");
                Assert.AreEqual(result, 20);
            }
            {
                var method = typeof(int).GetMethodFast<string>("Parse");
                var del = REDelegate.CreateDelegateFast(typeof(Func<string, int>), method.GetFunctionPointer()) as Func<string, int>;
                var result = del("20");
                Assert.AreEqual(result, 20);
            }
            {
                var list = new List<int>();
                var method = typeof(List<int>).GetMethodFast<int>("Add");
                var del = REDelegate.CreateDelegateFast<Action<int>>(list, method.GetFunctionPointer());
                del(1);
                Assert.AreEqual(list[0], 1);
            }
            {
                var list = new List<int>();
                var method = typeof(List<int>).GetMethodFast<int>("Add");
                var del = REDelegate.CreateDelegateFast(typeof(Action<int>), list, method.GetFunctionPointer()) as Action<int>;
                del(1);
                Assert.AreEqual(list[0], 1);
            }
        }

        [Test]
        public void CreateGenericDelegate()
        {
            {
                var method = typeof(int).GetMethodFast<string>("Parse");
                var del = method.CreateGenericDelegate() as Func<string, int>;
                var result = del("20");
                Assert.AreEqual(result, 20);
            }
        }

        [Test]
        public void CreateGenericDelegateType()
        {
            {
                var method = typeof(int).GetMethodFast<string>("Parse");
                var delType = method.CreateGenericDelegateType();
                Assert.AreEqual(delType, typeof(Func<string, int>));
            }
            {
                var method = typeof(List<>).GetMethodFast<GenericTypeParameterLike<_0>>("Add");
                var delType = method.CreateGenericDelegateType();
                Assert.AreEqual(delType, null);
            }
        }

        [Test]
        public void CreateUsingGenericDelegate()
        {
            {
                var method = typeof(int).GetMethodFast<string>("Parse");
                var del = method.CreateUsingGenericDelegate() as Func<string, int>;
                var result = del("20");
                Assert.AreEqual(result, 20);
            }

            {
                var method = typeof(IntWrapper).GetMethodFast<IntWrapper>("Abs");
                var del = method.CreateUsingGenericDelegate();
                var result = del.DynamicInvoke(new IntWrapper(-20)) as IntWrapper;
                Assert.AreEqual(result.Value, 20);
            }

            {
                var method = typeof(FloatWrapper).GetMethodFast<FloatWrapper>("Abs");
                var del = method.CreateUsingGenericDelegate();
                var result = (FloatWrapper)del.DynamicInvoke(new FloatWrapper(-20));
                Assert.AreEqual(result.Value, 20);
            }
        }

        [Test]
        public void CreateUsingGenericDelegateType()
        {
            {
                var method = typeof(int).GetMethodFast<string>("Parse");
                var delType = method.CreateUsingGenericDelegateType();
                Assert.AreEqual(delType, typeof(Func<string, int>));
            }

            {
                var method = typeof(IntWrapper).GetMethodFast<IntWrapper>("Abs");
                var delType = method.CreateUsingGenericDelegateType();
                Assert.AreEqual(delType, typeof(Func<object, object>));
            }

            {
                var method = typeof(FloatWrapper).GetMethodFast<FloatWrapper>("Abs");
                var delType = method.CreateUsingGenericDelegateType();
                Assert.AreEqual(delType, typeof(Func<object, object>));
            }
        }

        [Test]
        public void IsGenericDelegatable()
        {
            {
                var method = typeof(int).GetMethodFast<string>("Parse");
                Assert.AreEqual(method.IsGenericDelegatable(), true);
            }
            {
                var method = typeof(GameObject).MethodOf<GenericMethodParameterLike<_0>>("GetComponent", 1);
                Assert.AreEqual(method.IsGenericDelegatable(), false);
            }
            {
                var method = typeof(List<>).GetMethodFast<GenericTypeParameterLike<_0>>("Add");
                Assert.AreEqual(method.IsGenericDelegatable(), false);
            }
            {
                var method = typeof(IEnumerable).GetMethodFast("GetEnumerator");
                Assert.AreEqual(method.IsGenericDelegatable(), false);
            }
        }

        [Test]
        public void InitDelegate()
        {
            {
                Func<int> a = () => 1;
                Func<int> b = () => 2;
                a.InitDelegate(b.Target, b.Method);
                Assert.AreEqual(a(), 2);
            }
            {
                Func<int> a = () => 1;
                Func<int> b = () => 2;
                a.InitDelegate(b.Target, b.Method.GetFunctionPointer());
                Assert.AreEqual(a(), 2);
            }
        }

        [Test]
        public void CreateDelegatesByAttribute()
        {
            {
                var broadcasts = REDelegate.CreateDelegatesByAttribute<Action, BroadcastAttribute>();
                Assert.AreEqual(broadcasts.FirstOrDefault().Method.Name, "OnBroadCast");
            }
            {
                var broadcasts = REDelegate.CreateDelegatesByAttribute<Action>(typeof(BroadcastAttribute));
                Assert.AreEqual(broadcasts.FirstOrDefault().Method.Name, "OnBroadCast");
            }
            {
                var broadcasts = REDelegate.CreateDelegatesByAttribute(typeof(Action), typeof(BroadcastAttribute));
                Assert.AreEqual(broadcasts.FirstOrDefault().Method.Name, "OnBroadCast");
            }
        }
    }
}
