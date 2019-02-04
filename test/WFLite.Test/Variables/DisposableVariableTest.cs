using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Variables;

namespace WFLite.Test.Variables
{
    [TestClass]
    public class DisposableVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue()
        {
            var disposable = new Mock<IDisposable>();

            var testee = new DisposableVariable()
            {
                Func = () => disposable.Object
            };

            Assert.AreEqual(disposable.Object, testee.GetValue());
        }
    }
}
