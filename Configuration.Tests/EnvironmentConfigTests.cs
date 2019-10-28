using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [DataTestMethod]
        [DataRow("key", "value", DisplayName = "Valid K:V pair")]
        public void Cleanup_RemovesEnvironmentKeyValue_NullEnvironmentVariables(string key, string value)
        {
            // Arrange
            var sut = new EnvironmentConfig();

            // Act
            sut.SetConfigValue(key, value);
            sut.DeleteAllConfigs();

            string? envVar = Environment.GetEnvironmentVariable(key);

            // Cleanup
            Environment.SetEnvironmentVariable(key, null);

            // Assert
            Assert.IsNull(envVar);
        }

        [DataTestMethod]
        [DataRow("key","value", DisplayName = "Valid K:V pair")]
        public void Set_StoresEnvironmentKeyValue_EnvironmentValueSameAsInput(string key, string value)
        {
            // Arrange
            var sut = new EnvironmentConfig();

            // Act
            sut.SetConfigValue(key, value);
            string? sutValueSet = Environment.GetEnvironmentVariable(key);

            // Cleanup
            Environment.SetEnvironmentVariable(key, null);

            // Assert
            Assert.AreEqual(sutValueSet, value);
        }

        [DataTestMethod]
        [DataRow("key", "value", DisplayName = "Valid K:V pair")]
        public void Get_LoadsEnvironmentKeyValue_TestValueSameAsInput(string key, string value)
        {
            // Arrange
            var sut = new EnvironmentConfig();

            // Act
            Environment.SetEnvironmentVariable(key, value);
            sut.GetConfigValue(key, out string? sutValue);

            // Cleanup
            Environment.SetEnvironmentVariable(key, null);

            // Assert
            Assert.AreEqual(sutValue, value);
        }
    }
}
