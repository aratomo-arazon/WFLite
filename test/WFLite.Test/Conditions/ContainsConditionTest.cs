using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
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
                Enumerable = new AnyVariable<IEnumerable>()
                {
                    Value = new List<string>()
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
                Enumerable = new AnyVariable<IEnumerable>()
                {
                    Value = new List<string>()
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

        [TestMethod]
        public void Test___Method_Check___True___Generic()
        {
            var testee = new ContainsCondition<string>()
            {
                Enumerable = new AnyVariable<IEnumerable<string>>()
                {
                    Value = new List<string>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                },
                Value = new AnyVariable<string>() { Value = "bar" }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False___Generic()
        {
            var testee = new ContainsCondition<string>()
            {
                Enumerable = new AnyVariable<IEnumerable<string>>()
                {
                    Value = new List<string>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                },
                Value = new AnyVariable<string>() { Value = "BAR" }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
