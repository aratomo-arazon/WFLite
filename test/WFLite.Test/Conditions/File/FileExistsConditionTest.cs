using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WFLite.Conditions.IO;
using WFLite.Variables;

namespace WFLite.Test.Conditions.File
{
    [TestClass]
    public class FileExistsConditionTest
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
        public void Test___Method_Check___True()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            System.IO.File.WriteAllText(path, "bar");

            var testee = new FileExistsCondition()
            {
                Path = new AnyVariable() { Value = path }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            var testee = new FileExistsCondition()
            {
                Path = new AnyVariable() { Value = path }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
