using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Converters;

namespace WFLite.Test.Converters
{
    [TestClass]
    public class FuncConverterTest
    {
        [TestMethod]
        public void Test___Method_Convert()
        {
            var testee = new FuncConverter()
            {
                Func = (value) => value!.ToString()
            };

            Assert.AreEqual("10", testee.ConvertToObject(10));
        }

        [TestMethod]
        public void Test___Method_Convert___Generic()
        {
            var testee = new FuncConverter<string>()
            {
                Func = (value) => value!.ToString()!
            };

            Assert.AreEqual("10", testee.Convert(10));
        }

        [TestMethod]
        public void Test___Method_Convert___Generic_2()
        {
            var testee = new FuncConverter<int, string>()
            {
                Func = (value) => value!.ToString()
            };

            Assert.AreEqual("10", testee.Convert(10));
        }
    }
}
