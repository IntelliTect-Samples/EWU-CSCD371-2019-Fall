using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironentConfigTests
    {
        [TestMethod]
        [DataRow("ProgramData", "C:\\ProgramData")]
        [DataRow("Public", "C:\\Users\\Public")]
        public void GetEnvironment_settingExists(string name, string value)
        {
            //Organize
            IConfig environmentConfig = new EnvironmentConfig();

            //Act
            bool environmentVariableExists = environmentConfig.GetConfigValue(name, out string? outValue);

            //Assert
            Assert.IsTrue(environmentVariableExists);
            Assert.IsNotNull(outValue);
            Assert.AreEqual(outValue, value);
        }

        [TestMethod]
        [DataRow("Invalid Row", null)]
        public void GetEnvironment_InvalidSettingDoesNotExist(string name, string? value)
        {
            //Organize
            IConfig environmentConfig = new EnvironmentConfig();

            //Act
            bool environmentVariableExists = environmentConfig.GetConfigValue(name, out string? outValue);

            //Assert
            Assert.IsFalse(environmentVariableExists);
            Assert.IsNull(outValue);
            Assert.AreEqual(outValue, value);
        }

        [TestMethod]
        [DataRow("Test", "hello")]
        [DataRow("ProgramData", "C:\\ProgramData2")]
        [DataRow("Invalid row", null)]
        public void SetEnvironment_SetsNewVariable(string name, string? value)
        {
            //Organize
            IConfig environmentConfig = new EnvironmentConfig();
            //Act
            environmentConfig.SetConfigValue(name, value);
            //Assert
            Assert.AreEqual(value, Environment.GetEnvironmentVariable(name));
        }
    }
}
