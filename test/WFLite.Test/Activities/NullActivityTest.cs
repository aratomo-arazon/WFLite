using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class NullActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var testee = new NullActivity();

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var testee = new NullActivity();

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var testee = new NullActivity();

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var testee = new NullActivity();

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}