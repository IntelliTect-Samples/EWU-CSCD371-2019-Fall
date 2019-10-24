using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Configuration.Tests
{
    [TestClass()]
    public class FileConfigTests
    {
        [TestMethod()]
        public void FileConfig_ReadConfig()
        {
            //Arrange
            string filePath = Path.GetRandomFileName();
            List<Tuple<string, string?>> expectedConfigList = new List<Tuple<string, string?>>();
            expectedConfigList.Add(new Tuple<string, string?>("NAME1", "VALUE1"));
            expectedConfigList.Add(new Tuple<string, string?>("NAME2", "VALUE2"));
            expectedConfigList.Add(new Tuple<string, string?>("NAME3", "VALUE3"));

            try
            {
                GenerateTestFile(filePath);
                FileConfig fileConfig = new FileConfig(filePath);

                //Act
                var configList = fileConfig.ReadConfig();

                //Assert
                CollectionAssert.AreEqual(expectedConfigList, configList);
                CollectionAssert.AreEqual(expectedConfigList, configList);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod()]
        public void FileConfig_WriteConfig()
        {
            //Arrange
            string filePath = Path.GetRandomFileName();

            try
            {
                FileConfig fileConfig = new FileConfig(filePath);

                //Act
                fileConfig.WriteConfig("NAME1", "VALUE1");
                fileConfig.WriteConfig("NAME2", "VALUE2");
                string[] fileLines = File.ReadLines(filePath).ToArray();

                //Assert
                Assert.AreEqual(fileLines.Length, 2);
                Assert.AreEqual(fileLines[0], "NAME1=VALUE1");
                Assert.AreEqual(fileLines[1], "NAME2=VALUE2");
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod()]
        public void FileConfig_ValidateNameAndValue_ValueFail()
        {
            //Arrange
            string name = "PATHTEST", value = "VALUE=value";
            FileConfig fileConfig = new FileConfig("unnecessary");

            //Act
            bool tf = fileConfig.ValidateNameAndValue(name, value);

            //Assert
            Assert.IsFalse(tf);
        }

        [TestMethod()]
        public void FileConfig_ValidateNameAndValue_VaLuePass()
        {
            //Arrange
            string name = "PATHTEST", value = "value";
            FileConfig fileConfig = new FileConfig("unnecessary");

            //Act
            bool tf = fileConfig.ValidateNameAndValue(name, value);

            //Assert
            Assert.IsTrue(tf);
        }

        [TestMethod()]
        public void FileConfig_ValidateNameAndValue_NameFail()
        {
            //Arrange
            string name = "TEMP PATH", value = "VALUE";
            FileConfig fileConfig = new FileConfig("unnecessary");

            //Act
            bool tf = fileConfig.ValidateNameAndValue(name, value);

            //Assert
            Assert.IsFalse(tf);
        }

        [TestMethod()]
        public void FileConfig_ValidateNameAndValue_NamePass()
        {
            //Arrange
            string name = "path", value = "VALUE";
            FileConfig fileConfig = new FileConfig("unnecessary");

            //Act
            bool tf = fileConfig.ValidateNameAndValue(name, value);

            //Assert
            Assert.IsTrue(tf);
        }

        private void GenerateTestFile(string filePath)
        {
            using(StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("NAME1=VALUE1");
                sw.WriteLine("NAME2=VALUE2");
                sw.WriteLine("NAME3=VALUE3");
            }
        }
    }
}