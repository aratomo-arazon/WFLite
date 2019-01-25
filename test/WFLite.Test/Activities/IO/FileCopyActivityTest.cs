using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities.IO;
using WFLite.Conditions;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.IO
{
    [TestClass]
    public class FileCopyActivityTest
    {
        [TestInitialize]
        public void Initialize()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name);

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
        }

        [TestCleanup]
        public void Cleanup()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name);

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }

        [TestMethod]
        public async Task Test___Method_Start___Overwrite_False()
        {
            var sourceFilePath = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");
            var destFilePath = Path.Combine(Path.GetTempPath(), GetType().Name, "bar.txt");

            File.WriteAllText(sourceFilePath, "baz");

            var testee = new FileCopyActivity()
            {
                SourceFileName = new AnyVariable() { Value = sourceFilePath },
                DestFileName = new AnyVariable() { Value = destFilePath },
                Overwrite = new FalseCondition()
            };

            await testee.Start();

            Assert.IsTrue(File.Exists(sourceFilePath));
            Assert.IsTrue(File.Exists(destFilePath));
            Assert.AreEqual("baz", File.ReadAllText(destFilePath));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Overwrite_True()
        {
            var sourceFilePath = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");
            var destFilePath = Path.Combine(Path.GetTempPath(), GetType().Name, "bar.txt");

            File.WriteAllText(sourceFilePath, "baz");
            File.WriteAllText(destFilePath, "zzz");

            var testee = new FileCopyActivity()
            {
                SourceFileName = new AnyVariable() { Value = sourceFilePath },
                DestFileName = new AnyVariable() { Value = destFilePath },
                Overwrite = new TrueCondition()
            };

            await testee.Start();

            Assert.IsTrue(File.Exists(sourceFilePath));
            Assert.IsTrue(File.Exists(destFilePath));
            Assert.AreEqual("baz", File.ReadAllText(destFilePath));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
