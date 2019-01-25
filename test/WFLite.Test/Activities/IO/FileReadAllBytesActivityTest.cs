using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities.IO;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.IO
{
    [TestClass]
    public class FileReadAllBytesActivityTest
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

            File.WriteAllBytes(path, Encoding.UTF8.GetBytes("bar"));

            var bytes = new AnyVariable();

            var testee = new FileReadAllBytesActivity()
            {
                Path = new AnyVariable() { Value = path },
                Bytes = bytes
            };

            await testee.Start();

            Assert.AreEqual("bar", Encoding.UTF8.GetString(bytes.GetValue<byte[]>()));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
