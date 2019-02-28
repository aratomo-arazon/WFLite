using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Extensions;

namespace WFLite.Test.Extensions
{
    [TestClass]
    public class BoolExtensionTest
    {
        [TestMethod]
        public void Test___Method_ToCondition___True()
        {
            var testee = true;

            Assert.IsTrue(testee.ToCondition().Check());
        }

        [TestMethod]
        public void Test___Method_ToCondition___False()
        {
            var testee = false;

            Assert.IsFalse(testee.ToCondition().Check());
        }
    }
}
