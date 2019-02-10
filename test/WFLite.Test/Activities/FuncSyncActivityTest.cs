using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class FuncSyncActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var value = 0;

            var testee = new FuncSyncActivity()
            {
                Func = () =>
                {
                    value = 1;
                    return true;
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(1, value);
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var value = 0;

            var testee = new FuncSyncActivity()
            {
                Func = () =>
                {
                    value = 1;
                    return true;
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var value = 0;

            var testee = new FuncSyncActivity()
            {
                Func = () =>
                {
                    value = 1;
                    return true;
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(1, value);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var value = 0;

            var testee = new FuncSyncActivity()
            {
                Func = () =>
                {
                    value = 1;
                    return true;
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(0, value);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}