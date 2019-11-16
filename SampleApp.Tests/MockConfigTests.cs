using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleApp.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        // MMM Comment: Use SetConfigValue and SetConfigValue from the same test so they test each other.
        [TestMethod]
        public void SetConfigValue_BadName_ReturnsFalse()
        {
            MockConfig mockConfig = new MockConfig();
            Assert.IsFalse(mockConfig.SetConfigValue(" =", "validValue"));
        }

        [TestMethod]
        public void SetConfigValue_NullValue_ReturnsFalse()
        {
            MockConfig mockConfig = new MockConfig();
            Assert.IsFalse(mockConfig.SetConfigValue("validName", null));
        }

        [TestMethod]
        public void SetConfigValue_ValidParams_ReturnsTrue()
        {
            MockConfig mockConfig = new MockConfig();
            Assert.IsTrue(mockConfig.SetConfigValue("validName", "validValue"));
        }

        [TestMethod]
        public void GetConfigValue_BadName_ReturnsFalse()
        {
            MockConfig mockConfig = new MockConfig();
            Assert.IsFalse(mockConfig.GetConfigValue(" =", out string? _));
        }

        [TestMethod]
        public void GetConfigValue_BadName_ValueSetToNull()
        {
            MockConfig mockConfig = new MockConfig();
            mockConfig.GetConfigValue(" =", out string? value);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void GetConfigValue_ValidParams_ReturnsTrue()
        {
            MockConfig mockConfig = new MockConfig();
            mockConfig.SetConfigValue("test", "test");
            Assert.IsTrue(mockConfig.GetConfigValue("test", out string? _));
        }

        [TestMethod]
        public void GetConfigValue_ValidParams_ReturnsCorrectValue()
        {
            MockConfig mockConfig = new MockConfig();
            mockConfig.SetConfigValue("testName", "testValue");
            mockConfig.GetConfigValue("testName", out string? value);
            string NonNullValue = value ?? "";
            Assert.IsTrue(NonNullValue.Equals("testValue"));
        }
    }
}