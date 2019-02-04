using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class SwitchActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Cases()
        {
            var to = new AnyVariable();

            var testee = new SwitchActivity()
            {
                Value = new AnyVariable<int>() { Value = 1 },
                Cases = new Dictionary<object, IActivity>()
                {
                    { 1, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 100 } } },
                    { 2, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 1000 } } }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(100, to.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Default()
        {
            var to = new AnyVariable();

            var testee = new SwitchActivity()
            {
                Value = new AnyVariable<int>() { Value = 3 },
                Cases = new Dictionary<object, IActivity>()
                {
                    { 1, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 100 } } },
                    { 2, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 1000 } } }
                },
                Default = new AssignActivity() { To = to, Value = new AnyVariable() { Value = 10000 } }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(10000, to.GetValue());
        }

        [TestMethod]
        public void Test___Method_Stop___Status_Created()
        {
            var to = new AnyVariable();

            var testee = new SwitchActivity()
            {
                Value = new AnyVariable<int>() { Value = 1 },
                Cases = new Dictionary<object, IActivity>()
                {
                    { 1, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 100 } } },
                    { 2, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 1000 } } }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.IsNull(to.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Stop___Status_Executing()
        {
            var to = new AnyVariable();

            var testee = new SwitchActivity()
            {
                Value = new AnyVariable<int>() { Value = 1 },
                Cases = new Dictionary<object, IActivity>()
                {
                    { 1, new DelayActivity() { Duration = new AnyVariable<int>() { Value = 1000 } } },
                    { 2, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 1000 } } }
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
            var to = new AnyVariable();

            var testee = new SwitchActivity()
            {
                Value = new AnyVariable<int>() { Value = 1 },
                Cases = new Dictionary<object, IActivity>()
                {
                    { 1, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 100 } } },
                    { 2, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 1000 } } }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(100, to.GetValue());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public void Test___Method_Reset___Status_Stopped()
        {
            var to = new AnyVariable();

            var testee = new SwitchActivity()
            {
                Value = new AnyVariable<int>() { Value = 1 },
                Cases = new Dictionary<object, IActivity>()
                {
                    { 1, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 100 } } },
                    { 2, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 1000 } } }
                }
            };

            testee.Stop();

            Assert.AreEqual(ActivityStatus.Stopped, testee.Status);
            Assert.IsNull(to.GetValue());

            testee.Reset();

            Assert.AreEqual(ActivityStatus.Created, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Cases___Generic()
        {
            var to = new AnyVariable();

            var testee = new SwitchActivity<int>()
            {
                Value = new AnyVariable<int>() { Value = 1 },
                Cases = new Dictionary<int, IActivity>()
                {
                    { 1, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 100 } } },
                    { 2, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 1000 } } }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(100, to.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_Start___Status_Created___Default___Generic()
        {
            var to = new AnyVariable();

            var testee = new SwitchActivity<int>()
            {
                Value = new AnyVariable<int>() { Value = 3 },
                Cases = new Dictionary<int, IActivity>()
                {
                    { 1, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 100 } } },
                    { 2, new AssignActivity() { To = to, Value = new AnyVariable() { Value = 1000 } } }
                },
                Default = new AssignActivity() { To = to, Value = new AnyVariable() { Value = 10000 } }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(10000, to.GetValue());
        }
    }
}
