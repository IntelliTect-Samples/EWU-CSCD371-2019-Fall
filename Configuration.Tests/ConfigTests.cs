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
        public void EnvironmentConfig_GivenKvp_ReturnsCorrectGetSetValue(string key, string value)
        {
            var environment = new EnvironmentConfig();

            bool set = environment.SetConfigValue(key, value);
            bool get = environment.GetConfigValue(key, out string? str);

            Assert.IsTrue(set);
            Assert.IsTrue(get);
            Assert.AreEqual(value, str);
        }

        [DataTestMethod]
        [DataRow("key", "value")]
        [DataRow("another-key", "another-value")]
        public void FileConfig_GivenKvp_CorrectlyWritesSettingsToFile(string key, string value)
        {
            var config = new FileConfig();
        }

    }

}
