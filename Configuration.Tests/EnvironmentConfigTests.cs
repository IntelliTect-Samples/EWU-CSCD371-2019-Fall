using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void EnvironmentConfig_SetEnvVar_ReturnsTrue()
        {
            string name = "SomeName", value = "SomeValue", outValue;
            var sut = new EnvironmentConfig();
            Assert.IsTrue(sut.SetConfigValue(name, value));
            Assert.IsTrue(sut.GetConfigValue(name, out outValue));
            Assert.IsNotNull(outValue);
            Assert.AreEqual(value, outValue);
        }

        [TestMethod]
        public void EnvironmentConfig_AutoEnvVarCleanup()
        {
            string name = "SomeName", value = "SomeValue", outValue;
            var sut = new EnvironmentConfig();
            // Check that env var is created
            Assert.IsTrue(sut.SetConfigValue(name, value));
            Assert.IsTrue(sut.GetConfigValue(name, out outValue));
            Assert.IsNotNull(value);
            Assert.AreEqual(value, outValue);

            // Cleanup env vars manually
            // Note: this will also happen in the finalizer,
            // but we call manually to check for it
            sut.Cleanup();

            Assert.IsFalse(sut.GetConfigValue(name, out outValue));
            Assert.IsNull(outValue);
            Assert.IsNull(Environment.GetEnvironmentVariable(name));
        }
    }
}
