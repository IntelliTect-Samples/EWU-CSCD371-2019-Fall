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
        [DataRow("MockConfig", "1=2", DisplayName = "MockConfig, Invalid Key")]
        public void GetAndSet_HandlesInvalidKey_ReturnsFalseAndEmptyString(string configType, string key)
        {
            // Arrange
            BaseConfig sut = ConfigFactory.Create(configType);

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
        [DataRow("MockConfig", "Key", "Value", DisplayName = "MockConfig")]
        public void GetAndSet_SavesKeyValuePair_ReturnsExpectedValueForKey(string configType, string key, string value)
        {
            // Arrange
            BaseConfig sut = ConfigFactory.Create(configType);
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
        public static BaseConfig Create(string type)
        {
            BaseConfig? config = type switch
            {
                "EnvironmentConfig" => new EnvironmentConfig(),
                "FileConfig" => new FileConfig(),
                "MockConfig" => new MockConfig(),
                _ => null,
            };

            if (config is null) throw new ArgumentException($"[{nameof(ConfigFactory)}] Unrecognized target class: {type}");

            return config;
        }
    }

    public class MockConfig : BaseConfig
    {
        private List<KeyValuePair<string, string>> _kvPairs;

        public MockConfig() => _kvPairs = new List<KeyValuePair<string, string>>();

        public override void DeleteAllConfigs() => _kvPairs.Clear();

        public override bool GetConfigValue(string name, out string? value)
        {
            if (IsInvalidKeyName(name))
            {
                value = "";
                return false;
            }

            KeyValuePair<string, string> kv = _kvPairs.Find(kv => kv.Key.Equals(name));

            // check keys match to make sure we found it (a failed find returns default values)
            if (string.Equals(kv.Key, name))
            {
                value = kv.Value;
                return true;
            }

            value = "";
            return false;
        }

        public override bool SetConfigValue(string name, string? value)
        {
            if (IsInvalidKeyName(name)) return false;

            // remove any existing matching keys
            int removed = _kvPairs.RemoveAll(kv => kv.Key.Equals(name));

            if (value != null)
            {
                // if it wasn't deletion by setting value null, add new/updated config
                _kvPairs.Add(new KeyValuePair<string, string>(name, value));

                return true;
            }
            else if (removed > 0)
            {
                // deleted a key by passing null value
                return true;
            }

            // nothing was added or removed
            return false;
        }
    }
}