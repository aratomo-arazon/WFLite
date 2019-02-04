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
    public class WhileActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Condition_True()
        {
            var variable = new AnyVariable<bool>() { Value = true };
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new WhileActivity()
            {
                Condition = new TrueCondition() { Value = variable },
                Activity =  new DelayActivity() { Duration = duration }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);

            Thread.Sleep(3000);

            variable.SetValue(false);

            await task;

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Condition_False()
        {
            var variable = new AnyVariable<bool>() { Value = false };
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new WhileActivity()
            {
                Condition = new TrueCondition() { Value = variable },
                Activity = new DelayActivity() { Duration = duration }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var variable = new AnyVariable<bool>() { Value = true };
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new WhileActivity()
            {
                Condition = new TrueCondition() { Value = variable },
                Activity = new DelayActivity() { Duration = duration }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var variable = new AnyVariable<bool>() { Value = true };
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new WhileActivity()
            {
                Condition = new TrueCondition() { Value = variable },
                Activity = new DelayActivity() { Duration = duration }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);
      
            Thread.Sleep(3000);

            testee.Stop();

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var variable = new AnyVariable<bool>() { Value = true };
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new WhileActivity()
            {
                Condition = new TrueCondition() { Value = variable },
                Activity = new DelayActivity() { Duration = duration }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);

            Thread.Sleep(3000);

            variable.SetValue(false);

            await task;

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Stopped()
        {
            var variable = new AnyVariable<bool>() { Value = true };
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new WhileActivity()
            {
                Condition = new TrueCondition() { Value = variable },
                Activity = new DelayActivity() { Duration = duration }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);

            Thread.Sleep(3000);

            testee.Stop();

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}