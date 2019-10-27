using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [DataTestMethod]
        [DataRow("myName", "value")]
        public void EnvironmentConfig_SetConfigValue_ReturnsTrue(string name, string value)
        {
            IConfig environmentConfig = new EnvironmentConfig();
            
            Assert.IsTrue(environmentConfig.SetConfigValue(name, value));
        }

        [DataTestMethod]
        [DataRow("myName", "value")]
        [DataRow("Name","ThisValue")]
        public void EnvironmentConfig_SetConfigValue_GetsCorrectValue(string name, string value)
        {
            IConfig environmentConfig = new EnvironmentConfig();

            environmentConfig.SetConfigValue(name, value);
            environmentConfig.GetConfigValue(name, out string? myValue);

            Assert.AreEqual(value, myValue);
        }

        [DataTestMethod]
        [DataRow(null, "value")]
        [DataRow("Name", null)]
        [DataRow(" ", "value")]
        [DataRow("Name", "=")]
        [DataRow("=", "value")]
        public void EnvironmentConfig_SetConfigValue_ReturnFalse(string name, string value)
        {
            Assert.IsFalse(EnvironmentConfig.IsValidInput(name, value));
        }
    }
}
