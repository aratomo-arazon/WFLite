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
    public class FileReadAllTextAsyncActivityTest
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
        public async Task Test___Method_Start___Encoding_null()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");
            
            System.IO.File.WriteAllText(path, "bar");

            var contents = new AnyVariable();

            var testee = new FileReadAllTextAsyncActivity()
            {
                Path = new AnyVariable() { Value = path },
                Contents = contents
            };

            await testee.Start();

            Assert.AreEqual("bar", contents.GetValue<string>());
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Encoding_UTF8()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            System.IO.File.WriteAllText(path, "bar");

            var contents = new AnyVariable();

            var testee = new FileReadAllTextAsyncActivity()
            {
                Path = new AnyVariable() { Value = path },
                Contents = contents,
                Encoding = new AnyVariable() { Value = Encoding.UTF8 }
            };

            await testee.Start();

            Assert.AreEqual("bar", contents.GetValue<string>());
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
