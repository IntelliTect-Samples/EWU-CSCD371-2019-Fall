using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [DataTestMethod]
        [DataRow("testName1", "testValue1")]
        [DataRow("testName2", "testValue2")]
        [DataRow("testName3", "testValue3")]
        public void MockConfig_GetConfigValue_ReturnsTrue(string name, string? value)
        {
            // Arrange
            MockConfig sut = new MockConfig();

            // Act
            bool getResult = sut.GetConfigValue(name, out string? _);

            // Assert
            Assert.IsTrue(getResult);
        }

        [DataTestMethod]
        [DataRow("wrongtestName1", "testValue1")]
        [DataRow("wrongtestName2", "testValue2")]
        [DataRow("wrongtestName3", "testValue3")]
        public void MockConfig_GetConfigValue_ReturnsFalse(string name, string? value)
        {
            // Arrange
            MockConfig sut = new MockConfig();

            // Act
            bool getResult = sut.GetConfigValue(name, out string? _);

            // Assert
            Assert.IsFalse(getResult);
        }

        [DataTestMethod]
        [DataRow("testName1", "testValue1")]
        [DataRow("testName2", "testValue2")]
        [DataRow("testName3", "testValue3")]
        public void MockConfig_SetConfigValue_ReturnsTrue(string name, string? value)
        {
            // Arrange
            MockConfig sut = new MockConfig();

            // Act
            bool result = sut.GetConfigValue(name, out string? _);

            // Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow("test Name", "test Value")]
        [DataRow("test=Name", "test=Value")]
        [DataRow(null, "testValue")]
        [DataRow("testName", null)]
        [DataRow("", "testValue")]
        [DataRow("testName", "")]
        public void MockConfig_SetConfigValue_ReturnsFalse(string name, string? value)
        {
            // Arrange
            MockConfig sut = new MockConfig();

            // Act
            bool result = sut.GetConfigValue(name, out string? _);

            // Assert
            Assert.IsFalse(result);
        }

    }
}
