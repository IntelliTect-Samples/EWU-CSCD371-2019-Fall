using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#pragma warning disable CA1707//////////////////
namespace Configuration.Tests
{
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConfigValue_NameIsNull_ThrowsException()
        {
            var sut = new EnvironmentConfig();
            bool validValue = sut.GetConfigValue(null!, out string? value);

        }

        [TestMethod]
        public void GetConfigValue_ValueIsNull_ReturnsNull()
        {
            var sut = new EnvironmentConfig();
            string name = "TestName";
            bool validValue = sut.GetConfigValue(name, out string? value);

            Assert.IsFalse(validValue);
            Assert.IsNull(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetConfigValue_NameIsNull_ThrowsException()
        {
            var sut = new EnvironmentConfig();
            sut.SetConfigValue(null!, null);

        }

        [TestMethod]
        public void SetConfigValue_ValueIsNotNull_ReturnsValue()
        {
            string name = "TestName";
            var sut = new EnvironmentConfig();
            try
            {
                _ = sut.SetConfigValue(name, "TestValue");
                bool validValue = sut.GetConfigValue(name, out string? value);

                Assert.IsTrue(validValue);
                Assert.IsNotNull(value);
                Assert.AreEqual("TestValue", value);
            }
            finally
            {
                sut.SetConfigValue(name, null);
            }
        }
    }
}
