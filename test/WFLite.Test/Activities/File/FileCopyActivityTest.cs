using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities.File;
using WFLite.Conditions;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.File
{
    [TestClass]
    public class FileCopyActivityTest
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
        public async Task Test___Method_Start___Overwrite_False()
        {
            var sourceFilePath = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");
            var destFilePath = Path.Combine(Path.GetTempPath(), GetType().Name, "bar.txt");

            System.IO.File.WriteAllText(sourceFilePath, "baz");

            var testee = new FileCopyActivity()
            {
                SourceFileName = new AnyVariable() { Value = sourceFilePath },
                DestFileName = new AnyVariable() { Value = destFilePath },
                Overwrite = new FalseCondition()
            };

            await testee.Start();

            Assert.IsTrue(System.IO.File.Exists(sourceFilePath));
            Assert.IsTrue(System.IO.File.Exists(destFilePath));
            Assert.AreEqual("baz", System.IO.File.ReadAllText(destFilePath));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Overwrite_True()
        {
            var sourceFilePath = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");
            var destFilePath = Path.Combine(Path.GetTempPath(), GetType().Name, "bar.txt");

            System.IO.File.WriteAllText(sourceFilePath, "baz");
            System.IO.File.WriteAllText(destFilePath, "zzz");

            var testee = new FileCopyActivity()
            {
                SourceFileName = new AnyVariable() { Value = sourceFilePath },
                DestFileName = new AnyVariable() { Value = destFilePath },
                Overwrite = new TrueCondition()
            };

            await testee.Start();

            Assert.IsTrue(System.IO.File.Exists(sourceFilePath));
            Assert.IsTrue(System.IO.File.Exists(destFilePath));
            Assert.AreEqual("baz", System.IO.File.ReadAllText(destFilePath));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
