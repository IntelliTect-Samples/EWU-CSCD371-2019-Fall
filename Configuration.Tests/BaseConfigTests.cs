using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class BaseConfigTests
    {
        [DataTestMethod]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("Hello World", false)]
        [DataRow("Hello=World", false)]
        [DataRow("Hello = World", false)]
        [DataRow("Test", true)]
        [DataRow("success", true)]
        public void CheckValidConfigTest(string name, bool expected)
        {
            bool returned = BaseConfig.CheckValidConfig(name);

            Assert.AreEqual(expected, returned);
        }
    }
}
