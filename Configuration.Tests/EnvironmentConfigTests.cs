using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConfigValueNullNameThrowsException()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            string? value;
            //Act
            config.GetConfigValue(null, out value);

            //Assert
        }

        [TestMethod]
        public void GetConfigValueGoodNameNullValue()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            config.SetConfigValue("Name", null);
            string? value;

            //Act

            //Assert
            Assert.IsFalse(config.GetConfigValue("Name", out value));
        }

        [TestMethod]
        public void GetConfigValueGoodParameters()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            config.SetConfigValue("Name", "Value");
            
            string? value;

            //Act

            //Assert
            Assert.IsTrue(config.GetConfigValue("Name", out value));
            Assert.AreEqual(value, "Value");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetConfigValueNullNameThrowsException()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act
            config.SetConfigValue(null, "true");

            //Assert
        }

        [TestMethod]
        public void SetConfigValueGoodName()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act

            //Assert
            Assert.IsTrue(config.SetConfigValue("Name", "Value"));
         }

        [TestMethod]
        public void SetConfigGoodParameters()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            string? value;

            //Act
            config.SetConfigValue("Name", "Value");

            //Assert
            Assert.IsTrue(config.GetConfigValue("Name", out value));
        }
    }
}
