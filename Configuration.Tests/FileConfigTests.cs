using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        public void FileConfig_GetConfigValue_ReturnsTrue()
        {
            // Arrange
            string name = "USERPROFILE";
            FileConfig sut = new FileConfig();

            // Act
            bool result = sut.GetConfigValue(name, out string? _);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FileConfig_GetConfigValue_ReturnsFalse()
        {
            // Arrange
            FileConfig sut = new FileConfig();
            string name = "invalid name";

            // Act
            bool result = sut.GetConfigValue(name, out string? _);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FileConfig_SetConfigValue_ReturnsTrue()
        {
            // Arrange
            FileConfig sut = new FileConfig();
            string name = "USERPROFILE";
            string value = "testValue";

            // Act
            bool result = sut.SetConfigValue(name, value);

            // Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("test Name", "test Value")]
        [DataRow("test=Name", "test=Value")]
        [DataRow(null, "testValue")]
        [DataRow("testName", null)]
        [DataRow("", "testValue")]
        [DataRow("testName", "")]

        public void FileConfig_SetConfigValue_ReturnsFalse(string name, string value)
        {
            // Arrange
            FileConfig sut = new FileConfig();

            // Act
            bool result = sut.SetConfigValue(name, value);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
