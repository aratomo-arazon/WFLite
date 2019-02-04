using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Activities.Diagnostics;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.Diagnostics
{
    [TestClass]
    public class StopwatchActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var elapsed = new AnyVariable<long>() { Value = 0 };

            var testee = new StopwatchActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
                },
                Elapsed = elapsed
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreNotEqual(0L, elapsed.GetValue());
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var elapsed = new AnyVariable<long>() { Value = 0 };

            var testee = new StopwatchActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
                },
                Elapsed = elapsed
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(0L, elapsed.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var elapsed = new AnyVariable<long>() { Value = 0 };

            var testee = new StopwatchActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
                },
                Elapsed = elapsed
            };

            var task = testee.Start();

            testee.Stop();

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreNotEqual(0, elapsed.GetValueAsObject());
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var elapsed = new AnyVariable<long>() { Value = 0 };

            var testee = new StopwatchActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
                },
                Elapsed = elapsed
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreNotEqual(0, elapsed.GetValueAsObject());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var elapsed = new AnyVariable<long>() { Value = 0 };

            var testee = new StopwatchActivity()
            {
                Activity = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
                },
                Elapsed = elapsed
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(0L, elapsed.GetValue());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}
