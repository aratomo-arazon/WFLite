using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Variables;
using System.Collections.Generic;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class DictionaryVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue()
        {
            var testee = new DictionaryVariable()
            {
                Value = new Dictionary<string, object>()
                {
                    { "foo", 1 },
                    { "bar", 2 },
                    { "baz", 3 }
                }
            };

            var value = testee.GetValue();
            Assert.IsInstanceOfType(value, typeof(IDictionary<string, object>));

            var dictionary = value as IDictionary<string, object>;
            Assert.AreEqual(1, dictionary["foo"]);
            Assert.AreEqual(2, dictionary["bar"]);
            Assert.AreEqual(3, dictionary["baz"]);
        }

        [TestMethod]
        public void Test___Method_SetValue()
        {
            var testee = new DictionaryVariable()
            {
                Value = new Dictionary<string, object>()
                {
                    { "foo", 1 },
                    { "bar", 2 },
                    { "baz", 3 }
                }
            };

            testee.SetValue(new Dictionary<string, object>()
            {
                { "foo", 10 },
                { "bar", 20 },
                { "baz", 30 }
            });

            var value = testee.GetValue();
            Assert.IsInstanceOfType(value, typeof(IDictionary<string, object>));

            var dictionary = value as IDictionary<string, object>;
            Assert.AreEqual(10, dictionary["foo"]);
            Assert.AreEqual(20, dictionary["bar"]);
            Assert.AreEqual(30, dictionary["baz"]);
        }
    }
}
