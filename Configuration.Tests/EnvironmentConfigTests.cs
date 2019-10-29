using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{

    [TestClass]
    public class EnvironmentConfigTests
    {

        [DataTestMethod]
        [DataRow("key", "value")]
        [DataRow("another-key", "another-value")]
        public void GivenKvp_SetReturnsCorrectValue(string key, string value)
        {
            Assert.IsTrue(new EnvironmentConfig().SetConfigValue(key, value));
            Assert.AreEqual(value, Environment.GetEnvironmentVariable(key));
        }

        [DataTestMethod]
        [DataRow("key", "value")]
        [DataRow("another-key", "another-value")]
        public void GivenKey_GetReturnsCorrectValue(string key, string expectedValue)
        {
            var config = new EnvironmentConfig();
            config.SetConfigValue(key, expectedValue);

            Assert.IsTrue(config.GetConfigValue(key, out string? returned));
            Assert.AreEqual(expectedValue, returned);
        }

        [TestMethod]
        public void GivenNullValue_SetReturnFalse()
        {
            Assert.IsFalse(new EnvironmentConfig().SetConfigValue("key", null));
        }

    }

}
