using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Conditions;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class IfActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Then_Completed()
        {
            var to = new AnyVariable<int>() { Value = 0 };

            var testee = new IfActivity()
            {
                Condition = new TrueCondition(),
                Then = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 1 } },
                Else = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 2 } }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(1, to.GetValueAsObject());
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Then_Suspended()
        {
            var testee = new IfActivity()
            {
                Condition = new TrueCondition(),
                Then = new SuspendActivity()
                {
                    Until = new FalseCondition()
                },
                Else = new NullActivity()
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Suspended, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Else_Completed()
        {
            var to = new AnyVariable<int>() { Value = 0 };

            var testee = new IfActivity()
            {
                Condition = new FalseCondition(),
                Then = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 1 } },
                Else = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 2 } }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(2, to.GetValueAsObject());
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Else_Suspended()
        {
            var testee = new IfActivity()
            {
                Condition = new FalseCondition(),
                Then = new NullActivity(),
                Else = new SuspendActivity()
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

            var testee = new IfActivity()
            {
                Condition = new TrueCondition(),
                Then = new SuspendActivity()
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

            var testee = new IfActivity()
            {
                Condition = new TrueCondition(),
                Then = new SuspendActivity()
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
            var to = new AnyVariable<int>() { Value = 0 };

            var testee = new IfActivity()
            {
                Condition = new TrueCondition(),
                Then = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 1 } },
                Else = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 2 } }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(0, to.GetValueAsObject());
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var testee = new IfActivity()
            {
                Condition = new TrueCondition(),
                Then = new DelayActivity()
                {
                    Duration = new AnyVariable<int>() { Value = 1000 }
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
            var testee = new IfActivity()
            {
                Condition = new TrueCondition(),
                Then = new SuspendActivity()
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
            var to = new AnyVariable<int>() { Value = 0 };

            var testee = new IfActivity()
            {
                Condition = new TrueCondition(),
                Then = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 1 } },
                Else = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 2 } }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(1, to.GetValueAsObject());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var to = new AnyVariable<int>() { Value = 0 };

            var testee = new IfActivity()
            {
                Condition = new TrueCondition(),
                Then = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 1 } },
                Else = new AssignActivity() { To = to, Value = new AnyVariable<int>() { Value = 2 } }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(0, to.GetValueAsObject());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}