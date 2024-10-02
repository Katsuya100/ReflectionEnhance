using NUnit.Framework;
using System;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class FieldInfoTest
    {
        [Test]
        public void IsSerializeField()
        {
            var test = new ClassTestFunctions();
            test.InstanceField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            Assert.IsTrue(field.IsSerializeField());
        }

        [Test]
        public void GetClassInstanceValue_LowAlloc()
        {
            var test = new ClassTestFunctions();
            {
                test.InstanceField = 10;
                var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
                var value = field.GetInstanceValueLowAlloc(test);
                Assert.AreEqual(value, 10);
            }

            {
                test.InstanceFields = new int[] { 10 };
                var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFields");
                var values = field.GetInstanceValueLowAlloc(test) as int[];
                Assert.AreEqual(values[0], 10);
            }
        }

        [Test]
        public void GetClassInstanceValue_Fast()
        {
            var test = new ClassTestFunctions();
            {
                test.InstanceField = 10;
                var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
                var value = field.GetClassInstanceValueFast<ClassTestFunctions, int>(test);
                Assert.AreEqual(value, 10);
            }

            {
                test.InstanceFields = new int[] { 10 };
                var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFields");
                var values = field.GetClassInstanceValueFast<ClassTestFunctions, int[]>(test);
                Assert.AreEqual(values[0], 10);
            }
        }

        [Test]
        public void GetClassInstanceValue_Fast_UpCast()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldComp = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldComp");
            var value = field.GetClassInstanceValueFast<ClassTestFunctions, object>(test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetClassInstanceValue_Fast_UpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            test.InstanceField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            var value = field.GetClassInstanceValueFast<ClassTestFunctions, object>(test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetClassInstanceValue_Fast_DownCast()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldObj = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            var value = field.GetClassInstanceValueFast<ClassTestFunctions, IComparable>(test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetClassInstanceValue_Fast_DownCastToStruct()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldObj = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            var value = field.GetClassInstanceValueFast<ClassTestFunctions, int>(test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetClassInstanceValue_Fast_Base()
        {
            var test = new ClassTestFunctions();
            test.BaseField = 10;
            var field = typeof(BaseFunctions).GetFieldFast("BaseField");
            var value = field.GetClassInstanceValueFast<ClassTestFunctions, int>(test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetClassInstanceValue_FieldPointer()
        {
            var test = new ClassTestFunctions();
            {
                test.InstanceField = 10;
                ClassInstanceFieldPointer<ClassTestFunctions, int> field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
                var value = field.GetValue(test);
                Assert.AreEqual(value, 10);
            }

            {
                test.InstanceFields = new int[] { 10 };
                ClassInstanceFieldPointer<ClassTestFunctions, int[]> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFields");
                var values = field.GetValue(test);
                Assert.AreEqual(values[0], 10);
            }
        }

        [Test]
        public void GetClassInstanceValue_FieldPointer_UpCast()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldComp = 10;
            ClassInstanceFieldPointer<ClassTestFunctions, object> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldComp");
            var value = field.GetValue(test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetClassInstanceValue_FieldPointer_UpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            test.InstanceField = 10;
            ClassInstanceFieldPointer<ClassTestFunctions, object> field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            var value = field.GetValue(test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetClassInstanceValue_FieldPointer_DownCast()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldObj = 10;
            ClassInstanceFieldPointer<ClassTestFunctions, IComparable> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            var value = field.GetValue(test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetClassInstanceValue_FieldPointer_DownCastToStruct()
        {
            var test = new ClassTestFunctions();
            test.InstanceFieldObj = 10;
            ClassInstanceFieldPointer<ClassTestFunctions, int> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            var value = field.GetValue(test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void SetClassInstanceValue_LowAlloc()
        {
            var test = new ClassTestFunctions();
            {
                var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
                field.SetClassInstanceValueLowAlloc(test, 20);
                Assert.AreEqual(test.InstanceField, 20);
            }
            {
                var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFields");
                field.SetClassInstanceValueLowAlloc(test, new int[] { 20 });
                Assert.AreEqual(test.InstanceFields[0], 20);
            }
        }

        [Test]
        public void SetClassInstanceValue_Fast()
        {
            var test = new ClassTestFunctions();
            {
                var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
                field.SetClassInstanceValueFast(test, 20);
                Assert.AreEqual(test.InstanceField, 20);
            }
            {
                var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFields");
                field.SetClassInstanceValueFast(test, new int[] { 20 });
                Assert.AreEqual(test.InstanceFields[0], 20);
            }
        }

        [Test]
        public void SetClassInstanceValue_Fast_UpCast()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            field.SetClassInstanceValueFast(test, (IComparable)20);
            Assert.AreEqual(test.InstanceFieldObj, 20);
        }

        [Test]
        public void SetClassInstanceValue_Fast_UpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            field.SetClassInstanceValueFast(test, 20);
            Assert.AreEqual(test.InstanceFieldObj, 20);
        }

        [Test]
        public void SetClassInstanceValue_Fast_DownCast()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldComp");
            field.SetClassInstanceValueFast(test, (object)20);
            Assert.AreEqual(test.InstanceFieldComp, 20);
        }

        [Test]
        public void SetClassInstanceValue_Fast_DownCastToStruct()
        {
            var test = new ClassTestFunctions();
            var field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            field.SetClassInstanceValueFast(test, (object)20);
            Assert.AreEqual(test.InstanceField, 20);
        }

        [Test]
        public void SetClassInstanceValue_Fast_Base()
        {
            var test = new ClassTestFunctions();
            var field = typeof(BaseFunctions).GetFieldFast("BaseField");
            field.SetClassInstanceValueFast(test, 20);
            Assert.AreEqual(test.BaseField, 20);
        }

        [Test]
        public void SetClassInstanceValue_FieldPointer()
        {
            var test = new ClassTestFunctions();
            {
                ClassInstanceFieldPointer<ClassTestFunctions, int> field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
                field.SetValue(test, 20);
                Assert.AreEqual(test.InstanceField, 20);
            }
            {
                ClassInstanceFieldPointer<ClassTestFunctions, int[]> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFields");
                field.SetValue(test, new int[] { 20 });
                Assert.AreEqual(test.InstanceFields[0], 20);
            }
        }

        [Test]
        public void SetClassInstanceValue_FieldPointer_UpCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceFieldPointer<ClassTestFunctions, IComparable> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            field.SetValue(test, 20);
            Assert.AreEqual(test.InstanceFieldObj, 20);
        }

        [Test]
        public void SetClassInstanceValue_FieldPointer_UpCastFromStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceFieldPointer<ClassTestFunctions, int> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldObj");
            field.SetValue(test, 20);
            Assert.AreEqual(test.InstanceFieldObj, 20);
        }

        [Test]
        public void SetClassInstanceValue_FieldPointer_DownCast()
        {
            var test = new ClassTestFunctions();
            ClassInstanceFieldPointer<ClassTestFunctions, object> field = typeof(ClassTestFunctions).GetFieldFast("InstanceFieldComp");
            field.SetValue(test, 20);
            Assert.AreEqual(test.InstanceFieldComp, 20);
        }

        [Test]
        public void SetClassInstanceValue_FieldPointer_DownCastToStruct()
        {
            var test = new ClassTestFunctions();
            ClassInstanceFieldPointer<ClassTestFunctions, object> field = typeof(ClassTestFunctions).GetFieldFast("InstanceField");
            field.SetValue(test, 20);
            Assert.AreEqual(test.InstanceField, 20);
        }

        [Test]
        public void GetStructInstanceValue_LowAlloc()
        {
            var test = new StructTestFunctions();
            {
                test.InstanceField = 10;
                var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
                var value = (int)field.GetInstanceValueLowAlloc(test);
                Assert.AreEqual(value, 10);
            }

            {
                test.InstanceFields = new int[] { 10 };
                var field = typeof(StructTestFunctions).GetFieldFast("InstanceFields");
                var values = field.GetInstanceValueLowAlloc(test) as int[];
                Assert.AreEqual(values[0], 10);
            }
        }

        [Test]
        public void GetStructInstanceValue_Fast()
        {
            var test = new StructTestFunctions();
            {
                test.InstanceField = 10;
                var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
                var value = field.GetStructInstanceValueFast<StructTestFunctions, int>(ref test);
                Assert.AreEqual(value, 10);
            }

            {
                test.InstanceFields = new int[] { 10 };
                var field = typeof(StructTestFunctions).GetFieldFast("InstanceFields");
                var values = field.GetStructInstanceValueFast<StructTestFunctions, int[]>(ref test);
                Assert.AreEqual(values[0], 10);
            }
        }

        [Test]
        public void GetStructInstanceValue_Fast_UpCast()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldComp = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldComp");
            var value = field.GetStructInstanceValueFast<StructTestFunctions, object>(ref test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStructInstanceValue_Fast_UpCastFromStruct()
        {
            var test = new StructTestFunctions();
            test.InstanceField = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            var value = field.GetStructInstanceValueFast<StructTestFunctions, object>(ref test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStructInstanceValue_Fast_DownCast()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldObj = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            var value = field.GetStructInstanceValueFast<StructTestFunctions, IComparable>(ref test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStructInstanceValue_Fast_DownCastToStruct()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldObj = 10;
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            var value = field.GetStructInstanceValueFast<StructTestFunctions, int>(ref test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStructInstanceValue_FieldPointer()
        {
            var test = new StructTestFunctions();
            {
                test.InstanceField = 10;
                StructInstanceFieldPointer<StructTestFunctions, int> field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
                var value = field.GetValue(ref test);
                Assert.AreEqual(value, 10);
            }

            {
                test.InstanceFields = new int[] { 10 };
                StructInstanceFieldPointer<StructTestFunctions, int[]> field = typeof(StructTestFunctions).GetFieldFast("InstanceFields");
                var values = field.GetValue(ref test);
                Assert.AreEqual(values[0], 10);
            }
        }

        [Test]
        public void GetStructInstanceValue_FieldPointer_UpCast()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldComp = 10;
            StructInstanceFieldPointer<StructTestFunctions, object> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldComp");
            var value = field.GetValue(ref test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStructInstanceValue_FieldPointer_UpCastFromStruct()
        {
            var test = new StructTestFunctions();
            test.InstanceField = 10;
            StructInstanceFieldPointer<StructTestFunctions, object> field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            var value = field.GetValue(ref test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStructInstanceValue_FieldPointer_DownCast()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldObj = 10;
            StructInstanceFieldPointer<StructTestFunctions, IComparable> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            var value = field.GetValue(ref test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStructInstanceValue_FieldPointer_DownCastToStruct()
        {
            var test = new StructTestFunctions();
            test.InstanceFieldObj = 10;
            StructInstanceFieldPointer<StructTestFunctions, int> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            var value = field.GetValue(ref test);
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void SetStructInstanceValue_LowAlloc()
        {
            var test = new StructTestFunctions();
            {
                var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
                field.SetInstanceValueLowAlloc(ref test, 20);
                Assert.AreEqual(test.InstanceField, 20);
            }
            {
                var field = typeof(StructTestFunctions).GetFieldFast("InstanceFields");
                field.SetInstanceValueLowAlloc(ref test, new int[] { 20 });
                Assert.AreEqual(test.InstanceFields[0], 20);
            }
        }

        [Test]
        public void SetStructInstanceValue_Fast()
        {
            var test = new StructTestFunctions();
            {
                var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
                field.SetStructInstanceValueFast(ref test, 20);
                Assert.AreEqual(test.InstanceField, 20);
            }
            {
                var field = typeof(StructTestFunctions).GetFieldFast("InstanceFields");
                field.SetStructInstanceValueFast(ref test, new int[] { 20 });
                Assert.AreEqual(test.InstanceFields[0], 20);
            }
        }

        [Test]
        public void SetStructInstanceValue_Fast_UpCast()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            field.SetStructInstanceValueFast(ref test, (IComparable)20);
            Assert.AreEqual(test.InstanceFieldObj, 20);
        }

        [Test]
        public void SetStructInstanceValue_Fast_UpCastFromStruct()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            field.SetStructInstanceValueFast(ref test, 20);
            Assert.AreEqual(test.InstanceFieldObj, 20);
        }

        [Test]
        public void SetStructInstanceValue_Fast_DownCast()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldComp");
            field.SetStructInstanceValueFast(ref test, (object)20);
            Assert.AreEqual(test.InstanceFieldComp, 20);
        }

        [Test]
        public void SetStructInstanceValue_Fast_DownCastToStruct()
        {
            var test = new StructTestFunctions();
            var field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            field.SetStructInstanceValueFast(ref test, (object)20);
            Assert.AreEqual(test.InstanceField, 20);
        }

        [Test]
        public void SetStructInstanceValue_FieldPointer()
        {
            var test = new StructTestFunctions();
            {
                StructInstanceFieldPointer<StructTestFunctions, int> field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
                field.SetValue(ref test, 20);
                Assert.AreEqual(test.InstanceField, 20);
            }
            {
                StructInstanceFieldPointer<StructTestFunctions, int[]> field = typeof(StructTestFunctions).GetFieldFast("InstanceFields");
                field.SetValue(ref test, new int[] { 20 });
                Assert.AreEqual(test.InstanceFields[0], 20);
            }
        }

        [Test]
        public void SetStructInstanceValue_FieldPointer_UpCast()
        {
            var test = new StructTestFunctions();
            StructInstanceFieldPointer<StructTestFunctions, IComparable> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            field.SetValue(ref test, 20);
            Assert.AreEqual(test.InstanceFieldObj, 20);
        }

        [Test]
        public void SetStructInstanceValue_FieldPointer_UpCastFromStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceFieldPointer<StructTestFunctions, int> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldObj");
            field.SetValue(ref test, 20);
            Assert.AreEqual(test.InstanceFieldObj, 20);
        }

        [Test]
        public void SetStructInstanceValue_FieldPointer_DownCast()
        {
            var test = new StructTestFunctions();
            StructInstanceFieldPointer<StructTestFunctions, object> field = typeof(StructTestFunctions).GetFieldFast("InstanceFieldComp");
            field.SetValue(ref test, 20);
            Assert.AreEqual(test.InstanceFieldComp, 20);
        }

        [Test]
        public void SetStructInstanceValue_FieldPointer_DownCastToStruct()
        {
            var test = new StructTestFunctions();
            StructInstanceFieldPointer<StructTestFunctions, object> field = typeof(StructTestFunctions).GetFieldFast("InstanceField");
            field.SetValue(ref test, 20);
            Assert.AreEqual(test.InstanceField, 20);
        }

        [Test]
        public void GetStaticValue_Fast()
        {
            {
                ClassTestFunctions.StaticField = 10;
                var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
                var value = field.GetStaticValueFast<int>();
                Assert.AreEqual(value, 10);
            }

            {
                ClassTestFunctions.StaticFields = new int[] { 10 };
                var field = typeof(ClassTestFunctions).GetFieldFast("StaticFields");
                var values = field.GetStaticValueFast<int[]>();
                Assert.AreEqual(values[0], 10);
            }
        }

        [Test]
        public void GetStaticValue_Fast_UpCast()
        {
            ClassTestFunctions.StaticFieldComp = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldComp");
            var value = field.GetStaticValueFast<object>();
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStaticValue_Fast_UpCastFromStruct()
        {
            ClassTestFunctions.StaticField = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            var value = field.GetStaticValueFast<object>();
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStaticValue_Fast_DownCast()
        {
            ClassTestFunctions.StaticFieldObj = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            var value = field.GetStaticValueFast<IComparable>();
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStaticValue_Fast_DownCastToStruct()
        {
            ClassTestFunctions.StaticFieldObj = 10;
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            var value = field.GetStaticValueFast<int>();
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStaticValue_FieldPointer()
        {
            {
                ClassTestFunctions.StaticField = 10;
                StaticFieldPointer<int> field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
                var value = field.GetValue();
                Assert.AreEqual(value, 10);
            }

            {
                ClassTestFunctions.StaticFields = new int[] { 10 };
                StaticFieldPointer<int[]> field = typeof(ClassTestFunctions).GetFieldFast("StaticFields");
                var values = field.GetValue();
                Assert.AreEqual(values[0], 10);
            }
        }

        [Test]
        public void GetStaticValue_FieldPointer_UpCast()
        {
            ClassTestFunctions.StaticFieldComp = 10;
            StaticFieldPointer<object> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldComp");
            var value = field.GetValue();
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStaticValue_FieldPointer_UpCastFromStruct()
        {
            ClassTestFunctions.StaticField = 10;
            StaticFieldPointer<object> field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            var value = field.GetValue();
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStaticValue_FieldPointer_DownCast()
        {
            ClassTestFunctions.StaticFieldObj = 10;
            StaticFieldPointer<IComparable> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            var value = field.GetValue();
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void GetStaticValue_FieldPointer_DownCastToStruct()
        {
            ClassTestFunctions.StaticFieldObj = 10;
            StaticFieldPointer<int> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            var value = field.GetValue();
            Assert.AreEqual(value, 10);
        }

        [Test]
        public void SetStaticValue_LowAlloc()
        {
            {
                var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
                field.SetStaticValueLowAlloc(20);
                Assert.AreEqual(ClassTestFunctions.StaticField, 20);
            }
            {
                var field = typeof(ClassTestFunctions).GetFieldFast("StaticFields");
                field.SetStaticValueLowAlloc(new int[] { 20 });
                Assert.AreEqual(ClassTestFunctions.StaticFields[0], 20);
            }
        }

        [Test]
        public void SetStaticValue_Fast()
        {
            {
                var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
                field.SetStaticValueFast(20);
                Assert.AreEqual(ClassTestFunctions.StaticField, 20);
            }
            {
                var field = typeof(ClassTestFunctions).GetFieldFast("StaticFields");
                field.SetStaticValueFast(new int[] { 20 });
                Assert.AreEqual(ClassTestFunctions.StaticFields[0], 20);
            }
        }

        [Test]
        public void SetStaticValue_Fast_UpCast()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            field.SetStaticValueFast((IComparable)20);
            Assert.AreEqual(ClassTestFunctions.StaticFieldObj, 20);
        }

        [Test]
        public void SetStaticValue_Fast_UpCastFromStruct()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            field.SetStaticValueFast(20);
            Assert.AreEqual(ClassTestFunctions.StaticFieldObj, 20);
        }

        [Test]
        public void SetStaticValue_Fast_DownCast()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldComp");
            field.SetStaticValueFast((object)20);
            Assert.AreEqual(ClassTestFunctions.StaticFieldComp, 20);
        }

        [Test]
        public void SetStaticValue_Fast_DownCastToStruct()
        {
            var field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            field.SetStaticValueFast((object)20);
            Assert.AreEqual(ClassTestFunctions.StaticField, 20);
        }

        [Test]
        public void SetStaticValue_FieldPointer()
        {
            {
                StaticFieldPointer<int> field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
                field.SetValue(20);
                Assert.AreEqual(ClassTestFunctions.StaticField, 20);
            }
            {
                StaticFieldPointer<int[]> field = typeof(ClassTestFunctions).GetFieldFast("StaticFields");
                field.SetValue(new int[] { 20 });
                Assert.AreEqual(ClassTestFunctions.StaticFields[0], 20);
            }
        }

        [Test]
        public void SetStaticValue_FieldPointer_UpCast()
        {
            StaticFieldPointer<IComparable> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            field.SetValue(20);
            Assert.AreEqual(ClassTestFunctions.StaticFieldObj, 20);
        }

        [Test]
        public void SetStaticValue_FieldPointer_UpCastFromStruct()
        {
            StaticFieldPointer<int> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldObj");
            field.SetValue(20);
            Assert.AreEqual(ClassTestFunctions.StaticFieldObj, 20);
        }

        [Test]
        public void SetStaticValue_FieldPointer_DownCast()
        {
            StaticFieldPointer<object> field = typeof(ClassTestFunctions).GetFieldFast("StaticFieldComp");
            field.SetValue(20);
            Assert.AreEqual(ClassTestFunctions.StaticFieldComp, 20);
        }

        [Test]
        public void SetStaticValue_FieldPointer_DownCastToStruct()
        {
            StaticFieldPointer<object> field = typeof(ClassTestFunctions).GetFieldFast("StaticField");
            field.SetValue(20);
            Assert.AreEqual(ClassTestFunctions.StaticField, 20);
        }
    }
}
