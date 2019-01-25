using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities
{
    [TestClass]
    public class UsingActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start()
        {
            var disposable = new Mock<IDisposable>();

            disposable
                .Setup(d => d.Dispose());

            var testee = new UsingActivity()
            {
                Disposable = new DisposableVariable()
                {
                    Func = () => disposable.Object
                },
                Activity = new NullActivity()
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);

            disposable
                .Verify(d => d.Dispose(), Times.Once);
        }
    }
}
