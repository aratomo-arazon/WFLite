using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class ContainsConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___True()
        {
            var testee = new ContainsCondition()
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
                Value = new AnyVariable() { Value = "bar" }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False()
        {
            var testee = new ContainsCondition()
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
                Value = new AnyVariable() { Value = "BAR" }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
