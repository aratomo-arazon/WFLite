using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Conditions;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class DelegateConditionTest
    {
        [TestMethod]
        public void Test___Method_Check()
        {
            var testee = new DelegateCondition()
            {
                Condition = new TrueCondition()
            };

            Assert.IsTrue(testee.Check());
        }
    }
}
