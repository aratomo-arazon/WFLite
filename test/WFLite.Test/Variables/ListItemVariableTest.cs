using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class ListItemVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue()
        {
            var testee = new ListItemVariable()
            {
                List = new ListVariable()
                {
                    Value = new List<object>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                },
                Index = new AnyVariable() { Value = 1 }
            };

            Assert.AreEqual("bar", testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_SetValue()
        {
            var testee = new ListItemVariable()
            {
                List = new ListVariable()
                {
                    Value = new List<object>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                },
                Index = new AnyVariable() { Value = 1 }
            };

            testee.SetValue("BAR");

            Assert.AreEqual("BAR", testee.GetValue());
        }
    }
}
