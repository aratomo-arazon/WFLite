using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities.File;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.File
{
    [TestClass]
    public class FileWriteAllLinesActivityTest
    {
        [TestInitialize]
        public void Initialize()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name);

            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
            }
            System.IO.Directory.CreateDirectory(path);
        }

        [TestCleanup]
        public void Cleanup()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name);

            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
            }
        }

        [TestMethod]
        public async Task Test___Method_Start()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            var testee = new FileWriteAllLinesActivity()
            {
                Path = new AnyVariable() { Value = path },
                Contents = new AnyVariable() { Value = new string[] { "bar", "baz" } }
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual("bar", System.IO.File.ReadAllLines(path)[0]);
            Assert.AreEqual("baz", System.IO.File.ReadAllLines(path)[1]);
        }
    }
}
