using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class FalseConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___Value_null()
        {
            var testee = new FalseCondition();

            Assert.IsFalse(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Value_False()
        {
            var testee = new FalseCondition { Value = new AnyVariable() { Value = false } };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Value_True()
        {
            var testee = new FalseCondition { Value = new AnyVariable() { Value = true } };

            Assert.IsFalse(testee.Check());
        }
    }
}
