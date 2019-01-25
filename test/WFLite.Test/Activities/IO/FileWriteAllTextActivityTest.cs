using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WFLite.Activities.IO;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.IO
{
    [TestClass]
    public class FileWriteAllTextActivityTest
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
        public async Task Test___Method_Start___Encoding_null()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            var testee = new FileWriteAllTextActivity()
            {
                Path = new AnyVariable() { Value = path },
                Contents = new AnyVariable() { Value = "bar" }
            };

            await testee.Start();

            Assert.AreEqual("bar", File.ReadAllText(path));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Encoding_UTF8()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            var testee = new FileWriteAllTextActivity()
            {
                Path = new AnyVariable() { Value = path },
                Contents = new AnyVariable() { Value = "bar" },
                Encoding = new AnyVariable() { Value = Encoding.UTF8 }
            };

            await testee.Start();

            Assert.AreEqual("bar", File.ReadAllText(path));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
