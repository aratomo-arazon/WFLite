using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class NullVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue()
        {
            var testee = new NullVariable();

            Assert.IsNull(testee.GetValueAsObject());
        }

        [TestMethod]
        public void Test___Method_GetValue___Generic()
        {
            var testee = new NullVariable<int>();

            Assert.IsNull(testee.GetValueAsObject());
        }
    }
}
