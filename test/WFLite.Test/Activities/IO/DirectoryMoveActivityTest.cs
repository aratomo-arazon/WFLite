using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using WFLite.Activities.IO;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.IO
{
    [TestClass]
    public class DirectoryMoveActivityTest
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
        public async Task Test___Method_Start()
        {
            var sourceDirName = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");
            var destDirName = Path.Combine(Path.GetTempPath(), GetType().Name, "bar");

            Directory.CreateDirectory(sourceDirName);

            var testee = new DirectoryMoveActivity()
            {
                SourceDirName = new AnyVariable<string>() { Value = sourceDirName },
                DestDirName = new AnyVariable<string>() { Value = destDirName }
            };

            await testee.Start();

            Assert.IsFalse(Directory.Exists(sourceDirName));
            Assert.IsTrue(Directory.Exists(destDirName));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
