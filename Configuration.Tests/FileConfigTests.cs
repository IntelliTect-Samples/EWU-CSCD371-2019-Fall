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
        public void SetConfigValue_GivenValidNameAndValue_ReturnsTrue()
        {
            //Arrange
            FileConfig fileConf = new Configuration.FileConfig();

            //Act
            bool worked = fileConf.SetConfigValue("variable1", "true");

            //Assert
            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void SetConfigValue_GivenInvalidName_ReturnsFalse()
        {
            //Arrange
            FileConfig fileConf = new Configuration.FileConfig();

            //Act
            bool worked = fileConf.SetConfigValue("variable 1", "true");

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void SetConfigValue_GivenValidName_NullValue_ReturnsFalse()
        {
            //Arrange
            FileConfig fileConf = new Configuration.FileConfig();

            //Act
            bool worked = fileConf.SetConfigValue("variable1", null);

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void GetConfigValue_GivenValidName_ReturnsTrue()
        {
            //Arrange
            FileConfig fileConf = new Configuration.FileConfig();
            string? output;

            //Act
            fileConf.SetConfigValue("variable1", "true");
            bool worked = fileConf.GetConfigValue("variable1", out output);

            //Assert
            Assert.IsTrue(worked);
            Assert.AreEqual(output, "true");
        }

        [TestMethod]
        public void GetConfigValue_GivenInvalidName_ReturnsFalse()
        {
            //Arrange
            FileConfig fileConf = new Configuration.FileConfig();

            //Act
            bool worked = fileConf.GetConfigValue("variable 1", out _);

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void GetConfigValue_GivenValidButUnsetName_ReturnsFalse()
        {
            //Arrange
            FileConfig fileConf = new Configuration.FileConfig();

            //Act
            bool worked = fileConf.GetConfigValue("thisistexas", out _);

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void GetConfigValue_GivenNullName_ReturnsFalse()
        {
            //Arrange
            FileConfig fileConf = new Configuration.FileConfig();

            //Act
            bool worked = fileConf.GetConfigValue(null, out _);

            //Assert
            Assert.IsFalse(worked);
        }
    }
}
