using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WFLite.Conditions.IO;
using WFLite.Variables;

namespace WFLite.Test.Conditions.IO
{
    [TestClass]
    public class FileExistsConditionTest
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
        public void Test___Method_Check___True()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            File.WriteAllText(path, "bar");

            var testee = new FileExistsCondition()
            {
                Path = new AnyVariable<string>() { Value = path }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo.txt");

            var testee = new FileExistsCondition()
            {
                Path = new AnyVariable<string>() { Value = path }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
