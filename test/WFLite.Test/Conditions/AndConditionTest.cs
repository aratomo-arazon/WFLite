using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WFLite.Conditions;
using WFLite.Interfaces;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class AndConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___All_True()
        {
            var testee = new AndCondition()
            {
                Conditions = new List<ICondition>()
                {
                    new TrueCondition(),
                    new TrueCondition()
                }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___True_False()
        {
            var testee = new AndCondition()
            {
                Conditions = new List<ICondition>()
                {
                    new TrueCondition(),
                    new FalseCondition()
                }
            };

            Assert.IsFalse(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___All_False()
        {
            var testee = new AndCondition()
            {
                Conditions = new List<ICondition>()
                {
                    new FalseCondition(),
                    new FalseCondition()
                }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
