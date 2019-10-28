using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockConfig;


#pragma warning disable CS8632 

namespace MockConfig.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [DataTestMethod]
        [DataRow("name", "value")]
        public void MockConfig_SetConfigValue_True(string name, string value)
        {
            MockConfig envConfig = new MockConfig();
            Assert.IsTrue(envConfig.SetConfigValue(name, value));
        }

        [DataTestMethod]
        [DataRow("", "value")]
        [DataRow("name", "")]
        [DataRow("name=", "")]
        [DataRow("name", "value ")]
        [DataRow("name", "value=")]
        public void MockConfig_SetConfigValue_False(string name, string value)
        {
            MockConfig envConfig = new MockConfig();

            Assert.IsFalse(envConfig.SetConfigValue(name, value));
        }

        [DataTestMethod]
        [DataRow("name", "value")]
        public void MockConfig_GetConfigValue_True(string name, string value)
        {
            MockConfig envConfig = new MockConfig();

            envConfig.SetConfigValue(name, value);

            Assert.IsTrue(envConfig.GetConfigValue(name, out string? testValue));
        }

        [DataTestMethod]
        [DataRow("=name", "value")]
        public void MockConfig_GetConfigValue_False(string name, string value)
        {

            MockConfig envConfig = new MockConfig();

            envConfig.SetConfigValue(name, value);

            Assert.IsFalse(envConfig.GetConfigValue(name, out string? testValue));

        }
    }
}
