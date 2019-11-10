using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Configuration.Tests
{
    [TestClass]
    public class ConfigTests
    {
        [TestMethod]
        public void Config_SetConfig_ReturnsTrue()
        {
            var sut = new Config();
            string name="SomeName", value="SomeValue";
            Assert.IsTrue(sut.SetConfigValue(name, value));
            // MMM Comment: Call GetConfigValue() here and assert the result matches set.
        }

        [TestMethod]
        public void Config_GetConfig_ReturnsFalseOnNoValue()
        {
            var sut = new Config();
            string name="SomeName";
            string? value="SomeValue";
            Assert.IsFalse(sut.GetConfigValue(name, out value));
        }
    }
}
