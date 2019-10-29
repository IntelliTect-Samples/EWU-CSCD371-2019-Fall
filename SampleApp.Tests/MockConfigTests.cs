using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SampleApp.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [TestMethod]
        public void GetConfigValue_ValueIsNull_ReturnsNull()
        {
            var sut = new MockConfig();
            bool validValue = sut.GetConfigValue("name", out string? value);

            Assert.IsFalse(validValue);
            Assert.IsNull(value);
        }

        [DataTestMethod]
        [DataRow ("name1", "value1")]
        [DataRow ("name2", "value2")]
        [DataRow ("name3", "value3")]
        [DataRow ("name4", "value4")]
        [DataRow ("name5", "value5")]
        public void GetConfigValue_ReturnsCorrectValue(string name, string correctValue)
        {
            var sut = new MockConfig();
            bool validValue = sut.GetConfigValue(name, out string? value);

            Assert.IsTrue(validValue);
            Assert.AreEqual(value, correctValue);
        }

        [TestMethod]
        public void ClearConfig_RemovesAllSettings()
        {
            var sut = new MockConfig();
            sut.ClearConfig();

            Assert.AreEqual(0, sut.Settings.Count);
        }
    }
}
