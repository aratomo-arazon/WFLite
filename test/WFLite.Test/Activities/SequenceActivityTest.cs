using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class SequenceActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created()
        {
            var variable1 = new AnyVariable<int>();
            var variable2 = new AnyVariable<int>();

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new AssignActivity() { To = variable1, Value = new AnyVariable<int>() { Value = 10 } },
                    new AssignActivity() { To = variable2, Value = new AnyVariable<int>() { Value = 20 } }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(10, variable1.GetValueAsObject());
            Assert.AreEqual(20, variable2.GetValueAsObject());
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var variable1 = new AnyVariable<int>();
            var variable2 = new AnyVariable<int>();

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new AssignActivity() { To = variable1, Value = new AnyVariable<int>() { Value = 10 } },
                    new AssignActivity() { To = variable2, Value = new AnyVariable<int>() { Value = 20 } }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.IsNull(variable1.GetValueAsObject());
            Assert.IsNull(variable2.GetValueAsObject());
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var duration = new AnyVariable<int>() { Value = 1000 };

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new DelayActivity() { Duration = duration },
                    new DelayActivity() { Duration = duration }
                }
            };

            var task = testee.Start();

            Assert.AreEqual(ActivityStatus.Executing, testee.Status);

            testee.Stop();

            await task;

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Reset___Status_Completed()
        {
            var variable1 = new AnyVariable<int>();
            var variable2 = new AnyVariable<int>();

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new AssignActivity() { To = variable1, Value = new AnyVariable<int>() { Value = 10 } },
                    new AssignActivity() { To = variable2, Value = new AnyVariable<int>() { Value = 20 } }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(10, variable1.GetValueAsObject());
            Assert.AreEqual(20, variable2.GetValueAsObject());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var variable1 = new AnyVariable<int>();
            var variable2 = new AnyVariable<int>();

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new AssignActivity() { To = variable1, Value = new AnyVariable<int>() { Value = 10 } },
                    new AssignActivity() { To = variable2, Value = new AnyVariable<int>() { Value = 20 } }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.IsNull(variable1.GetValueAsObject());
            Assert.IsNull(variable2.GetValueAsObject());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Issue_2()
        {
            var lastAct = string.Empty;

            var testee = new SequenceActivity()
            {
                Activities = new List<IActivity>()
                {
                    new SequenceActivity()
                    {
                        Activities = new List<IActivity>()
                        {
                            new FuncSyncActivity()
                            {
                                Func = () =>
                                {
                                    lastAct = "Act1_1";
                                    return true;
                                }
                            },
                            new FuncSyncActivity()
                            {
                                Func = () => 
                                {
                                    lastAct = "Act1_2";
                                    return false;   // stopped
                                }
                            },
                            new FuncSyncActivity()
                            {
                                Func = () => 
                                {
                                    lastAct = "Act1_3";
                                    return true;
                                }
                            }
                        }
                    },
                    new FuncSyncActivity()
                    {
                        Func = () =>
                        {
                            lastAct = "Act2_1";
                            return true;
                        }
                    }
                }
            };

            await testee.Start();

            Assert.AreEqual("Act1_2", lastAct);
        }
    }
}
