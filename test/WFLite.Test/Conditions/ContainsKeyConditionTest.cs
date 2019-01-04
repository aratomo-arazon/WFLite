using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class ContainsKeyConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___True()
        {
            var testee = new ContainsKeyCondition()
            {
                Dictionary = new DictionaryVariable()
                {
                    Value = new Dictionary<string, object>()
                    {
                        { "foo", 1 },
                        { "bar", 2 },
                        { "baz", 3 }
                    }
                },
                Key = new AnyVariable() { Value = "bar" }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False()
        {
            var testee = new ContainsKeyCondition()
            {
                Dictionary = new DictionaryVariable()
                {
                    Value = new Dictionary<string, object>()
                    {
                        { "foo", 1 },
                        { "bar", 2 },
                        { "baz", 3 }
                    }
                },
                Key = new AnyVariable() { Value = "BAR" }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
