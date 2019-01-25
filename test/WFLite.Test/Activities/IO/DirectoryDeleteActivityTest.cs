using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using WFLite.Activities.IO;
using WFLite.Conditions;
using WFLite.Enums;
using WFLite.Variables;

namespace WFLite.Test.Activities.IO
{
    [TestClass]
    public class DirectoryDeleteActivityTest
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
        public async Task Test___Method_Start___Recursive_False()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");

            Directory.CreateDirectory(path);

            var testee = new DirectoryDeleteActivity()
            {
                Path = new AnyVariable() { Value = path },
                Recursive = new FalseCondition()
            };

            await testee.Start();

            Assert.IsFalse(Directory.Exists(path));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }

        [TestMethod]
        public async Task Test___Method_Start___Recursive_True()
        {
            var path = Path.Combine(Path.GetTempPath(), GetType().Name, "foo");

            Directory.CreateDirectory(path);

            var subdir = Path.Combine(Path.GetTempPath(), GetType().Name, "foo", "bar");

            Directory.CreateDirectory(subdir);

            var testee = new DirectoryDeleteActivity()
            {
                Path = new AnyVariable() { Value = path },
                Recursive = new TrueCondition()
            };

            await testee.Start();

            Assert.IsFalse(Directory.Exists(path));
            Assert.AreEqual(ActivityStatus.Completed, testee.Status);
        }
    }
}
