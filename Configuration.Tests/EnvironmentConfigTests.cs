using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Configuration;

namespace Configuration.Tests
{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type. Justification: I am testing what happens when someone ignores this warning
    [TestClass]
    public class EnvironmentConfigTests
    {

        [TestMethod]
        public void SetEnvironmentVariable_GivenNullVariable_ReturnsFalse()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.SetConfigValue(null, "pretty alright");

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void SetEnvironmentVariable_GivenValidVariable_ReturnsTrue()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.SetConfigValue("Custom", "pretty alright");

            //Assert
            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void SetEnvironmentVariable_GivenNullValue_ReturnsTrue()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.SetConfigValue("Custom", null);

            //Assert
            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void SetEnvironmentVariable_GivenValidValue_ReturnsTrue()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.SetConfigValue("Custom", "pretty alright");

            //Assert
            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void SetEnvironmentVariable_DoesNotPersist() //flawed by the fact that the tests have to of already run in order for this to catch a problem
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            envConfig.GetConfigValue("DoesPersist", out string? valueOutput);
            bool worked = envConfig.SetConfigValue("DoesPersist", "true");

            //Assert
            Assert.IsTrue(worked);
            Assert.AreNotEqual("true", valueOutput);
        }
    }
}
