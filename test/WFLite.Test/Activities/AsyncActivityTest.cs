using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class AsyncActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var testee = new AsyncActivity()
            {
                Func = async (cancellationToken) =>
                {
                    await Task.Delay(100);
                    return true;
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var testee = new AsyncActivity()
            {
                Func = async (cancellationToken) =>
                {
                    await Task.Delay(100);
                    return true;
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var testee = new AsyncActivity()
            {
                Func = async (cancellationToken) =>
                {
                    await Task.Delay(1000, cancellationToken);
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return false;
                    }
                    return true;
                }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);

            testee.Stop();

            //Assert.AreEqual(ActivityStatus.Stopping, testee.Status);

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var testee = new AsyncActivity()
            {
                Func = async (cancellationToken) =>
                {
                    await Task.Delay(100);
                    return true;
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
            var testee = new AsyncActivity()
            {
                Func = async (cancellationToken) =>
                {
                    await Task.Delay(100);
                    return true;
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}