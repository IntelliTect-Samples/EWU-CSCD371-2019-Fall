using Microsoft.VisualStudio.TestTools.UnitTesting;
using Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class ExtensionIConfigTests
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
            FakeIConfig fakeConfig = new FakeIConfig();

            // Act
            bool sutResult = fakeConfig.IsInvalidKeyName(key);

            // Cleanup

            // Assert
            Assert.AreEqual<bool>(sutResult, isInvalid);
        }
    }

    public class FakeIConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value) => false;
    }
}