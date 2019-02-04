using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class TrueConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___Value_null()
        {
            var testee = new TrueCondition();

            Assert.IsTrue(testee.Check());
        }


        [TestMethod]
        public void Test___Method_Check___Value_True()
        {
            var testee = new TrueCondition { Value = new AnyVariable<bool>() { Value = true } };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Value_False()
        {
            var testee = new TrueCondition { Value = new AnyVariable<bool>() { Value = false } };

            Assert.IsFalse(testee.Check());
        }
    }
}
