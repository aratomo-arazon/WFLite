using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class SequenceActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var variable1 = new AnyVariable();
            var variable2 = new AnyVariable();

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 10 } },
                    new AssignActivity() { To = variable2, Value = new AnyVariable() { Value = 20 } }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(10, variable1.GetValue());
            Assert.AreEqual(20, variable2.GetValue());
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var variable1 = new AnyVariable();
            var variable2 = new AnyVariable();

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 10 } },
                    new AssignActivity() { To = variable2, Value = new AnyVariable() { Value = 20 } }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.IsNull(variable1.GetValue());
            Assert.IsNull(variable2.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var duration = new AnyVariable() { Value = 1000 };

            var testee = new SequenceActivity()
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
        public async Task Test___Method_Reset___Status_Completed()
        {
            var variable1 = new AnyVariable();
            var variable2 = new AnyVariable();

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 10 } },
                    new AssignActivity() { To = variable2, Value = new AnyVariable() { Value = 20 } }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(10, variable1.GetValue());
            Assert.AreEqual(20, variable2.GetValue());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var variable1 = new AnyVariable();
            var variable2 = new AnyVariable();

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 10 } },
                    new AssignActivity() { To = variable2, Value = new AnyVariable() { Value = 20 } }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.IsNull(variable1.GetValue());
            Assert.IsNull(variable2.GetValue());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}
