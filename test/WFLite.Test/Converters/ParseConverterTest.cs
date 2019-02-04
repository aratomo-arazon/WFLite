using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Converters;

namespace WFLite.Test.Converters
{
    [TestClass]
    public class ParseConverterTest
    {
        [TestMethod]
        public void Test___Method_Convert___bool()
        {
            var testee = new ParseConverter<bool>();

            Assert.AreEqual(true, testee.Convert("true"));
        }

        [TestMethod]
        public void Test___Method_Convert___char()
        {
            var testee = new ParseConverter<char>();

            Assert.AreEqual(0x20, testee.Convert(" "));
        }

        [TestMethod]
        public void Test___Method_Convert___byte()
        {
            var testee = new ParseConverter<byte>();

            Assert.AreEqual((byte)1, testee.Convert("1"));
        }

        [TestMethod]
        public void Test___Method_Convert___short()
        {
            var testee = new ParseConverter<short>();

            Assert.AreEqual((short)1, testee.Convert("1"));
        }

        [TestMethod]
        public void Test___Method_Convert___ushort()
        {
            var testee = new ParseConverter<ushort>();

            Assert.AreEqual((ushort)1, testee.Convert("1"));
        }

        [TestMethod]
        public void Test___Method_Convert___Guid()
        {
            var testee = new ParseConverter<Guid>();

            Assert.AreEqual(Guid.Empty, testee.Convert("00000000-0000-0000-0000-000000000000"));
        }

        [TestMethod]
        public void Test___Method_Convert___DateTime()
        {
            var testee = new ParseConverter<DateTime>();

            Assert.AreEqual(DateTime.MinValue, testee.Convert("0001-01-01 00:00:00"));
        }
    }
}
