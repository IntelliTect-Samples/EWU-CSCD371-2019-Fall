using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{

    [TestClass]
    public class MockConfigTests
    {

        [DataTestMethod]
        [DataRow("setting", "value")]
        [DataRow("setting", "hyphenated-value")]
        [DataRow("setting", "\"some double-quote enclosed string value\"")]
        [DataRow("setting", "\'some single-quote enclosed string value\'")]
        public void GivenKvp_Set_CorrectlySavesSetting(string key, string expectedValue)
        {
            var mock = new MockConfig();

            mock.SetConfigValue(key, expectedValue);

            Assert.IsTrue(mock.GetConfigValue(key, out string? returnedValue));
            Assert.AreEqual(expectedValue, returnedValue);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("key with spaces")]
        [DataRow("key=with=equals")]
        [DataRow("")]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenInvalidKey_Set_ThrowsException(string key)
        {
            var mock = new MockConfig();
            mock.SetConfigValue(key, "value");
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("value with spaces")]
        [DataRow("value=with=equals")]
        [DataRow("")]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenInvalidValue_Set_ThrowsException(string value)
        {
            var mock = new MockConfig();
            mock.SetConfigValue("key", value);
        }

        [DataTestMethod]
        [DataRow("key", "value")]
        [DataRow("hyphenated-key", "hyphenated-value")]
        [DataRow("key", "\"some double-quote enclosed string value\"")]
        [DataRow("key", "\'some single-quote enclosed string value\'")]
        public void GivenKvp_Get_ReturnsCorrectValue_AfterSet(string key, string expectedValue)
        {
            var mock = new MockConfig();
            mock.SetConfigValue(key, expectedValue);

            bool check = mock.GetConfigValue(key, out string? returnedValue);

            Assert.IsTrue(check);
            Assert.AreEqual(expectedValue, returnedValue);
        }

        [TestMethod]
        public void GivenKey_Get_ReturnsNullIfNotSet()
        {
            var mock = new MockConfig();

            mock.SetConfigValue("key", "value");

            bool isSet = mock.GetConfigValue("another-key", out string? value);

            Assert.IsFalse(isSet);
            Assert.IsNull(value);
        }

    }

}
