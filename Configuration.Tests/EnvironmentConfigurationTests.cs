using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CA1707

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigurationTests
    {
        [DataTestMethod]
        [DataRow("name", "value")]
        public void EnvironmentConfig_SetConfigValue_True(string name, string value)
        {
            IConfig envConfig = new EnvironmentConfig();
            Assert.IsTrue(envConfig.SetConfigValue(name, value));
        }

        [DataTestMethod]
      
        [DataRow("", "value")]
        [DataRow("name", "")]
        [DataRow("name=", "")]
        [DataRow("name", "value ")]
        [DataRow("name", "value=")]
        public void EnvironmentConfig_SetConfigValue_False(string name, string value)
        {
            IConfig envConfig = new EnvironmentConfig();

            Assert.IsFalse(envConfig.SetConfigValue(name, value));
        }

        [DataTestMethod]
        [DataRow("name", "value")]
        public void EnvironmentConfig_GetConfigValue_True(string name, string value)
        {
            IConfig envConfig = new EnvironmentConfig();

            envConfig.SetConfigValue(name, value);

            Assert.IsTrue(envConfig.GetConfigValue(name, out string? testValue));
        }

        [DataTestMethod]
        [DataRow("=name", "value")]
        public void EnvironmentConfig_GetConfigValue_False(string name, string value)
        {
            IConfig envConfig = new EnvironmentConfig();

            envConfig.SetConfigValue(name, value);

            Assert.IsFalse(envConfig.GetConfigValue(name, out string? testValue));
        }
    }
}
