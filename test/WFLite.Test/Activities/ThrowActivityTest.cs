using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class ThrowActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var testee = new ThrowActivity();

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var testee = new ThrowActivity();

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Stopped()
        {
            var testee = new ThrowActivity();

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}