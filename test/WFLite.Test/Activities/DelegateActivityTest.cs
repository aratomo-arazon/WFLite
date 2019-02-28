using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Conditions;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class DelegateActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created_to_Completed()
        {
            var testee = new DelegateActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created_to_Suspended()
        {
            var testee = new DelegateActivity()
            {
                Activity = new SuspendActivity()
                {
                    Until = new FalseCondition()
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Suspended_to_Completed()
        {
            var value = new AnyVariable<bool>() { Value = false };

            var testee = new DelegateActivity()
            {
                Activity = new SuspendActivity()
                {
                    Until = new TrueCondition() { Value = value }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);

            value.SetValue<bool>(true);

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Suspended_to_Suspended()
        {
            var value = new AnyVariable<bool>() { Value = false };

            var testee = new DelegateActivity()
            {
                Activity = new SuspendActivity()
                {
                    Until = new TrueCondition() { Value = value }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var testee = new DelegateActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var testee = new DelegateActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 5000 }
                }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);
     
            Thread.Sleep(1000);

            testee.Stop();

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Suspended()
        {
            var testee = new DelegateActivity()
            {
                Activity = new SuspendActivity()
                {
                    Until = new FalseCondition()
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var testee = new DelegateActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var testee = new DelegateActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}