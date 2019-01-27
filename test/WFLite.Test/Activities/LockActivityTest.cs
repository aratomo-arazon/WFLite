using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Activities.Diagnostics;
using WFLite.Enums;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class LockActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start()
        {
            var elapsed = new AnyVariable();
            var lockObject = new LockVariable();

            var testee = new StopwatchActivity()
            {
                Elapsed = elapsed,
                Activity = new ParallelActivity()
                {
                    Activities = new List<IActivity>()
                    {
                        new LockActivity()
                        {
                            LockObject = lockObject,
                            Activity = new DelayActivity()
                            {
                                Duration = new AnyVariable(1000)
                            }
                        },
                        new LockActivity()
                        {
                            LockObject = lockObject,
                            Activity = new DelayActivity()
                            {
                                Duration = new AnyVariable(1000)
                            }
                        }
                    }
                }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.IsTrue(2000 <= elapsed.GetValue<long>());
        }
    }
}
