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
        [TestMethod]
        public void FileConfig_ReadFileCorrectly()
        {
            FileConfig fileConfig = new FileConfig(Path.GetTempFileName());

            fileConfig.WriteConfig("Name1", "Value1");
            Assert.AreEqual("Name1=Value1", fileConfig.ReadConfig()[0]);
        }

        [TestMethod]
        public void FileConfig_WriteFileCorrectly()
        {
            string filePath = Path.GetTempFileName();
            FileConfig fileConfig = new FileConfig(filePath);

            fileConfig.WriteConfig("Name1", "Value1");
            fileConfig.WriteConfig("Name2", "Value2");
            fileConfig.WriteConfig("Name3", "Value3");

            string[] checkList = File.ReadAllLines(filePath);

            Assert.AreEqual("Name1=Value1",checkList[0]);
            Assert.AreEqual("Name2=Value2", checkList[1]);
            Assert.AreEqual("Name3=Value3", checkList[2]);
        }
    }
}
