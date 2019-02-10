using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities.Diagnostics;
using WFLite.Enums;
using WFLite.Variables;
using WFLite.Variables.Diagnostics;

namespace WFLite.Test.Activities.Diagnostics
{
    [TestClass]
    public class ProcessExecuteActivityTest
    {
        [TestMethod]
        public async Task Test___Method_Start()
        {
            var exitCode = new AnyVariable<int>();

            var testee = new ProcessExecuteActivity()
            {
                StartInfo = new ProcessStartInfoVariable()
                {
                    FileName = new AnyVariable<string>("cmd.exe"),
                    Arguments = new AnyVariable<string>("/Ccd"),
                    CreateNoWindow = new AnyVariable<bool>(true),
                    UseShellExecute = new AnyVariable<bool>(false)
                },
                ExitCode = exitCode
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual(0, exitCode.GetValue());
        }
    }
}
