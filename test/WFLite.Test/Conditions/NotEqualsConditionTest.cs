using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class NotEqualsConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___True()
        {
            var testee = new NotEqualsCondition()
            {
                Value1 = new AnyVariable() { Value = 10 },
                Value2 = new AnyVariable() { Value = 20 }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False()
        {
            var testee = new NotEqualsCondition()
            {
                Value1 = new AnyVariable() { Value = 10 },
                Value2 = new AnyVariable() { Value = 10 }
            };

            Assert.IsFalse(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___True___Generic()
        {
            var testee = new NotEqualsCondition<int>()
            {
                Value1 = new AnyVariable<int>() { Value = 10 },
                Value2 = new AnyVariable<int>() { Value = 20 }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False___Generic()
        {
            var testee = new NotEqualsCondition<int>()
            {
                Value1 = new AnyVariable<int>() { Value = 10 },
                Value2 = new AnyVariable<int>() { Value = 10 }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
