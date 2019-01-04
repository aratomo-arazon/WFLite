using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WFLite.Converters;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class AnyVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue___without_Converter()
        {
            var testee = new AnyVariable()
            {
                Value = 10
            };

            Assert.AreEqual(10, testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_GetValue___with_Converter()
        {
            var testee = new AnyVariable()
            {
                Value = "Ten",
                Converter = new DictionaryConverter()
                {
                    Dictionary = new Dictionary<object, object>()
                    {
                        { "Ten", 10 }
                    }
                }
            };

            Assert.AreEqual(10, testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_SetValue()
        {
            var testee = new AnyVariable()
            {
                Value = 10
            };

            testee.SetValue(20);
            Assert.AreEqual(20, testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_GetValue___Generic()
        {
            var testee = new AnyVariable<int>()
            {
                Value = 10
            };

            Assert.AreEqual(10, testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_SetValue___Generic()
        {
            var testee = new AnyVariable<int>()
            {
                Value = 10
            };

            testee.SetValue(20);
            Assert.AreEqual(20, testee.GetValue());
        }
    }
}
