using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [TestMethod]
        public void MockConfig_SetConfigValue_GetConfigValue()
        {
            //Arrange
            string key = "TEST";
            string value = "VALUE";
            var sut = new MockConfig();

            //Act
            sut.SetConfigValue(key, value);
            bool getConfigReturn = sut.GetConfigValue(key, out string? outValue);

            //Assert
            Assert.IsTrue(getConfigReturn);
            Assert.IsNotNull(outValue);
            Assert.AreEqual(value, outValue);
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(null)]
        [DataRow("Hello World")]
        [DataRow("Hello=World")]
        public void MockConfig_GetConfigValue_BadName(string badName)
        {
            var sut = new MockConfig();

            sut.GetConfigValue(badName, out string? _);
        }


        [TestMethod]
        public void MockConfig_GetConfigValue_ConfigNotExist()
        {
            string key = "TEST";
            var sut = new MockConfig();

            //Unset any environment variable with name TEST
            sut.SetConfigValue(key, null);

            bool getConfigReturn = sut.GetConfigValue(key, out string? outValue);

            Assert.IsFalse(getConfigReturn);
            Assert.IsTrue(string.IsNullOrEmpty(outValue));
        }

        [TestMethod]
        public void MockConfig_SetConfigValue_UpdateSetting()
        {
            string key = "TEST";
            string beforeValue = "VALUE1";
            string afterValue = "VALUE2";

            var sut = new MockConfig();

            //Act
            bool beforeSet = sut.SetConfigValue(key, beforeValue);
            bool getConfigBefore = sut.GetConfigValue(key, out string? _);
            bool afterSet = sut.SetConfigValue(key, afterValue);
            bool getConfigAfter = sut.GetConfigValue(key, out string? outAfter);

            Assert.IsTrue(beforeSet);
            Assert.IsTrue(afterSet);
            Assert.IsTrue(getConfigBefore);
            Assert.IsTrue(getConfigAfter);

            Assert.AreEqual(afterValue, outAfter);

        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void MockConfig_SetConfigValue_UnsetSetting(string? testValue)
        {
            //set unset get
            string key = "TEST";
            string value = "VALUE";
            var sut = new MockConfig();

            bool setReturn = sut.SetConfigValue(key, value);
            bool unsetReturn = sut.SetConfigValue(key, testValue);
            bool getReturn = sut.GetConfigValue(key, out string? outValue);

            Assert.IsTrue(setReturn);
            Assert.IsTrue(unsetReturn);
            Assert.IsFalse(getReturn);

            Assert.IsTrue(string.IsNullOrEmpty(outValue));
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(null, "value")]
        [DataRow("", "value")]
        public void MockConfig_SetConfigValue_BadName_BadValue(string name, string value)
        {
            var sut = new MockConfig();

            sut.SetConfigValue(name, value);
        }

        [TestMethod]
        public void MockConfig_SetConfigValue_UnsetNonExistingSetting()
        {
            var sut = new MockConfig();
            string key = "TEST";

            //make sure the item doesn't exist
            sut.SetConfigValue(key, null);

            bool unsetReturn = sut.SetConfigValue(key, null);
            bool getReturn = sut.GetConfigValue(key, out string? outValue);

            Assert.IsFalse(unsetReturn);
            Assert.IsFalse(getReturn);
            Assert.IsTrue(string.IsNullOrEmpty(outValue));
        }
    }
}
