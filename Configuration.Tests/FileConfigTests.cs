using Configuration;
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileConfigNullThrowsException()
        {
            //Arrange
            string? path = null;

            //Act
            FileConfig config = new FileConfig(path);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileConfigEmptyThrowsException()
        {
            //Arrange
            FileConfig config = new FileConfig("");

            //Act

            //Assert
        }

        [TestMethod]
        public void FileConfigGoodPath()
        {
            //Arrange
            FileConfig config = new FileConfig("Path");

            //Act

            //Assert
            Assert.AreEqual(config.GetPath(), "Path");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteConfigNullNameThrowsException()
        {
            //Arrange
            FileConfig fileConfig = new FileConfig("Path");
            string? variable = null;

            //Act
            fileConfig.WriteConfig(variable, "Value");

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteConfigEmptyNameThrowsException()
        {
            //Arrange
            FileConfig fileConfig = new FileConfig("Path");

            //Act
            fileConfig.WriteConfig("", "Value");

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteConfigAllBadParameters()
        {
            //Arrange
            FileConfig fileConfig = new FileConfig("Path");
            string value = "value";

            //Act
            fileConfig.WriteConfig("", value);

            //Assert
        }
    }
}
