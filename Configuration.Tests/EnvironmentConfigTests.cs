using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
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
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act
            string name = "HOME";

            //Assert
            Assert.IsTrue(config.ReadConfigValue(name, out string? value));
            Assert.AreEqual(Environment.GetEnvironmentVariable(name), value);
        }

        [TestMethod]
        public void ReadConfigValue_UnSetName_ReturnsFalse()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act
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