using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFLite.Activities;
using WFLite.Conditions;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class SuspendActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Until_True()
        {
            var testee = new SuspendActivity()
            {
                Until = new TrueCondition()
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Until_False()
        {
            var testee = new SuspendActivity()
            {
                Until = new FalseCondition()
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Suspended___Until_True()
        {
            var value = new AnyVariable<bool>() { Value = false };

            var testee = new SuspendActivity()
            {
                Until = new TrueCondition() { Value = value }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);

            value.SetValue<bool>(true);

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Suspended___Until_False()
        {
            var value = new AnyVariable<bool>() { Value = false };

            var testee = new SuspendActivity()
            {
                Until = new TrueCondition() { Value = value }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var testee = new SuspendActivity()
            {
                Until = new TrueCondition()
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Suspended()
        {
            var testee = new SuspendActivity()
            {
                Until = new FalseCondition()
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var testee = new SuspendActivity()
            {
                Until = new TrueCondition()
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var testee = new SuspendActivity()
            {
                Until = new TrueCondition()
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);        }
    }
}
