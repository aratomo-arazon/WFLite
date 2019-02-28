using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Enums;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Test.Extensions
{
    [TestClass]
    public class ActivityStatusExtensionTest
    {
        [TestMethod]
        public void Test___Method_IsCreated()
        {
            Assert.IsTrue(ActivityStatus.Created.IsCreated());
            Assert.IsFalse(ActivityStatus.Executing.IsCreated());
            Assert.IsFalse(ActivityStatus.Suspended.IsCreated());
            Assert.IsFalse(ActivityStatus.Stopping.IsCreated());
            Assert.IsFalse(ActivityStatus.Completed.IsCreated());
            Assert.IsFalse(ActivityStatus.Stopped.IsCreated());
        }

        [TestMethod]
        public void Test___Method_IsExecuting()
        {
            Assert.IsFalse(ActivityStatus.Created.IsExecuting());
            Assert.IsTrue(ActivityStatus.Executing.IsExecuting());
            Assert.IsFalse(ActivityStatus.Suspended.IsExecuting());
            Assert.IsFalse(ActivityStatus.Stopping.IsExecuting());
            Assert.IsFalse(ActivityStatus.Completed.IsExecuting());
            Assert.IsFalse(ActivityStatus.Stopped.IsExecuting());
        }

        [TestMethod]
        public void Test___Method_IsSuspended()
        {
            Assert.IsFalse(ActivityStatus.Created.IsSuspended());
            Assert.IsFalse(ActivityStatus.Executing.IsSuspended());
            Assert.IsTrue(ActivityStatus.Suspended.IsSuspended());
            Assert.IsFalse(ActivityStatus.Stopping.IsSuspended());
            Assert.IsFalse(ActivityStatus.Completed.IsSuspended());
            Assert.IsFalse(ActivityStatus.Stopped.IsSuspended());
        }

        [TestMethod]
        public void Test___Method_IsStopping()
        {
            Assert.IsFalse(ActivityStatus.Created.IsStopping());
            Assert.IsFalse(ActivityStatus.Executing.IsStopping());
            Assert.IsFalse(ActivityStatus.Suspended.IsStopping());
            Assert.IsTrue(ActivityStatus.Stopping.IsStopping());
            Assert.IsFalse(ActivityStatus.Completed.IsStopping());
            Assert.IsFalse(ActivityStatus.Stopped.IsStopping());
        }

        [TestMethod]
        public void Test___Method_IsRunning()
        {
            Assert.IsFalse(ActivityStatus.Created.IsRunning());
            Assert.IsTrue(ActivityStatus.Executing.IsRunning());
            Assert.IsFalse(ActivityStatus.Suspended.IsRunning());
            Assert.IsTrue(ActivityStatus.Stopping.IsRunning());
            Assert.IsFalse(ActivityStatus.Completed.IsRunning());
            Assert.IsFalse(ActivityStatus.Stopped.IsRunning());
        }

        [TestMethod]
        public void Test___Method_IsCompleted()
        {
            Assert.IsFalse(ActivityStatus.Created.IsCompleted());
            Assert.IsFalse(ActivityStatus.Executing.IsCompleted());
            Assert.IsFalse(ActivityStatus.Suspended.IsCompleted());
            Assert.IsFalse(ActivityStatus.Stopping.IsCompleted());
            Assert.IsTrue(ActivityStatus.Completed.IsCompleted());
            Assert.IsFalse(ActivityStatus.Stopped.IsCompleted());
        }

        public void Test___Method_IsStopped()
        {
            Assert.IsFalse(ActivityStatus.Created.IsStopped());
            Assert.IsFalse(ActivityStatus.Executing.IsStopped());
            Assert.IsFalse(ActivityStatus.Suspended.IsStopped());
            Assert.IsFalse(ActivityStatus.Stopping.IsStopped());
            Assert.IsFalse(ActivityStatus.Completed.IsStopped());
            Assert.IsTrue(ActivityStatus.Stopped.IsStopped());
        }

        public void Test___Method_IsFinished()
        {
            Assert.IsFalse(ActivityStatus.Created.IsFinished());
            Assert.IsFalse(ActivityStatus.Executing.IsFinished());
            Assert.IsFalse(ActivityStatus.Suspended.IsFinished());
            Assert.IsFalse(ActivityStatus.Stopping.IsFinished());
            Assert.IsTrue(ActivityStatus.Completed.IsFinished());
            Assert.IsTrue(ActivityStatus.Stopped.IsFinished());
        }

        public void Test___Method_CanStart()
        {
            Assert.IsTrue(ActivityStatus.Created.CanStart());
            Assert.IsFalse(ActivityStatus.Executing.CanStart());
            Assert.IsTrue(ActivityStatus.Suspended.CanStart());
            Assert.IsFalse(ActivityStatus.Stopping.CanStart());
            Assert.IsFalse(ActivityStatus.Completed.CanStart());
            Assert.IsFalse(ActivityStatus.Stopped.CanStart());
        }

        public void Test___Method_CanStop()
        {
            Assert.IsTrue(ActivityStatus.Created.CanStop());
            Assert.IsTrue(ActivityStatus.Executing.CanStop());
            Assert.IsTrue(ActivityStatus.Suspended.CanStop());
            Assert.IsFalse(ActivityStatus.Stopping.CanStop());
            Assert.IsFalse(ActivityStatus.Completed.CanStop());
            Assert.IsFalse(ActivityStatus.Stopped.CanStop());
        }

        public void Test___Method_CanReset()
        {
            Assert.IsFalse(ActivityStatus.Created.CanReset());
            Assert.IsFalse(ActivityStatus.Executing.CanReset());
            Assert.IsFalse(ActivityStatus.Suspended.CanReset());
            Assert.IsFalse(ActivityStatus.Stopping.CanReset());
            Assert.IsTrue(ActivityStatus.Completed.CanReset());
            Assert.IsTrue(ActivityStatus.Stopped.CanReset());
        }

        public void Test___Method_GetStatus___Created()
        {
            var activity1 = new Mock<IActivity>();
            var activity2 = new Mock<IActivity>();
            var activity3 = new Mock<IActivity>();

            activity1.Setup(a => a.Status).Returns(ActivityStatus.Created);
            activity2.Setup(a => a.Status).Returns(ActivityStatus.Created);
            activity3.Setup(a => a.Status).Returns(ActivityStatus.Created);

            var testee = new List<IActivity>()
            {
                activity1.Object,
                activity2.Object,
                activity3.Object
            };

            Assert.AreEqual(ActivityStatus.Created, testee.GetStatus());
        }

        public void Test___Method_GetStatus___Stopped()
        {
            var activity1 = new Mock<IActivity>();
            var activity2 = new Mock<IActivity>();
            var activity3 = new Mock<IActivity>();

            activity1.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity2.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity3.Setup(a => a.Status).Returns(ActivityStatus.Stopped);

            var testee = new List<IActivity>()
            {
                activity1.Object,
                activity2.Object,
                activity3.Object
            };

            Assert.AreEqual(ActivityStatus.Stopped, testee.GetStatus());
        }

        public void Test___Method_GetStatus___Completed()
        {
            var activity1 = new Mock<IActivity>();
            var activity2 = new Mock<IActivity>();
            var activity3 = new Mock<IActivity>();

            activity1.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity2.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity3.Setup(a => a.Status).Returns(ActivityStatus.Completed);

            var testee = new List<IActivity>()
            {
                activity1.Object,
                activity2.Object,
                activity3.Object
            };

            Assert.AreEqual(ActivityStatus.Completed, testee.GetStatus());
        }

        public void Test___Method_GetStatus___Stopping()
        {
            var activity1 = new Mock<IActivity>();
            var activity2 = new Mock<IActivity>();
            var activity3 = new Mock<IActivity>();

            activity1.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity2.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity3.Setup(a => a.Status).Returns(ActivityStatus.Stopping);

            var testee = new List<IActivity>()
            {
                activity1.Object,
                activity2.Object,
                activity3.Object
            };

            Assert.AreEqual(ActivityStatus.Stopping, testee.GetStatus());
        }

        public void Test___Method_GetStatus___Suspended()
        {
            var activity1 = new Mock<IActivity>();
            var activity2 = new Mock<IActivity>();
            var activity3 = new Mock<IActivity>();

            activity1.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity2.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity3.Setup(a => a.Status).Returns(ActivityStatus.Suspended);

            var testee = new List<IActivity>()
            {
                activity1.Object,
                activity2.Object,
                activity3.Object
            };

            Assert.AreEqual(ActivityStatus.Suspended, testee.GetStatus());
        }

        public void Test___Method_GetStatus___Executing()
        {
            var activity1 = new Mock<IActivity>();
            var activity2 = new Mock<IActivity>();
            var activity3 = new Mock<IActivity>();

            activity1.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity2.Setup(a => a.Status).Returns(ActivityStatus.Completed);
            activity3.Setup(a => a.Status).Returns(ActivityStatus.Executing);

            var testee = new List<IActivity>()
            {
                activity1.Object,
                activity2.Object,
                activity3.Object
            };

            Assert.AreEqual(ActivityStatus.Suspended, testee.GetStatus());
        }
    }
}
