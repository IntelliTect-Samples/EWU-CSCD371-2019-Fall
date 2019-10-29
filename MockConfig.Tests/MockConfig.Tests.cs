using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mocks.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [DataTestMethod]
        [DataRow("name", "value")]
        [DataRow("numberOfFingers", "6")]
        public void SetConfigValue_ValidArgs_SetsValues(string name, string value)
        {
            var config = new MockConfig();

            config.SetConfigValue(name, value);

            Assert.AreEqual(config.Settings.Count, 1);
            Assert.IsNotNull(config.Settings[name]);
            Assert.AreEqual(config.Settings[name], value);
        }

        [DataTestMethod]
        [DataRow("name", "value")]
        [DataRow("numberOfFingers", "6")]
        public void GetConfigValue_ContainsSetting_GetsValues(string name, string value)
        {
            var config = new MockConfig();
            config.Settings[name] = value;

            bool success = config.GetConfigValue(name, out string? val);

            Assert.IsTrue(success);
            Assert.AreEqual(val, value);
        }

        [DataTestMethod]
        [DataRow("name")]
        [DataRow("anotherName")]
        public void GetConfigValue_AbsentSetting_ReturnsNone(string name)
        {
            var config = new MockConfig();

            bool success = config.GetConfigValue(name, out string? val);

            Assert.IsFalse(success);
            Assert.IsNull(val);
        }

        [TestMethod]
        public void GetEnumerator_HasSettings_IteratesCorrectly()
        {
            var settings = new[] { ("var1", "val1"), ("var2", "val2"), ("var3", "val3") };
            var config = new MockConfig();

            foreach (var (name, value) in settings) config.Settings[name] = value;

            foreach (var ((name, value), (readName, readValue)) in settings.Zip(config))
            {
                Assert.AreEqual(name, readName);
                Assert.AreEqual(value, readValue);
            }
        }
    }
}
