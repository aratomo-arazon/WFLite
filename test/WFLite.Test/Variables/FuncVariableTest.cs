using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class FuncVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue()
        {
            var testee = new FuncVariable()
            {
                Func = () => 10
            };

            Assert.AreEqual(10, testee.GetValue<int>());
        }

        [TestMethod]
        public void Test___Method_GetValue___Generic()
        {
            var testee = new FuncVariable<string>()
            {
                Func = () => "foo"
            };

            Assert.AreEqual("foo", testee.GetValue<string>());
        }
    }
}
