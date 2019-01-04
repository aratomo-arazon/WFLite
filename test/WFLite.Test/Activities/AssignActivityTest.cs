using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class AssignActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var to = new AnyVariable() { Value = 0 };
            var value = new AnyVariable() { Value = 10 };

            var testee = new AssignActivity()
            {
                To = to,
                Value = value
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(10, to.GetValue());
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var to = new AnyVariable() { Value = 0 };
            var value = new AnyVariable() { Value = 10 };

            var testee = new AssignActivity()
            {
                To = to,
                Value = value
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(0, to.GetValue());
        }
         
        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var to = new AnyVariable() { Value = 0 };
            var value = new AnyVariable() { Value = 10 };

            var testee = new AssignActivity()
            {
                To = to,
                Value = value
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(10, to.GetValue());

            testee.Reset();
            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var to = new AnyVariable() { Value = 0 };
            var value = new AnyVariable() { Value = 10 };

            var testee = new AssignActivity()
            {
                To = to,
                Value = value
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(0, to.GetValue());

            testee.Reset();
            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}
