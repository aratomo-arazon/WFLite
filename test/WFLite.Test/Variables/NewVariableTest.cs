using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class NewVariableTest
    {
        [TestMethod]
        public void Test___Method_Start()
        {
            var testee = new NewVariable()
            {
                Func = () => Guid.NewGuid()
            };

            var value1 = testee.GetValue<Guid>();
            var value2 = testee.GetValue<Guid>();

            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        public void Test___Method_Start___Generic()
        {
            var testee = new NewVariable<Guid>()
            {
                Func = () => Guid.NewGuid()
            };

            var value1 = testee.GetValue<Guid>();
            var value2 = testee.GetValue<Guid>();

            Assert.AreNotEqual(value1, value2);
        }
    }
}
