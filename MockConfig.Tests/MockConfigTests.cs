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
        [DataRow("SomeName", "Some Value")]
        [DataRow("SomeName", "Some=Value")]
        [DataRow("SomeName", "SomeValue ")]
        public void SetConfigValue_BadConfigValue_ThrowsException(string name, string value)
        {
            var sut = new MockConfig();
            sut.SetConfigValue(name, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow("SomeName", "")]
        [DataRow("SomeName", null)]
        public void SetConfigValue_NullConfigValue_ThrowsException(string name, string? value)
        {
            var sut = new MockConfig();
            sut.SetConfigValue(name, value);
        }
    }
}
