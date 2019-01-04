using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Threading;
using WFLite.Activities;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class DelayActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var testee = new DelayActivity()
            {
                Duration = new AnyVariable() { Value = 1000 }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var testee = new DelayActivity()
            {
                Duration = new AnyVariable() { Value = 1000 }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var testee = new DelayActivity()
            {
                Duration = new AnyVariable() { Value = 10000 }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);

            Thread.Sleep(1000);
        
            testee.Stop();

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var testee = new DelayActivity()
            {
                Duration = new AnyVariable() { Value = 1000 }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var testee = new DelayActivity()
            {
                Duration = new AnyVariable() { Value = 1000 }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}
