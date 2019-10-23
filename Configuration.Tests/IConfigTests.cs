using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
    [TestClass]
    public class IConfigTests
    {
        [TestMethod]
        public void IConfig_GetConfigValue_GetsNull()
        {
            var sut = new TestConfig();
            string? config = null;
            Assert.IsFalse(sut.GetConfigValue("SomeName", out config));
            Assert.IsNull(config);
        }
        
        [TestMethod]
        public void IConfig_GetConfigValue_GetsNotNull()
        {
            var sut = new TestConfig() { ConfigValue = "SomeValue" };
            string? config = null;
            Assert.IsTrue(sut.GetConfigValue("SomeName", out config));
            Assert.IsNotNull(config);
            Assert.AreEqual("SomeValue", config);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IConfig_SetConfigValue_ThrowsErrorOnNullValue()
        {
            var sut = new TestConfig() { ConfigValue = "SomeValue" };
            string? config = null;
            sut.SetConfigValue("SomeName", config);
        }
    }

    public class TestConfig : IConfigTests
    {
        public string? ConfigValue { get; set; }

        public bool GetConfigValue(string name, out string? value)
        {
            if (ConfigValue is null)
            {
                value = null;
                return false;
            } else {
                value = ConfigValue;
                return true;
            }
        }

        public bool SetConfigValue(string name, string value)
        {
            if (value is null) throw new ArgumentNullException();
            ConfigValue = value;
            return true;
        }
    }
}
