using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class EqualsConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___True()
        {
            var testee = new EqualsCondition()
            {
                Value1 = new AnyVariable() { Value = 10 },
                Value2 = new AnyVariable() { Value = 10 }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False()
        {
            var testee = new EqualsCondition()
            {
                Value1 = new AnyVariable() { Value = 10 },
                Value2 = new AnyVariable() { Value = 20 }
            };

            Assert.IsFalse(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___True___Generic()
        {
            var testee = new EqualsCondition<int>()
            {
                Value1 = new AnyVariable<int>() { Value = 10 },
                Value2 = new AnyVariable<int>() { Value = 10 }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False___Generic()
        {
            var testee = new EqualsCondition<int>()
            {
                Value1 = new AnyVariable<int>() { Value = 10 },
                Value2 = new AnyVariable<int>() { Value = 20 }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
