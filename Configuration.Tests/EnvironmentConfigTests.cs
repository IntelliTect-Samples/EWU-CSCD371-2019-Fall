﻿using System;
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
        public void GetConfigValue_NullName_ThrowsException()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            string? value;
            //Act
            config.GetConfigValue(null, out value);

            //Assert
        }

        [TestMethod]
        public void GetConfigValue_GoodName_NullValue()
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
        public void GetConfigValue_GoodParameters()
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
        public void SetConfigValue_NullName_ThrowsException()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act
            config.SetConfigValue(null, "true");

            //Assert
        }


    }
}
