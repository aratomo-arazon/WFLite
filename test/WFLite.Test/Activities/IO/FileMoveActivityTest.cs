using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using WFLite.Activities.IO;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.IO
{
    [TestClass]
    public class FileMoveActivityTest
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
            var sourceFileName = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");
            var destFileName = Path.Combine(Path.GetTempPath(), GetType().Name, "bar.txt");

            File.WriteAllText(sourceFileName, "baz");

            var testee = new FileMoveActivity()
            {
                SourceFileName = new AnyVariable<string>() { Value = sourceFileName },
                DestFileName = new AnyVariable<string>() { Value = destFileName }
            };

            await testee.Start();

            Assert.IsFalse(File.Exists(sourceFileName));
            Assert.IsTrue(File.Exists(destFileName));
            Assert.AreEqual("baz", File.ReadAllText(destFileName));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
