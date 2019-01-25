using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WFLite.Conditions.IO;
using WFLite.Variables;

namespace WFLite.Test.Conditions.Directory
{
    [TestClass]
    public class DirectoryExistsConditionTest
    {
        [TestInitialize]
        public void Initialize()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name);

            if(System.IO.Directory.Exists(path))
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
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");

            System.IO.Directory.CreateDirectory(path);

            var testee = new DirectoryExistsCondition()
            {
                Path = new AnyVariable() { Value = path }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___False()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");

            var testee = new DirectoryExistsCondition()
            {
                Path = new AnyVariable() { Value = path }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}