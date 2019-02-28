using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Conditions;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class FuncConditionTest
    {
        [TestMethod]
        public void Test___Method_Check()
        {
            var testee = new FuncCondition()
            {
                Func = new Func<bool>(() => true)
            };

            Assert.IsTrue(testee.Check());
        }
    }
}
