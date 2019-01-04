﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Conditions;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class GreaterThanConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___Greater()
        {
            var testee = new GreaterThanCondition()
            {
                Value1 = new AnyVariable<int>() { Value = 20 },
                Value2 = new AnyVariable<int>() { Value = 10 }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Equals()
        {
            var testee = new GreaterThanCondition()
            {
                Value1 = new AnyVariable<int>() { Value = 20 },
                Value2 = new AnyVariable<int>() { Value = 20 }
            };

            Assert.IsFalse(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Less()
        {
            var testee = new GreaterThanCondition()
            {
                Value1 = new AnyVariable<int>() { Value = 10 },
                Value2 = new AnyVariable<int>() { Value = 20 }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
