using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        public void EnvironmentConfig_GetEnvVar_IsNull()
        {
            string name = "SomeName", value;
            var sut = new EnvironmentConfig();
            Assert.IsFalse(sut.GetConfigValue(name, out value));
            Assert.IsNull(value);
        }

        [TestMethod]
        public void EnvironmentConfig_GetEnvVar_IsNotNull()
        {
            string name = "PATH", value;
            var sut = new EnvironmentConfig();
            Assert.IsTrue(sut.GetConfigValue(name, out value));
            Assert.IsNotNull(value);
        }
    }
}
