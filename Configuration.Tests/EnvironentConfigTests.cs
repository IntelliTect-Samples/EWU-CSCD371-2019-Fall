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
        [DataRow("Invalid row", null)]
        [DataRow("Public", "C:\\Users\\Public")]
        public void GetEnvironment_settingExists(string name, string? value)
        {
            //Organize
            IConfig environmentConfig = new EnvironmentConfig();


            //Act
            bool environmentVariableExists = environmentConfig.GetConfigValue(name, value);
            //Assert
            Assert.IsTrue(environmentVariableExists);

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
