using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WFLite.Converters;

namespace WFLite.Test.Converters
{
    [TestClass]
    public class DictionaryConverterTest
    {
        [TestMethod]
        public void Test___Method_Convert()
        {
            var testee = new DictionaryConverter()
            {
                Dictionary = new Dictionary<object, object?>()
                {
                    { 1, "One" },
                    { 2, "Two" },
                    { 3, "Three" }
                },
                Default = "Many"
            };

            Assert.AreEqual("One", testee.ConvertToObject(1));
            Assert.AreEqual("Two", testee.ConvertToObject(2));
            Assert.AreEqual("Three", testee.ConvertToObject(3));
            Assert.AreEqual("Many", testee.ConvertToObject(4));
        }

        [TestMethod]
        public void Test___Method_Convert___Generic()
        {
            var testee = new DictionaryConverter<string>()
            {
                Dictionary = new Dictionary<object, string>()
                {
                    { 1, "One" },
                    { 2, "Two" },
                    { 3, "Three" }
                },
                Default = "Many"
            };

            Assert.AreEqual("One", testee.Convert(1));
            Assert.AreEqual("Two", testee.Convert(2));
            Assert.AreEqual("Three", testee.Convert(3));
            Assert.AreEqual("Many", testee.Convert(4));
        }

        [TestMethod]
        public void Test___Method_Convert___Generic_2()
        {
            var testee = new DictionaryConverter<int, string>()
            {
                Dictionary = new Dictionary<int, string>()
                {
                    { 1, "One" },
                    { 2, "Two" },
                    { 3, "Three" }
                },
                Default = "Many"
            };

            Assert.AreEqual("One", testee.Convert(1));
            Assert.AreEqual("Two", testee.Convert(2));
            Assert.AreEqual("Three", testee.Convert(3));
            Assert.AreEqual("Many", testee.Convert(4));
        }
    }
}
