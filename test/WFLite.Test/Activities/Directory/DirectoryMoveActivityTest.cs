using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities.Directory;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.Directory
{
    [TestClass]
    public class DirectoryMoveActivityTest
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
            var sourceDirName = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");
            var destDirName = Path.Combine(Path.GetTempPath(), GetType().Name, "bar");

            System.IO.Directory.CreateDirectory(sourceDirName);

            var testee = new DirectoryMoveActivity()
            {
                SourceDirName = new AnyVariable() { Value = sourceDirName },
                DestDirName = new AnyVariable() { Value = destDirName }
            };

            await testee.Start();

            Assert.IsFalse(System.IO.Directory.Exists(sourceDirName));
            Assert.IsTrue(System.IO.Directory.Exists(destDirName));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
