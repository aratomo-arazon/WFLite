using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class NullConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___Value_null()
        {
            var testee = new NullCondition()
            {
                Value = new AnyVariable() { Value = null }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Value_not_null()
        {
            var testee = new NullCondition()
            {
                Value = new AnyVariable<int>() { Value = 10 }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
