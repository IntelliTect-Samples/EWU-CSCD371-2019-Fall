using Microsoft.VisualStudio.TestTools.UnitTesting;
using Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class BaseConfigTests
    {
        [DataTestMethod]
        [DataRow(null, true)]
        [DataRow("", true, DisplayName = "Empty String")]
        [DataRow(" ", true, DisplayName = "White Space")]
        [DataRow("a =b", true, DisplayName = "White Space and Equals Sign")]
        [DataRow("ValidKeyName", false, DisplayName = "Valid Name")]
        public void IsInvalidKeyName_CheckingKeyStringIsValid_ResultMatchesBooleanValidityParameter(string key, bool isInvalid)
        {
            // Arrange

            // Act
            bool sutResult = BaseConfig.IsInvalidKeyName(key);

            // Cleanup

            // Assert
            Assert.AreEqual<bool>(sutResult, isInvalid);
        }

        [DataTestMethod]
        [DataRow("EnvironmentConfig", "1=2", DisplayName = "EnvironmentConfig, Invalid Key")]
        [DataRow("FileConfig", "1=2", DisplayName = "FileConfig, Invalid Key")]
        public void GetAndSet_HandlesInvalidKey_ReturnsFalseAndEmptyString(string configType, string key)
        {
            // Arrange
            ConfigFactory.Create(configType, out BaseConfig sut);

            const string VALUE = "irrelevant";
            bool setSuccess, getSuccess;

            // Act
            setSuccess = sut.SetConfigValue(key, VALUE);
            getSuccess = sut.GetConfigValue(key, out string? sutValue);

            // Cleanup
            sut.DeleteAllConfigs();

            // Assert
            Assert.IsFalse(setSuccess);
            Assert.IsFalse(getSuccess);
            Assert.AreEqual(sutValue, "");
        }

        [DataTestMethod]
        [DataRow("EnvironmentConfig", "Key", "Value", DisplayName = "EnvironmentConfig")]
        [DataRow("FileConfig", "Key", "Value", DisplayName = "FileConfig")]
        public void GetAndSet_SavesKeyValuePair_ReturnsExpectedValueForKey(string configType, string key, string value)
        {
            // Arrange
            ConfigFactory.Create(configType, out BaseConfig sut);
            bool setSuccess, getSuccess;

            // Act
            setSuccess = sut.SetConfigValue(key, value);
            getSuccess = sut.GetConfigValue(key, out string? sutValue);

            // Cleanup
            sut.DeleteAllConfigs();

            // Assert
            Assert.IsTrue(setSuccess);
            Assert.IsTrue(getSuccess);
            Assert.AreEqual(sutValue, value);
        }
    }

    public static class ConfigFactory
    {
        public static void Create(string type, out BaseConfig config)
        {
            BaseConfig? cfg = type switch
            {
                "EnvironmentConfig" => new EnvironmentConfig(),
                "FileConfig" => new FileConfig(),
                _ => null,
            };

            if (cfg is null) throw new ArgumentException($"[{nameof(ConfigFactory)}] Unrecognized target class: {type}");

            config = cfg;
        }
    }
}