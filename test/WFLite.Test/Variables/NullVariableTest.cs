using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.IsNull(testee.GetValue());
        }

        [TestMethod]
        public void Test___Method_SetValue()
        {
            var testee = new NullVariable();

            testee.SetValue(10);
            Assert.IsNull(testee.GetValue());
        }
    }
}
