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
    public class FileReadAllBytesAsnycActivityTest
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

            System.IO.File.WriteAllBytes(path, Encoding.UTF8.GetBytes("bar"));

            var bytes = new AnyVariable();

            var testee = new FileReadAllBytesAsyncActivity()
            {
                Path = new AnyVariable() { Value = path },
                Bytes = bytes
            };

            await testee.Start();

            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
            Assert.AreEqual("bar", Encoding.UTF8.GetString(bytes.GetValue<byte[]>()));
        }
    }
}
