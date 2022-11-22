using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Enums;
using WFLite.Extensions;
using WFLite.Variables;

namespace WFLite.Test.Extensions
{
    [TestClass]
    public class FuncExtensionTest
    {
        [TestMethod]
        public void Test___Method_ToVariable___object()
        {
            var testee = new Func<object>(() => 10);

            Assert.AreEqual(10, testee.ToVariable().GetValue<int>());
        }

        [TestMethod]
        public void Test___Method_ToVariable___generic()
        {
            var testee = new Func<int>(() => 10);

            Assert.AreEqual(10, testee.ToVariable().GetValue());
        }

        [TestMethod]
        public void Test___Method_ToConverter___object_to_object()
        {
            var testee = new Func<object?, object?>(value => value);

            Assert.AreEqual(10, testee.ToConverter().ConvertToObject(10));
        }

        [TestMethod]
        public void Test___Method_ToConverter___object_to_generic()
        {
            var testee = new Func<object?, int>(value => Convert.ToInt32(value));

            Assert.AreEqual(10, testee.ToConverter<int>().Convert(10));
        }

        [TestMethod]
        public void Test___Method_ToConverter___generic_to_generic()
        {
            var testee = new Func<int, string>(value => Convert.ToString(value));

            Assert.AreEqual("10", testee.ToConverter<int, string>().Convert(10));
        }

        [TestMethod]
        public void Test___Method_ToCondition()
        {
            var testee = new Func<bool>(() => true);

            Assert.IsTrue(testee.ToCondition().Check());
        }

        [TestMethod]
        public async Task Test___Method_ToActivity___sync()
        {
            var value = new AnyVariable<int>();

            var testee = new Func<bool>(() =>
            {
                value.SetValue(10);
                return true;
            });

            await testee.ToActivity().Start();

            Assert.AreEqual(10, value.GetValue());
        }

        [TestMethod]
        public async Task Test___Method_ToActivity___async()
        {
            var value = new AnyVariable<int>();

            var testee = new Func<CancellationToken, Task<bool>>(async (cancellationToken) =>
            {
                value.SetValue(10);
                return await Task.FromResult(true);
            });

            await testee.ToActivity().Start();

            Assert.AreEqual(10, value.GetValue());
        }
    }
}
