using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Configuration.Tests
{
    [TestClass]
    public class MockConfigTests
    {
        [DataTestMethod]
        [DataRow("name", "value")]
        [DataRow("name2", "value2")]
        public void WriteConfigValue_ValidSettings_SetsValues(string name, string value)
        {
            MockConfig config = new MockConfig();

            Assert.IsTrue(config.WriteConfigValue(name, value));
            Assert.AreEqual(Environment.GetEnvironmentVariable(name), value);
        }
        [TestMethod]
        [DataRow("bad name", "value")]
        [DataRow("bad=name", "value")]
        public void WriteConfigValue_UnacceptableParameters_ReturnsFalse(string name, string value)
        {
            EnvironmentConfig config = new EnvironmentConfig();


            Assert.IsFalse(config.WriteConfigValue(name, value));
#nullable disable
            Assert.IsFalse(config.WriteConfigValue(null, value));
#nullable enable
        }

        [TestMethod]
        public void ReadConfigValue_UnSetName_ReturnsFalse()
        {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();

            //Act
            string name = "randomName";

            //Assert
            Assert.IsFalse(config.ReadConfigValue(name, out string? value));
            Assert.IsNull(value);
        }

        [TestMethod]
        [DataRow("goodName", "value")]
        public void ReadConfigValue_NonNullName_ReturnsTrue(string name, string value)
        {
            try
            {
                Environment.SetEnvironmentVariable(name, value);

                bool success = new EnvironmentConfig().ReadConfigValue(name, out var val);
                Assert.IsTrue(success);
                Assert.AreEqual(val, value);
            }
            finally
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }
    }
}
