using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        public void EnvironmentConfig_GetConfigValue_NonNullNameReturnsTrue()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act
            string name = "HOME", value = null;

            //Assert
            Assert.IsTrue(config.GetConfigValue(name, value));
        }

        [TestMethod]
        public void EnvironmentConfig_GetConfigValue_NonExistentNameReturnsFalse()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act
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
