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
        public void SetConfigValue_GivenNullVariable_ReturnsFalse()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.SetConfigValue(null, "pretty alright");

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void SetConfigValue_GivenValidVariable_ReturnsTrue()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.SetConfigValue("Custom", "pretty alright");

            //Assert
            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void SetConfigValue_GivenNullValue_ReturnsTrue()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.SetConfigValue("Custom", null);

            //Assert
            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void SetConfigValue_GivenValidValue_ReturnsTrue()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.SetConfigValue("Custom", "pretty alright");

            //Assert
            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void SetConfigValue_DoesNotPersist() //flawed by the fact that the tests have to of already run in order for this to catch a problem
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

        [TestMethod]
        public void GetConfigValue_GivenExistingVariable_ReturnsTrue()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.GetConfigValue("SystemDrive", out string? _);

            //Assert
            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void GetConfigValue_GivenNonexistentVariable_ReturnsFalse()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.GetConfigValue("TexasThisWillNeverBeAVariableByChance", out string? _);

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void GetConfigValue_GivenNullVariable_ReturnsFalse()
        {
            //Arrange
            IConfig envConfig = new EnvironmentConfig();

            //Act
            bool worked = envConfig.GetConfigValue(null, out string? _);

            //Assert
            Assert.IsFalse(worked);
        }
    }
}
