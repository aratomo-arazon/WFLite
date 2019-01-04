using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class ListVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue()
        {
            var testee = new ListVariable()
            {
                Value = new List<object>()
                {
                    "foo",
                    "bar",
                    "baz"
                }
            };

            var value = testee.GetValue() as IList<object>;
            Assert.AreEqual("foo", value[0]);
            Assert.AreEqual("bar", value[1]);
            Assert.AreEqual("baz", value[2]);
        }

        [TestMethod]
        public void Test___Method_SetValue()
        {
            var testee = new ListVariable()
            {
                Value = new List<object>()
                {
                    "foo",
                    "bar"
                }
            };

            testee.SetValue(new List<object>()
            {
                "foo",
                "bar",
                "baz"
            });

            var value = testee.GetValue() as IList<object>;
            Assert.AreEqual("foo", value[0]);
            Assert.AreEqual("bar", value[1]);
            Assert.AreEqual("baz", value[2]);
        }
    }
}
