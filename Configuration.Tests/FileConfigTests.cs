using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        public void Read_Success()
        {
            //Arrange
            FileConfig fileConfig = new FileConfig();
            Dictionary<string, string> map = new Dictionary<string, string>();

            //Act
            _=fileConfig.FileWrite("type1","value1");
            map = fileConfig.FileRead();

            //Assert
            Assert.IsTrue(map.ContainsKey("type1"));
            Assert.IsTrue(map.ContainsValue("value1"));
        }

        [TestMethod]
        public void Write_Success()
        {
            //Arrange
            FileConfig fileConfig = new FileConfig();

            //Act
            bool result = fileConfig.FileWrite("word","next");

            //Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(null, "word")]
        [DataRow("word", null)]
        [DataRow("", "word")]
        [DataRow("word", "")]
        [DataRow("wo=rd", "word")]
        [DataRow("word", "wo=rd")]
        [DataRow("wo rd", "word")]
        [DataRow("word", "wo rd")]
        public void Write_Fail(string name, string value)
        {
            //Arrange
            FileConfig fileConfig =  new FileConfig();

            //Act
            bool result = fileConfig.FileWrite(name,value);

            //Assert
            Assert.IsFalse(result);
        }

    }
}
