using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Converters;
using System;

namespace WFLite.Test.Converters
{
    [TestClass]
    public class CastConverterTest
    {
        [TestMethod]
        public void Test___Method_Convert___to_bool()
        {
            var testee = new CastConverter<bool>();

            var result = testee.ConvertToObject("True");
            Assert.AreEqual(typeof(bool), result!.GetType());
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_char()
        {
            var testee = new CastConverter<char>();

            var result = testee.ConvertToObject(10);
            Assert.AreEqual(typeof(char), result!.GetType());
            Assert.AreEqual((char)10, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_byte()
        {
            var testee = new CastConverter<byte>();

            var result = testee.ConvertToObject(10);
            Assert.AreEqual(typeof(byte), result!.GetType());
            Assert.AreEqual((byte)10, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_short()
        {
            var testee = new CastConverter<short>();

            var result = testee.ConvertToObject(10);
            Assert.AreEqual(typeof(short), result!.GetType());
            Assert.AreEqual((short)10, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_ushort()
        {
            var testee = new CastConverter<ushort>();

            var result = testee.ConvertToObject(10);
            Assert.AreEqual(typeof(ushort), result!.GetType());
            Assert.AreEqual((ushort)10, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_int()
        {
            var testee = new CastConverter<int>();

            var result = testee.ConvertToObject(10.2);
            Assert.AreEqual(typeof(int), result!.GetType());
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_uint()
        {
            var testee = new CastConverter<uint>();

            var result = testee.ConvertToObject(10.2);
            Assert.AreEqual(typeof(uint), result!.GetType());
            Assert.AreEqual(10U, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_long()
        {
            var testee = new CastConverter<long>();

            var result = testee.ConvertToObject(10.2);
            Assert.AreEqual(typeof(long), result!.GetType());
            Assert.AreEqual(10L, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_ulong()
        {
            var testee = new CastConverter<ulong>();

            var result = testee.ConvertToObject(10.2);
            Assert.AreEqual(typeof(ulong), result!.GetType());
            Assert.AreEqual(10UL, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_float()
        {
            var testee = new CastConverter<float>();

            var result = testee.ConvertToObject(10.2);
            Assert.AreEqual(typeof(float), result!.GetType());
            Assert.AreEqual(10.2F, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_double()
        {
            var testee = new CastConverter<double>();

            var result = testee.ConvertToObject(10.0F);
            Assert.AreEqual(typeof(double), result!.GetType());
            Assert.AreEqual(10.0, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_decimal()
        {
            var testee = new CastConverter<decimal>();

            var result = testee.ConvertToObject(10.2);
            Assert.AreEqual(typeof(decimal), result!.GetType());
            Assert.AreEqual((decimal)10.2, result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_string()
        {
            var testee = new CastConverter<string>();

            var result = testee.ConvertToObject(10);
            Assert.AreEqual(typeof(string), result!.GetType());
            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public void Test___Method_Convert___to_DateTime()
        {
            var testee = new CastConverter<DateTime>();

            var result = testee.ConvertToObject("2019-01-01 00:00:00");
            Assert.AreEqual(typeof(DateTime), result!.GetType());
            Assert.AreEqual(DateTime.Parse("2019-01-01 00:00:00"), result);
        }
    }
}
