using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WFLite.Interfaces;
using WFLite.Variables;
using WFLite.Variables.IO;

namespace WFLite.Test.Variables.IO
{
    [TestClass]
    public class PathCombineVariableTest
    {
        [TestMethod]
        public void Test___GetValue()
        {
            var testee = new PathCombineVariable()
            {
                Paths = new List<IOutVariable<string>>()
                {
                    new AnyVariable<string>() { Value = "C:" },
                    new AnyVariable<string>() { Value = "Program Files" },
                    new AnyVariable<string>() { Value = "WFLite"}
                }
            };

            Assert.AreEqual("C:\\Program Files\\WFLite", testee.GetValue());
        }
    }
}
