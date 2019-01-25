using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using WFLite.Activities.IO;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.IO
{
    [TestClass]
    public class FileReadAllLinesAsyncActivityTest
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
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            File.WriteAllLines(path, new string[] { "bar", "baz" });

            var contents = new AnyVariable();

            var testee = new FileReadAllLinesAsyncActivity()
            {
                Path = new AnyVariable() { Value = path },
                Contents = contents
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual("bar", contents.GetValue<string[]>()[0]);
            Assert.AreEqual("baz", contents.GetValue<string[]>()[1]);
        }
    }
}
