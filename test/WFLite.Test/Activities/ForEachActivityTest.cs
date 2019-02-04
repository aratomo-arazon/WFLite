using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class ForEachActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created___not_Empty()
        {
            var value = new AnyVariable<string>();
            var to = new AnyVariable<string>();

            var testee = new ForEachActivity()
            {
                Enumerable = new AnyVariable<IEnumerable>()
                {
                    Value = new List<string>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                },
                Value = value,
                Activity = new AssignActivity()
                {
                    To = to,
                    Value = value
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual("baz", to.GetValueAsObject());
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Empty()
        {
            var value = new AnyVariable<object>();
            var to = new AnyVariable<int>() { Value = 0 };

            var testee = new ForEachActivity()
            {
                Enumerable = new AnyVariable<IEnumerable>()
                {
                    Value = new List<object>()
                },
                Value = value,
                Activity = new AssignActivity()
                {
                    To = to,
                    Value = value
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(0, to.GetValueAsObject());
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var value = new AnyVariable<string>();
            var to = new AnyVariable<string>();

            var testee = new ForEachActivity()
            {
                Enumerable = new AnyVariable<IEnumerable>()
                {
                    Value = new List<object>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                },
                Value = value,
                Activity = new AssignActivity()
                {
                    To = to,
                    Value = value
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.IsNull(to.GetValueAsObject());
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var value = new AnyVariable<int>();

            var testee = new ForEachActivity()
            {
                Enumerable = new AnyVariable<IEnumerable>()
                {
                    Value = new List<object>()
                    {
                        2000,
                        2000,
                        2000
                    }
                },
                Value = value,
                Activity = new DelayActivity()
                {
                    Duration = value
                }
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
            var value = new AnyVariable<string>();
            var to = new AnyVariable<string>();

            var testee = new ForEachActivity()
            {
                Enumerable = new AnyVariable<IEnumerable>()
                {
                    Value = new List<object>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                },
                Value = value,
                Activity = new AssignActivity()
                {
                    To = to,
                    Value = value
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual("baz", to.GetValueAsObject());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var value = new AnyVariable<string>();
            var to = new AnyVariable<string>();

            var testee = new ForEachActivity()
            {
                Enumerable = new AnyVariable<IEnumerable>()
                {
                    Value = new List<string>()
                    {
                        "foo",
                        "bar",
                        "baz"
                    }
                },
                Value = value,
                Activity = new AssignActivity()
                {
                    To = to,
                    Value = value
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.IsNull(to.GetValueAsObject());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}