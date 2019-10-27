using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        private List<String> ExpectedList = new List<String>();

        [DataTestMethod]
        public void FileConfig_ReadFileCorrectly()
        {
            FileConfig fileConfig = new FileConfig(Path.GetTempFileName());

            fileConfig.WriteConfig("Name1", "Value1");
            Assert.AreEqual("Name1=Value1", fileConfig.ReadConfig()[0]);
        }
    }
}
