using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Configuration;

namespace Mock.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [TestMethod]
        public void GetConfigValue_UnsetName_ReturnsNull()
        {
            string name="SomeName";
            string? value;
            var sut = new MockConfig();
            Assert.IsFalse(sut.GetConfigValue(name, out value));
            Assert.IsNull(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("Some Value")]
        [DataRow("Some=Value")]
        [DataRow("SomeValue ")]
        public void SetConfigValue_BadConfigValue_ThrowsException(string value)
        {
            string name = "SomeName";
            var sut = new MockConfig();
            sut.SetConfigValue(name, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow("")]
        [DataRow(null)]
        public void SetConfigValue_NullConfigValue_ThrowsException(string? value)
        {
            string name = "SomeName";
            var sut = new MockConfig();
            sut.SetConfigValue(name, value);
        }
    }
}
