using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class NotNullConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___Value_null()
        {
            var testee = new NotNullCondition()
            {
                Value = new AnyVariable() { Value = null }
            };

            Assert.IsFalse(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Value_not_null()
        {
            var testee = new NotNullCondition()
            {
                Value = new AnyVariable() { Value = 10 }
            };

            Assert.IsTrue(testee.Check());
        }
    }
}
