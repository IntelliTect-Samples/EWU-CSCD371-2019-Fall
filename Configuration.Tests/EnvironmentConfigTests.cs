<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
=======
using System;
>>>>>>> Assignment4
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
<<<<<<< HEAD
        private static IEnumerable<object[]> InValidName =>
        new List<object[]> {
        new object[] { "name 1", "goodValue" },
        new object[] { "name=2", "alsoGoodValue" },
        new object[] { string.Empty, "lastGoodValue"}
        };

        private static IEnumerable<object[]> ValidSettings =>
        new List<object[]> {
        new object[] { "name1", "goodValue" },
        new object[] { "name2", "alsoGoodValue" },
        new object[] { "Name_3", "lastGoodValue"}
        };

        [TestMethod]
        public void ReadConfigValue_NonNullName_ReturnsTrue()
=======
        [TestMethod]
        public void EnvironmentConfig_GetConfigValue_NonNullNameReturnsTrue()
>>>>>>> Assignment4
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act
<<<<<<< HEAD
            string name = "HOME";

            //Assert
            Assert.IsTrue(config.ReadConfigValue(name, out string? value));
            Assert.AreEqual(Environment.GetEnvironmentVariable(name), value);
        }

        [TestMethod]
        public void ReadConfigValue_UnSetName_ReturnsFalse()
=======
            string name = "HOME", value = null;

            //Assert
            Assert.IsTrue(config.GetConfigValue(name, value));
        }

        [TestMethod]
        public void EnvironmentConfig_GetConfigValue_NonExistentNameReturnsFalse()
>>>>>>> Assignment4
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act
<<<<<<< HEAD
            string name = "randomName";

            //Assert
            Assert.IsFalse(config.ReadConfigValue(name, out string? value));
            Assert.IsNull(value);
        }

        [TestMethod]
        [DynamicData(nameof(InValidName))]
        public void WriteConfigValue_UnacceptableParameters_ReturnsFalse(string name, string value)
        {
            EnvironmentConfig config = new EnvironmentConfig();

           
            Assert.IsFalse(config.WriteConfigValue(name, value));
#nullable disable
            Assert.IsFalse(config.WriteConfigValue(null, value));
#nullable enable
        }

        [TestMethod]
        [DynamicData(nameof(ValidSettings))]
        public void WriteConfigValue_AcceptableParamter_ReturnsTrue_returnsValue(string name, string value)
        {
            
            EnvironmentConfig config = new EnvironmentConfig();

            Assert.IsTrue(config.WriteConfigValue(name, value));
            Assert.AreEqual(Environment.GetEnvironmentVariable(name), value);
        }
    }

}
=======
            string name = "", value = "Some value";

            //Assert
            Assert.IsFalse(config.GetConfigValue(name, value));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void EnvironmentConfig_SetConfigValue_UnacceptableParametersReturnsFalse()
        {
            //Arrange
            EnvironmentConfig config1 = new EnvironmentConfig();
            EnvironmentConfig config2 = new EnvironmentConfig();
            EnvironmentConfig config3 = new EnvironmentConfig();
            EnvironmentConfig config4 = new EnvironmentConfig();

            //Act
            string? name1 = null, value1 = "Somevalue";
            string? name2 = "Some Name", value2 = "Somevalue";
            string? name3 = "", value3 = "Somevalue";
            string? name4 = "=someName", value4 = "Somevalue";

            //Assert
            Assert.IsFalse(config1.SetConfigValue(name1, value1));
            Assert.IsFalse(config2.SetConfigValue(name2, value2));
            Assert.IsFalse(config3.SetConfigValue(name3, value3));
            Assert.IsFalse(config4.SetConfigValue(name4, value4));
        }

        [TestMethod]
        public void EnvironmentConfig_SetConfigValue_AcceptableParamterReturnsTrue()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            
            //Act
            string name = "SomeName", value = "SomeValue";

            //Assert
            Assert.IsTrue(config.SetConfigValue(name, value));
        }

        [TestMethod]
        public void EnvironmentConfig_DeleteCreatedVariables_ReturnsTrueIfDeleted()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            config.SetConfigValue("NewVariable", "Value");

            //Act
            config.DeleteCreatedVariables();
            var variable = Environment.GetEnvironmentVariable("NewVariable");

            //Assert
            Assert.IsNull(variable);
        }
    }

}
>>>>>>> Assignment4
