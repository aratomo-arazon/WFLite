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
    public class DirectoryCreateActivityTest
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
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");

            var testee = new DirectoryCreateActivity()
            {
                Path = new AnyVariable() { Value = path }
            };

            await testee.Start();

            Assert.IsTrue(System.IO.Directory.Exists(path));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
