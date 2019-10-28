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
            sut.CleanUp();

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

        [DataTestMethod]
        [DataRow(null, DisplayName = "Null Key")]
        [DataRow("", DisplayName = "Empty Key")]
        [DataRow(" ", DisplayName = "White Space Key")]
        [DataRow("1=2", DisplayName = "Malformed Key")]
        public void GetAndSet_HandlesMalformedKey_ReturnsFalseAndEmptyString(string key)
        {
            // Arrange
            var sut = new EnvironmentConfig();
            const string VALUE = "irrelevant";
            bool setSuccess, getSuccess;

            // Act
            setSuccess = sut.SetConfigValue(key, VALUE);
            getSuccess = sut.GetConfigValue(key, out string? sutValue);

            // Cleanup
            sut.CleanUp();

            // Assert
            Assert.IsFalse(setSuccess);
            Assert.IsFalse(getSuccess);
            Assert.AreEqual(sutValue, "");
        }
    }
}
