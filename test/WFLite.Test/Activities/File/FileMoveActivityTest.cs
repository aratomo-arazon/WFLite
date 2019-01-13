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
    public class FileMoveActivityTest
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
            var sourceFileName = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");
            var destFileName = Path.Combine(Path.GetTempPath(), GetType().Name, "bar.txt");

            System.IO.File.WriteAllText(sourceFileName, "baz");

            var testee = new FileMoveActivity()
            {
                SourceFileName = new AnyVariable() { Value = sourceFileName },
                DestFileName = new AnyVariable() { Value = destFileName }
            };

            await testee.Start();

            Assert.IsFalse(System.IO.File.Exists(sourceFileName));
            Assert.IsTrue(System.IO.File.Exists(destFileName));
            Assert.AreEqual("baz", System.IO.File.ReadAllText(destFileName));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
