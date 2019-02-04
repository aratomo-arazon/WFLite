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
        public async Task Test___Method_Start___Status_Created___Then()
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
        public async Task Test___Method_Start___Status_Created___Else()
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