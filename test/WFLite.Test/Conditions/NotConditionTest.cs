using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Conditions;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class NotConditionTest
    {
        [TestMethod]
        public void Test___Method_Check()
        {
            var testee = new NotCondition()
            {
                Condition = new TrueCondition()
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
