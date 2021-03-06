﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using WFLite.Activities.IO;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.IO
{
    [TestClass]
    public class DirectoryCreateActivityTest
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
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");

            var testee = new DirectoryCreateActivity()
            {
                Path = new AnyVariable<string>() { Value = path }
            };

            await testee.Start();

            Assert.IsTrue(Directory.Exists(path));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
