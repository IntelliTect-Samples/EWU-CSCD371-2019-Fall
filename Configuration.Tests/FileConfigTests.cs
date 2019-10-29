using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#pragma warning disable CA1707

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        public void FileConfig_Read()
        {
            string path = Path.GetRandomFileName();
            List<Tuple<string, string?>> testList = new List<Tuple<string, string?>>();
            testList.Add(new Tuple<string, string?>("nameA", "valueA"));

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("nameA=valueA");
            }

            FileConfig fileConfig = new FileConfig(path);
            var config = fileConfig.Read();
            CollectionAssert.AreEqual(testList, config);
            File.Delete(path);
        }

        [DataTestMethod]
        [DataRow("nameA", "valueB")]
        public void FileConfig_Write(string name, string value)
        {
            string path = Path.GetRandomFileName();
            FileConfig config = new FileConfig(path);
            config.Write(name, value);
            string line = File.ReadLines(path).First();
            Assert.AreEqual($"{name}={value}", line);
            File.Delete(path);
        }

        [DataTestMethod]
        [DataRow("nameA", "value B")]
        [DataRow("nameA", null)]
        [DataRow("nameA", "value=")]
        [DataRow("nameA", "")]
        public void FileConfig_Write_BadValue(string name, string value)
        { 
            FileConfig config = new FileConfig("");
            Assert.IsFalse(config.Write(name, value));
        }

        [DataTestMethod]
        [DataRow("nameA", "valueB")]
        public void FileConfig_Write_GoodValue(string name, string value)
        {
            FileConfig config = new FileConfig("TestFile");
            Assert.IsTrue(config.Write(name, value));
        }

        [DataTestMethod]
        [DataRow("name A", "valueB")]
        [DataRow("name=", "valueB")]
        [DataRow("", "valueB")]
        [DataRow(null, "valueB")]
        public void FileConfig_Write_BadName(string name, string value)
        {
            FileConfig config = new FileConfig("TestFile");
            Assert.IsFalse(config.Write(name, value));
        }

        [DataTestMethod]
        [DataRow("nameA", "valueB")]
        public void FileConfig_Write_GoodName(string name, string value)
        {
            FileConfig config = new FileConfig("TestFile");
            Assert.IsTrue(config.Write(name, value));
        }

    }
}
