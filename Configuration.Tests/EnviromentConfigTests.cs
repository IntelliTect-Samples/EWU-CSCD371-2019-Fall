using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnviromentConfigTests
    {
        [TestMethod]
        public void EnvironmentConfig_GetConfigValue_ReturnsFalse()
        {
            // Arrange
            EnvironmentConfig test = new EnvironmentConfig();
            string name = "testName";

            // Act
            bool result = test.GetConfigValue(name, out string _);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EnvironmentConfig_GetConfigValue_ReturnsTrue()
        {
            // Arrange
            EnvironmentConfig test = new EnvironmentConfig();
            string name = "USERPROFILE";
            
            // Act
            bool result = test.GetConfigValue(name, out string _);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EnvironmentConfig_SetConfigValue_ReturnsFalse()
        {
            // Arrange
            EnvironmentConfig test = new EnvironmentConfig();
            string name = "testValue";
            string? value = null;

            // Act
            bool result = test.SetConfigValue(name, value);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EnvironmentConfig_SetConfigValue_ReturnsTrue()
        {
            // Arrange
            EnvironmentConfig test = new EnvironmentConfig();
            string name = "testName";
            string? value = "testValue";

            // Act
            bool result = test.SetConfigValue(name, value);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
