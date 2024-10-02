using NUnit.Framework;
using System;
using System.Linq;

namespace Katuusagi.ReflectionEnhance.Tests
{
    public class EnumTest
    {
        [Test]
        public void GetValues()
        {
            var renums = Enum.GetValues(typeof(EnumIntTest)) as EnumIntTest[];
            {
                var lenums = REEnum.GetValuesFast<EnumIntTest>();

                Assert.AreEqual(lenums[0], renums[0]);
                Assert.AreEqual(lenums[1], renums[1]);
                Assert.AreEqual(lenums[2], renums[2]);
            }
            {
                REEnum.TryGetValuesFast<EnumIntTest>(out var lenums);

                Assert.AreEqual(lenums[0], renums[0]);
                Assert.AreEqual(lenums[1], renums[1]);
                Assert.AreEqual(lenums[2], renums[2]);
            }
        }

        [Test]
        public void GetNames()
        {
            var renums = Enum.GetNames(typeof(EnumIntTest));
            {
                var lenums = REEnum.GetNamesFast<EnumIntTest>();

                Assert.AreEqual(lenums[0], renums[0]);
                Assert.AreEqual(lenums[1], renums[1]);
                Assert.AreEqual(lenums[2], renums[2]);
            }
            {
                REEnum.TryGetNamesFast<EnumIntTest>(out var lenums);

                Assert.AreEqual(lenums[0], renums[0]);
                Assert.AreEqual(lenums[1], renums[1]);
                Assert.AreEqual(lenums[2], renums[2]);
            }
        }

        [Test]
        public void GetName()
        {
            Assert.AreEqual(Enum.GetName(typeof(EnumIntTest), EnumIntTest.Hoge), REEnum.GetNameFast(EnumIntTest.Hoge));
            REEnum.TryGetNameFast(EnumIntTest.Hoge, out var name);
            Assert.AreEqual(Enum.GetName(typeof(EnumIntTest), EnumIntTest.Hoge), name);
        }

        [Test]
        public void Parse()
        {
            {
                Assert.AreEqual(Enum.Parse<EnumIntTest>("Hoge"), REEnum.ParseFast<EnumIntTest>("Hoge"));
                REEnum.TryParseFast("Hoge", out EnumIntTest e);
                Assert.AreEqual(Enum.Parse<EnumIntTest>("Hoge"), e);
            }
            {
                Assert.AreEqual(Enum.Parse<EnumIntTest>("hoge", true), REEnum.ParseFast<EnumIntTest>("hoge", true));
                REEnum.TryParseFast("hoge", true, out EnumIntTest e);
                Assert.AreEqual(Enum.Parse<EnumIntTest>("hoge", true), e);
            }
        }

        [Test]
        public void IsDefined()
        {
            Assert.AreEqual(Enum.IsDefined(typeof(EnumIntTest), EnumIntTest.Hoge), REEnum.IsDefinedFast(EnumIntTest.Hoge));
            Assert.AreEqual(Enum.IsDefined(typeof(EnumIntTest), EnumIntTest.Hoge), REEnum.IsDefinedFastWithoutConstraint(EnumIntTest.Hoge));
        }

        [Test]
        public void GetUnderlyingType()
        {
            Assert.AreEqual(Enum.GetUnderlyingType(typeof(EnumIntTest)), REEnum.GetUnderlyingTypeFast<EnumFlags>());

            REEnum.TryGetUnderlyingTypeFast<EnumFlags>(out var u);
            Assert.AreEqual(Enum.GetUnderlyingType(typeof(EnumIntTest)), u);
        }

        [Test]
        public void EnumTo()
        {
            var byteEnum = EnumByteTest.Hoge;
            var intEnum = EnumIntTest.Hoge;
            var longEnum = EnumLongTest.Hoge;

            Assert.AreEqual((byte)byteEnum, REEnum.EnumTo<EnumByteTest, byte>(byteEnum));
            Assert.AreEqual((int)intEnum, REEnum.EnumTo<EnumIntTest, int>(intEnum));
            Assert.AreEqual((long)longEnum, REEnum.EnumTo<EnumLongTest, long>(longEnum));

            REEnum.TryEnumTo<EnumByteTest, byte>(byteEnum, out var byteEnum2);
            REEnum.TryEnumTo<EnumIntTest, int>(intEnum, out var intEnum2);
            REEnum.TryEnumTo<EnumLongTest, long>(longEnum, out var longEnum2);
            Assert.AreEqual((byte)byteEnum, byteEnum2);
            Assert.AreEqual((int)intEnum, intEnum2);
            Assert.AreEqual((long)longEnum, longEnum2);
        }

