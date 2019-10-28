using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        public void GetConfig_WithNullName()
        {
            //Arrange
            EnvironmentConfig environmentConfig = new EnvironmentConfig();
            bool getEnvVar;
            string? value = null;

            //Act
            getEnvVar = environmentConfig.GetConfigValue(null, out value);

            //Assert
            Assert.IsFalse(getEnvVar);
        }

        [TestMethod]
        public void SetConfig_WithNullName()
        {
            //Arrange
            EnvironmentConfig environmentConfig = new EnvironmentConfig();
            bool setEnvVar;

            //Act
            setEnvVar = environmentConfig.SetConfigValue(null, null);

            //Assert
            Assert.IsFalse(setEnvVar);
        }
        
        [TestMethod]
        public void SetConfig_Then_GetConfig()
        {
            //Arrange
            EnvironmentConfig environmentConfig = new EnvironmentConfig();
            bool getEnvVar, setEnvVar;
            string? getValue = null, setValue = "data";

            //Act
            setEnvVar = environmentConfig.SetConfigValue("Key1", setValue);
            getEnvVar = environmentConfig.GetConfigValue("Key1", out getValue);

            //Assert
            Assert.IsTrue(setEnvVar);
            Assert.IsTrue(getEnvVar);
            Assert.IsNotNull(getValue);
            Assert.AreEqual("data", getValue);


        }

    }
}
