using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            string name = "SomeName", value = "SomeValue";
            string? outValue = null;

            var sut = new TestConfig();
            sut.SetConfigValue(name, value);

            Assert.IsTrue(sut.GetConfigValue(name, out outValue));
            Assert.IsNotNull(outValue);
            Assert.AreEqual(value, outValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IConfig_SetConfigValue_ThrowsErrorOnNullValue()
        {
            var sut = new TestConfig();

            string? config = null;
            sut.SetConfigValue("SomeName", config);
        }
    }

    public class TestConfig : IConfigTests
    {
        private Dictionary<string, string?> ConfigValue;

        public TestConfig() =>
            ConfigValue = new Dictionary<string, string?>();

        public bool GetConfigValue(string name, out string? value)
        {
            if (!ConfigValue.ContainsKey(name))
            {
                value = null;
                return false;
            } else {
                value = ConfigValue[name];
                return true;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException($"Cannot pass null config for {nameof(value)}.");
            ConfigValue[name] = value;
            return true;
        }
    }
}
