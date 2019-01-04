using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public async Task Test___Method_Start___Status_Created___Collection_List___not_Empty()
        {
            var value = new AnyVariable();
            var to = new AnyVariable();

            var testee = new ForEachActivity()
            {
                Collection = new ListVariable()
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
            Assert.AreEqual("baz", to.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Collection_List___Empty()
        {
            var value = new AnyVariable();
            var to = new AnyVariable() { Value = 0 };

            var testee = new ForEachActivity()
            {
                Collection = new ListVariable()
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
            Assert.AreEqual(0, to.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Collection_Dictionary_not_Empty()
        {
            var key = new AnyVariable();
            var value = new AnyVariable();
            var to1 = new AnyVariable();
            var to2 = new AnyVariable();

            var testee = new ForEachActivity()
            {
                Collection = new DictionaryVariable()
                {
                    Value = new Dictionary<string, object>()
                    {
                        { "foo", 1 },
                        { "bar", 2 },
                        { "baz", 3 }
                    }
                },
                Key = key,
                Value = value,
                Activity = new SequenceActivity()
                {
                    Activities = new List<IActivity>()
                    {
                        new AssignActivity()
                        {
                            To = to1,
                            Value = key
                        },
                        new AssignActivity()
                        {
                            To = to2,
                            Value = value
                        }
                    }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual("baz", to1.GetValue());
            Assert.AreEqual(3, to2.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Collection_Dictionary_Empty()
        {
            var key = new AnyVariable();
            var value = new AnyVariable();
            var to1 = new AnyVariable();
            var to2 = new AnyVariable();

            var testee = new ForEachActivity()
            {
                Collection = new DictionaryVariable()
                {
                    Value = new Dictionary<string, object>()
                },
                Key = key,
                Value = value,
                Activity = new SequenceActivity()
                {
                    Activities = new List<IActivity>()
                    {
                        new AssignActivity()
                        {
                            To = to1,
                            Value = key
                        },
                        new AssignActivity()
                        {
                            To = to2,
                            Value = value
                        }
                    }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.IsNull(to1.GetValue());
            Assert.IsNull(to2.GetValue());
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var value = new AnyVariable();
            var to = new AnyVariable();

            var testee = new ForEachActivity()
            {
                Collection = new ListVariable()
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
            Assert.IsNull(to.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var value = new AnyVariable();

            var testee = new ForEachActivity()
            {
                Collection = new ListVariable()
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
            var value = new AnyVariable();
            var to = new AnyVariable();

            var testee = new ForEachActivity()
            {
                Collection = new ListVariable()
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
            Assert.AreEqual("baz", to.GetValue());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var value = new AnyVariable();
            var to = new AnyVariable();

            var testee = new ForEachActivity()
            {
                Collection = new ListVariable()
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
            Assert.IsNull(to.GetValue());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }
    }
}