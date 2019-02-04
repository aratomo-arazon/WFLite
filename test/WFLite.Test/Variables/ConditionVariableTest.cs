using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class ConditionVariableTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void Test___Method_GetValue___Condition_True()
        {
            var testee = new ConditionVariable()
            {
                Condition = new TrueCondition()
            };

            Assert.IsTrue(testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_GetValue___Condition_False()
        {
            var testee = new ConditionVariable()
            {
                Condition = new FalseCondition()
            };

            Assert.IsFalse(testee.GetValue());
        }
    }
}
