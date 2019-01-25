using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class LockVariableTest
    {
        [TestMethod]
        public void Test___Method_Start()
        {
            var testee1 = new LockVariable();
            var testee2 = new LockVariable();

            var semaphoreSlim1 = testee1.GetValue<SemaphoreSlim>();
            var semaphoreSlim2 = testee2.GetValue<SemaphoreSlim>();

            Assert.IsNotNull(semaphoreSlim1);
            Assert.IsNotNull(semaphoreSlim2);
            Assert.AreNotEqual(semaphoreSlim1, semaphoreSlim2);
        }
    }
}
