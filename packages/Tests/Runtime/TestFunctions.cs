using System;
using System.Diagnostics;
using UnityEngine.Scripting.APIUpdating;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public enum EnumByteTest : byte
    {
        Hoge = 100,
    }

    public enum EnumIntTest : int
    {
        Hoge = 200,
        Fuga,
        Piyo,
    }

    public enum EnumLongTest : long
    {
        Hoge = 300,
    }

    [Flags]
    public enum EnumFlags
    {
        A = 1 << 0,
        B = 1 << 1,
        C = 1 << 2,
        D = 1 << 3,
    }

    internal class IntWrapper
    {
        public int Value { get; private set; }
        public IntWrapper(int v)
        {
            Value = v;
        }

        public static IntWrapper Abs(IntWrapper v)
        {
            return new IntWrapper(Math.Abs(v.Value));
        }
    }

    internal struct FloatWrapper
    {
        public float Value { get; private set; }
        public FloatWrapper(float v)
        {
            Value = v;
        }

        public static FloatWrapper Abs(FloatWrapper v)
        {
            return new FloatWrapper(Math.Abs(v.Value));
        }
    }

    public interface IBaseFunctions
    {
        int VirtualMethod();
    }

    public class BaseFunctions : IBaseFunctions
    {
        public int BaseField = 0;

        public virtual int VirtualMethod()
        {
            return 0;
        }
    }

    public class GenericClassTestFunctions<T>
    {
        public static T StaticMethod(T value)
        {
            return value;
        }

        public static void GenericMethod<TArg>(T value, TArg v)
        {
        }
    }

    [MovedFrom(false, "FugaFuga", "PiyoPiyo", "HogeHoge")]
    public class ClassTestFunctions : BaseFunctions
    {
        public struct InnerType
        {
        }

        public static int[] StaticFields = null;
        public static int StaticField = 0;
        public static IComparable StaticFieldComp = null;
        public static object StaticFieldObj = null;
        public int[] InstanceFields = null;
        public int InstanceField = 10;
        public IComparable InstanceFieldComp = 10;
        public object InstanceFieldObj = 10;
        public int this[int a]
        {
            get => InstanceField;
            set => InstanceField = value;
        }
        public int InstanceProperty { get; set; }
        public static int StaticProperty { get; set; }

        public event Action InstanceEvent = () => { };
        public static event Action StaticEvent = () => { };

        public ClassTestFunctions()
        {
            InstanceField = -1;
            InstanceFieldComp = -1;
            InstanceFieldObj = -1;
        }
        public ClassTestFunctions(int field)
        {
            InstanceField = field;
            InstanceFieldComp = field;
            InstanceFieldObj = field;
        }
        public ClassTestFunctions(IComparable comparable)
        {
            if (comparable is int field)
            {
                InstanceField = field;
            }
        }
        public ClassTestFunctions(object o)
        {
            if (o is int field)
            {
                InstanceField = field;
            }
        }

        public void UniqueMethod()
        {
        }

        [Broadcast]
        public static void OnBroadCast()
        {
        }

        public static int StaticMethod(int value)
        {
            StaticEvent();
            return value;
        }

        public static object StaticMethod(object value)
        {
            StaticEvent();
            return value;
        }

        public static IComparable StaticMethod(IComparable value)
        {
            StaticEvent();
            return value;
        }

        public int InstanceMethod(int value)
        {
            InstanceEvent();
            return value;
        }

        public object InstanceMethod(object value)
        {
            InstanceEvent();
            return value;
        }

        public IComparable InstanceMethod(IComparable value)
        {
            InstanceEvent();
            return value;
        }

        public static void RefArgMethod(ref int a1, in int a2, out int a3)
        {
            a3 = a1;
            a1 = a2;
        }

        public static ref int RefStructMethod(ref int value)
        {
            value = 100;
            return ref value;
        }

        public static ref string RefClassMethod(ref string value)
        {
            value = "fuga";
            return ref value;
        }

        public static unsafe int* PointerMethod(int* value)
        {
            return value;
        }

        public static unsafe void* VoidPointerMethod(void* value)
        {
            return value;
        }

        public static unsafe int** DoublePointerMethod(int** value)
        {
            return value;
        }

        public static unsafe int*[] PointerArrayMethod(int*[] value)
        {
            return value;
        }

        public static string GenericMethod1<TArg0>(TArg0 a)
        {
            return a.ToString();
        }

        public static TReturn GenericMethod2<TArg0, TReturn>(TArg0 a)
        {
            return default;
        }

        public override int VirtualMethod()
        {
            return 1;
        }
    }

    public struct StructTestFunctions : IBaseFunctions
    {
        public IComparable SetValue;
        public static int[] StaticFields = null;
        public static int StaticField = 0;
        public static IComparable StaticFieldComp = null;
        public static object StaticFieldObj = null;
        public int[] InstanceFields;
        public int InstanceField;
        public IComparable InstanceFieldComp;
        public object InstanceFieldObj;

        public StructTestFunctions(int field)
        {
            SetValue = null;
            InstanceField = field;
            InstanceFields = null;
            InstanceFieldObj = field;
            InstanceFieldComp = field;
        }
        public StructTestFunctions(IComparable comparable)
        {
            SetValue = null;
            InstanceField = default;
            InstanceFields = null;
            InstanceFieldObj = comparable;
            InstanceFieldComp = comparable;
            if (comparable is int field)
            {
                InstanceField = field;
            }
        }
        public StructTestFunctions(object o)
        {
            SetValue = null;
            InstanceField = default;
            InstanceFields = null;
            InstanceFieldObj = o;
            InstanceFieldComp = null;
            if (o is int field)
            {
                InstanceField = field;
            }
        }

        public int InstanceMethod(int value)
        {
            return value;
        }

        public object InstanceMethod(object value)
        {
            return value;
        }

        public IComparable InstanceMethod(IComparable value)
        {
            return value;
        }

        public void Set(IComparable value)
        {
            SetValue = value;
        }

        public int VirtualMethod()
        {
            return 1;
        }
    }

    internal class BroadcastAttribute : Attribute
    {
    }
}
