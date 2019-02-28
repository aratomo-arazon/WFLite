using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Conditions;
using WFLite.Enums;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class ParallelActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created_to_Completed()
        {
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new ParallelActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new DelayActivity() { Duration = duration }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created_to_Suspended()
        {
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new ParallelActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new SuspendActivity()
                    {
                        Until = new FalseCondition()
                    }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Suspended_to_Completed()
        {
            var duration = new AnyVariable<int>() { Value = 1000 };
            var value = new AnyVariable<bool>() { Value = false };

            var testee = new ParallelActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new SuspendActivity()
                    {
                        Until = new TrueCondition() { Value = value }
                    }
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
            var duration = new AnyVariable<int>() { Value = 1000 };
            var value = new AnyVariable<bool>() { Value = false };

            var testee = new ParallelActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new SuspendActivity()
                    {
                        Until = new TrueCondition() { Value = value }
                    }
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
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new ParallelActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new DelayActivity() { Duration = duration }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new ParallelActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new DelayActivity() { Duration = duration }
                }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);

            testee.Stop();

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Suspended()
        {
            var duration = new AnyVariable<int>() { Value = 1000 };
            var value = new AnyVariable<bool>() { Value = false };

            var testee = new ParallelActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new SuspendActivity()
                    {
                        Until = new TrueCondition() { Value = value }
                    }
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
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new ParallelActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new DelayActivity() { Duration = duration }
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
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new ParallelActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new DelayActivity() { Duration = duration }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}