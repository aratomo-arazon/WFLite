using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Variables;
using WFLite.Variables.Diagnostics;

namespace WFLite.Test.Variables.Diagnostics
{
    [TestClass]
    public class ProcessStartInfoVariableTest
    {
        [TestMethod]
        public void Test___Method_GetValue()
        {
            var testee = new ProcessStartInfoVariable()
            {
                FileName = new AnyVariable<string>() { Value = "foo.exe" },
                Arguments = new AnyVariable<string>() { Value = "bar baz" },
                UseShellExecute = new AnyVariable<bool>() { Value = true },
                CreateNoWindow = new AnyVariable<bool>() { Value = true },
                WorkingDirectory = new AnyVariable<string>() { Value = "C:\\Program Files\\WFLite" }
            };

            var processStartInfo = testee.GetValue();

            Assert.AreEqual("foo.exe", processStartInfo!.FileName);
            Assert.AreEqual("bar baz", processStartInfo!.Arguments);
            Assert.IsTrue(processStartInfo!.UseShellExecute);
            Assert.IsTrue(processStartInfo!.CreateNoWindow);
            Assert.AreEqual("C:\\Program Files\\WFLite", processStartInfo!.WorkingDirectory);
        }
    }
}
