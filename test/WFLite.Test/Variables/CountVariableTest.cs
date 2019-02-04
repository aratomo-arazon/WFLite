using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class CountVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue()
        {
            var testee = new CountVariable()
            {
                Enumerable = new AnyVariable<IEnumerable>()
                {
                    Value = new List<object>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                }
            };

            Assert.AreEqual(3, testee.GetValueAsObject());
        }

        [TestMethod]
        public void Test___Method_GetValue___Generic()
        {
            var testee = new CountVariable<string>()
            {
                Enumerable = new AnyVariable<IEnumerable<string>>()
                {
                    Value = new List<string>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                }
            };

            Assert.AreEqual(3, testee.GetValueAsObject());
        }

    }
}
