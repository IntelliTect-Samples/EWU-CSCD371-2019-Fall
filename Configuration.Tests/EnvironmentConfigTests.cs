using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        public void CreateEnvironmentConfig_EmptyConstructor_NoErrors()
        {
            _ = new EnvironmentConfig();
        }

        [TestMethod]
        public void GetConfigValue_NameIsWinDir_ReturnsTrue()
        {
            EnvironmentConfig test = new EnvironmentConfig();
            Assert.IsTrue(test.GetConfigValue("windir", out _));
        }

        [TestMethod]
        public void GetConfigValue_InvalidName_ReturnsNullValue()
        {
            EnvironmentConfig test = new EnvironmentConfig();
            test.GetConfigValue(" =", out string? value);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void GetConfigValue_InvalidName_ReturnsFalse()
        {
            EnvironmentConfig test = new EnvironmentConfig();
            Assert.IsFalse(test.GetConfigValue(" =", out _));
        }

        [TestMethod]
        public void SetConfigValue_NullValue_ReturnsFalse()
        {
            EnvironmentConfig test = new EnvironmentConfig();
            Assert.IsFalse(test.SetConfigValue("validName", null));
        }

        [TestMethod]
        public void SetConfigValue_InvalidName_ReturnsFalse()
        {
            EnvironmentConfig test = new EnvironmentConfig();
            Assert.IsFalse(test.SetConfigValue(" =", null));
        }
    }
}