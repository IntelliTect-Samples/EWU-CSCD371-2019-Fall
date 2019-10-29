using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [DataTestMethod]
        [DataRow("TestKey", "TestValue")]
        [DataRow("ABC", "DEF")]
        [DataRow("123", "456")]
        public void GetConfigValue_ReturnsTrue(string name, string expectedValue)
        {
            IConfig sut = new EnvironmentConfig();
            string? value;


            sut.SetConfigValue(name, expectedValue);
            bool hasConfiguration = sut.GetConfigValue(name, out value);

            Assert.IsTrue(hasConfiguration);
            Assert.AreEqual(expectedValue, value);
        }

        [DataTestMethod]
        [DataRow("TestKey", "TestValue")]
        [DataRow("ABC", "DEF")]
        [DataRow("123", "456")]
        public void SetConfigValue_ReturnsTrue(string name, string value) 
        {
            IConfig sut = new EnvironmentConfig();

            bool isConfigured = sut.SetConfigValue(name, value);

            Assert.IsTrue(isConfigured);
        }

        [DataTestMethod]
        [DataRow("Invalid Key", "TestValue")]
        [DataRow("ABC", "D=E=F")]
        [DataRow("", "456")]
        [DataRow(" ", "789")]
        [ExpectedException(typeof(ArgumentException))]
        public void SetConfigValue_ThrowsException_InvalidCharacters(string name, string value)
        {
            IConfig sut = new EnvironmentConfig();

            bool isConfigured = sut.SetConfigValue(name, value);
        }
    }
}
