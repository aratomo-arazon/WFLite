using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class DictionaryItemVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue()
        {
            var dictionary = new DictionaryVariable()
            {
                Value = new Dictionary<string, object>()
                {
                    { "foo", 1 },
                    { "bar", 2 },
                    { "baz", 3 }
                }
            };

            var testee = new DictionaryItemVariable()
            {
                Dictionary = dictionary,
                Key = new AnyVariable<string>() { Value = "bar" }
            };

            Assert.AreEqual(2, testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_SetValue()
        {
            var dictionary = new DictionaryVariable()
            {
                Value = new Dictionary<string, object>()
                {
                    { "foo", 1 },
                    { "bar", 2 },
                    { "baz", 3 }
                }
            };

            var testee = new DictionaryItemVariable()
            {
                Dictionary = dictionary,
                Key = new AnyVariable<string>() { Value = "bar" }
            };

            testee.SetValue(10);
            Assert.AreEqual(10, testee.GetValue());
        }
    }
}
