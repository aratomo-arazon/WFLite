using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WFLite.Converters;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class AnyVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue___without_Converter()
        {
            var testee = new AnyVariable<int>()
            {
                Value = 10
            };

            Assert.AreEqual(10, testee.GetValueAsObject());
        }

        [TestMethod]
        public void Test___Method_SetValue()
        {
            var testee = new AnyVariable<int>()
            {
                Value = 10
            };

            testee.SetValue(20);
            Assert.AreEqual(20, testee.GetValueAsObject());
        }

        [TestMethod]
        public void Test___Method_GetValue___Generic_Class()
        {
            var testee = new AnyVariable<int>()
            {
                Value = 10
            };

            Assert.AreEqual(10, testee.GetValueAsObject());
        }

        [TestMethod]
        public void Test___Method_GetValue___Generic_Method___int_to_string()
        {
            var testee = new AnyVariable<int>()
            {
                Value = 10
            };

            Assert.AreEqual("10", testee.GetValue<string>());
        }

        [TestMethod]
        public void Test___Method_GetValue___Generic_Method___enum_to_string()
        {
            var testee = new AnyVariable<ActivityStatus>()
            {
                Value = ActivityStatus.Created
            };

            Assert.AreEqual("Created", testee.GetValue<string>());
        }

        [TestMethod]
        public void Test___Method_GetValue___Generic_Method___enum_to_int()
        {
            var testee = new AnyVariable<ActivityStatus>()
            {
                Value = ActivityStatus.Created
            };

            Assert.AreEqual(0, testee.GetValue<int>());
        }

        [TestMethod]
        public void Test___Method_SetValue___Generic_Class()
        {
            var testee = new AnyVariable<int>()
            {
                Value = 10
            };

            testee.SetValue(20);
            Assert.AreEqual(20, testee.GetValueAsObject());
        }
    }
}