        [Test]
        public void ToEnum()
        {
            byte byteValue = 100;
            int intValue = 200;
            long longValue = 300;

            Assert.AreEqual(Enum.ToObject(typeof(EnumByteTest), byteValue), REEnum.ToEnum<byte, EnumByteTest>(byteValue));
            Assert.AreEqual(Enum.ToObject(typeof(EnumIntTest), intValue), REEnum.ToEnum<int, EnumIntTest>(intValue));
            Assert.AreEqual(Enum.ToObject(typeof(EnumLongTest), longValue), REEnum.ToEnum<long, EnumLongTest>(longValue));

            REEnum.TryToEnum<byte, EnumByteTest>(byteValue, out var byteValue2);
            REEnum.TryToEnum<int, EnumIntTest>(intValue, out var intValue2);
            REEnum.TryToEnum<long, EnumLongTest>(longValue, out var longValue2);
            Assert.AreEqual(Enum.ToObject(typeof(EnumByteTest), byteValue), byteValue2);
            Assert.AreEqual(Enum.ToObject(typeof(EnumIntTest), intValue), intValue2);
            Assert.AreEqual(Enum.ToObject(typeof(EnumLongTest), longValue), longValue2);
        }

        [Test]
        public void GetUnderlyingValues()
        {
            var renums = (Enum.GetValues(typeof(EnumIntTest)) as EnumIntTest[]).Select(v => (int)v).ToArray();
            {
                var lenums = REEnum.GetUnderlyingValuesFast<EnumIntTest, int>();

                Assert.AreEqual(lenums[0], renums[0]);
                Assert.AreEqual(lenums[1], renums[1]);
                Assert.AreEqual(lenums[2], renums[2]);
            }
            {
                REEnum.TryGetUnderlyingValuesFast<EnumIntTest, int>(out var lenums);

                Assert.AreEqual(lenums[0], renums[0]);
                Assert.AreEqual(lenums[1], renums[1]);
                Assert.AreEqual(lenums[2], renums[2]);
            }

        }

        [Test]
        public void HasFlag()
        {
            var v = EnumFlags.A | EnumFlags.C | EnumFlags.D;
            Assert.AreEqual(v.HasFlagLowAlloc(EnumFlags.A), v.HasFlag(EnumFlags.A));
            Assert.AreEqual(v.HasFlagLowAlloc(EnumFlags.B), v.HasFlag(EnumFlags.B));
            Assert.AreEqual(v.HasFlagLowAlloc(EnumFlags.A | EnumFlags.C), v.HasFlag(EnumFlags.A | EnumFlags.C));
            Assert.AreEqual(v.HasFlagLowAlloc(EnumFlags.A | EnumFlags.B), v.HasFlag(EnumFlags.A | EnumFlags.B));
        }

        [Test]
        public void IsEqualsUnderlying()
        {
            Assert.AreEqual(REEnum.IsEqualsUnderlying<EnumFlags, int>(), true);
            Assert.AreEqual(REEnum.IsEqualsUnderlying<EnumFlags, byte>(), false);
            Assert.AreEqual(REEnum.IsEqualsUnderlyingWithoutConstraint<EnumFlags, int>(), true);
            Assert.AreEqual(REEnum.IsEqualsUnderlyingWithoutConstraint<EnumFlags, byte>(), false);
        }

        [Test]
        public void IsSerializable()
        {
            Assert.AreEqual(REEnum.IsSerializableEnumWithoutConstraint<EnumIntTest>(), true);
            Assert.AreEqual(REEnum.IsSerializableEnum<EnumIntTest>(), true);
            Assert.AreEqual(typeof(EnumIntTest).IsSerializableEnum(), true);
        }
    }
}
