using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class CountVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue___Collection_List()
        {
            var testee = new CountVariable()
            {
                Collection = new ListVariable()
                {
                    Value = new List<object>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                }
            };

            Assert.AreEqual(3, testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_GetValue___Collection_Dictionary()
        {
            var testee = new CountVariable()
            {
                Collection = new DictionaryVariable()
                {
                    Value = new Dictionary<string, object>()
                    {
                        { "foo", 1 },
                        { "bar", 2 },
                        { "baz", 3 }
                    }
                }
            };

            Assert.AreEqual(3, testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_SetValue()
        {
            var testee = new CountVariable();

            Assert.ThrowsException<NotSupportedException>(() => testee.SetValue(3));
        }
    }
}
