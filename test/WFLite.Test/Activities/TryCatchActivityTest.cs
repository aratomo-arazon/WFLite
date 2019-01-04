using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;
using WFLite.Variables;


namespace WFLite.Test.Activities
{
    [TestClass]
    public class TryCatchActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var variable1 = new AnyVariable() { Value = 0 };
            var variable2 = new AnyVariable() { Value = 10 };

            var testee = new TryCatchActivity()
            {
                Try = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 20 } },
                Catch = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 30 } },
                Finally = new AssignActivity() { To = variable2, Value = variable1 }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(20, variable1.GetValue());
            Assert.AreEqual(20, variable2.GetValue());
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var variable1 = new AnyVariable() { Value = 0 };
            var variable2 = new AnyVariable() { Value = 10 };

            var testee = new TryCatchActivity()
            {
                Try = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 20 } },
                Catch = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 30 } },
                Finally = new AssignActivity() { To = variable2, Value = variable1 }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing___Try()
        {
            var variable1 = new AnyVariable() { Value = 0 };
            var variable2 = new AnyVariable() { Value = 10 };
            var duration = new AnyVariable() { Value = 1000 };

            var testee = new TryCatchActivity()
            {
                Try = new DelayActivity() { Duration = duration },
                Catch = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 30 } },
                Finally = new AssignActivity() { To = variable2, Value = variable1 }
            };

            using (var task = testee.Start())
            {
                Assert.AreEqual(ActivityStatus.Executing, testee.Status);

                testee.Stop();

                await task;
            }

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(30, variable1.GetValue());
            Assert.AreEqual(30, variable2.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing___Catch()
        {
            var variable1 = new AnyVariable() { Value = 0 };
            var variable2 = new AnyVariable() { Value = 10 };
            var duration = new AnyVariable() { Value = 1000 };

            var testee = new TryCatchActivity()
            {
                Try = new ThrowActivity(),
                Catch = new DelayActivity() { Duration = duration },
                Finally = new AssignActivity() { To = variable2, Value = variable1 }
            };

            var task = testee.Start();

            testee.Stop();

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(0, variable1.GetValue());
            Assert.AreEqual(0, variable2.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing___Finally()
        {
            var variable1 = new AnyVariable() { Value = 0 };
            var duration = new AnyVariable() { Value = 1000 };

            var testee = new TryCatchActivity()
            {
                Try = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 20 } },
                Catch = new NullActivity(),
                Finally = new DelayActivity() { Duration = duration }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);

            testee.Stop();

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.AreEqual(20, variable1.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var variable1 = new AnyVariable() { Value = 0 };
            var variable2 = new AnyVariable() { Value = 10 };

            var testee = new TryCatchActivity()
            {
                Try = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 20 } },
                Catch = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 30 } },
                Finally = new AssignActivity() { To = variable2, Value = variable1 }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(20, variable1.GetValue());
            Assert.AreEqual(20, variable2.GetValue());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var variable1 = new AnyVariable() { Value = 0 };
            var variable2 = new AnyVariable() { Value = 10 };

            var testee = new TryCatchActivity()
            {
                Try = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 20 } },
                Catch = new AssignActivity() { To = variable1, Value = new AnyVariable() { Value = 30 } },
                Finally = new AssignActivity() { To = variable2, Value = variable1 }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}
