using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WFLite.Conditions.IO;
using WFLite.Variables;

namespace WFLite.Test.Conditions.IO
{
    [TestClass]
    public class DirectoryExistsConditionTest
    {
        [TestInitialize]
        public void Initialize()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name);

            if(Directory.Exists(path))
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
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");

            Directory.CreateDirectory(path);

            var testee = new DirectoryExistsCondition()
            {
                Path = new AnyVariable<string>() { Value = path }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");

            var testee = new DirectoryExistsCondition()
            {
                Path = new AnyVariable<string>() { Value = path }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}