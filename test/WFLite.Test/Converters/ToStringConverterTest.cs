using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WFLite.Converters;

namespace WFLite.Test.Converters
{
    [TestClass]
    public class ToStringConverterTest
    {
        [TestMethod]
        public void Test___Method_Convert()
        {
            var testee = new ToStringConverter();

            Assert.AreEqual("20", testee.Convert(20));
        }
    }
}