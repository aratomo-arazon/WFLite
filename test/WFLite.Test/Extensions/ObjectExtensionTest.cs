using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Extensions;

namespace WFLite.Test.Extensions
{
    [TestClass]
    public class ObjectExtensionTest
    {
        [TestMethod]
        public void Test___Method_ToVariable___object()
        {
            object testee = 10; 

            Assert.AreEqual(10, testee.ToVariable().GetValue<int>());
        }

        [TestMethod]
        public void Test___Method_ToVariable___generic()
        {
            var testee = 10;

            Assert.AreEqual(10, testee.ToVariable().GetValue());
        }
    }
}
