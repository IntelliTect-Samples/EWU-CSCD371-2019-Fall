using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnviromentConfigTests
    {
        [TestMethod]
        public void SetEnviromentVariable_Success()
        {
            //Arrange
            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            //Act
            bool result = environmentConfig.SetConfigValue("Word","Okay");

            //Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(null, "word")]
        [DataRow("word", null)]
        [DataRow("", "word")]
        [DataRow("word", "")]
        public void SetEnviromentVariable_Fails(string name, string value)
        {
            //Arrange
            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            //Act
            bool result = environmentConfig.SetConfigValue(name, value);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetConfigValue_Sucess()
        {
            //Arrange
            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            //Act
            _ = environmentConfig.SetConfigValue("Word", "Okay");
            bool result = environmentConfig.GetConfigValue("Word", "Okay");

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetConfigValue_False()
        {
            //Arrange
            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            //Act
            _ = environmentConfig.SetConfigValue("Word", "Okay");
            bool result = environmentConfig.GetConfigValue("No", "Good");

            //Assert
            Assert.IsFalse(result);
        }
    }
}
