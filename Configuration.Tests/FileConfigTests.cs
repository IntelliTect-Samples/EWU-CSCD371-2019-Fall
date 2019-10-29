using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{

    [TestClass]
    public class FileConfigTests
    {

        [DataTestMethod]
        [DataRow("setting", "value")]
        [DataRow("setting", "hyphenated-value")]
        [DataRow("setting", "\"some double-quote enclosed string value\"")]
        [DataRow("setting", "\'some single-quote enclosed string value\'")]
        public void GivenKvp_Set_CorrectlyWritesToFile(string key, string value)
        {
            var config = new FileConfig("test");

            config.SetConfigValue(key, value);

            var lines = File.ReadAllLines(config.FilePath);

            config.Delete();

            Assert.IsTrue(lines.Length == 1);
            Assert.AreEqual($"{key}={value}", lines[0]);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("key with spaces")]
        [DataRow("key=with=equals")]
        [DataRow("")]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenInvalidKey_Set_ThrowsException(string key)
        {
            var config = new FileConfig("test.settings");
            try
            {
                config.SetConfigValue(key, "value");
            } finally
            {
                config.Delete();
            }
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("value with spaces")]
        [DataRow("value=with=equals")]
        [DataRow("")]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenInvalidValue_Set_ThrowsException(string value)
        {
            var config = new FileConfig("test.settings");
            try
            {
                config.SetConfigValue("key", value);
            } finally
            {
                config.Delete();
            }
        }

        [DataTestMethod]
        [DataRow("key", "value")]
        [DataRow("hyphenated-key", "hyphenated-value")]
        [DataRow("key", "\"some double-quote enclosed string value\"")]
        [DataRow("key", "\'some single-quote enclosed string value\'")]
        public void GivenKvp_Get_ReturnsCorrectValue_AfterSet(string key, string expectedValue)
        {
            var config = new FileConfig("test.settings");
            config.SetConfigValue(key, expectedValue);

            bool check = config.GetConfigValue(key, out string? returnedValue);

            config.Delete();

            Assert.IsTrue(check);
            Assert.AreEqual(expectedValue, returnedValue);
        }

        [TestMethod]
        public void GivenKey_Get_ReturnsNullIfFileNotCreated()
        {
            var  config = new FileConfig("test.settings");
            bool isSet  = config.GetConfigValue("key", out string? value);

            config.Delete();

            Assert.IsFalse(isSet);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void GivenKey_Get_ReturnsNullIfNotSet()
        {
            var config = new FileConfig("test.settings");

            config.SetConfigValue("key", "value");

            bool isSet = config.GetConfigValue("another-key", out string? value);
            
            config.Delete();

            Assert.IsFalse(isSet);
            Assert.IsNull(value);
        }

    }

}
