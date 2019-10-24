using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockConfig;

namespace MockConfig.Tests
{
    [TestClass()]
    public class MockConfigTests
    {
        [TestMethod]
        public void MockConfig_GetConfigValue_ReturnsFalse()
        {
            //arrange
            string name = "Wrong Path Name", value = "TESTVALUE";
            MockConfig testSystem = new MockConfig();

            //act
            bool tf = testSystem.GetConfigValue(name, value);

            //assert
            Assert.IsFalse(tf);
        }

        [DataTestMethod]
        [DataRow("NAME1", "TESTVALUE")]
        [DataRow("NAME2", "TESTVALUE")]
        [DataRow("NAME3", "TESTVALUE")]
        [DataRow("NAME4", "TESTVALUE")]
        public void MockConfig_GetConfigValue_ReturnsTrue(string name, string value)
        {
            //arrange
            MockConfig testSystem = new MockConfig();

            //act
            bool tf = testSystem.GetConfigValue(name, value);

            //assert
            Assert.IsTrue(tf);
        }

        [DataTestMethod]
        [DataRow("NAME5", "Not Valid")]
        [DataRow("NAME5", null)]
        [DataRow("NAME5", "NOT=VALID")]
        [DataRow("NAME5", "")]
        public void MockConfig_SetConfigValue_ReturnsFalse(string name, string value)
        {
            //arrange
            MockConfig testSystem = new MockConfig();

            //act
            bool tf = testSystem.SetConfigValue(name, value);

            //assert
            Assert.IsFalse(tf);
        }

        [DataTestMethod]
        [DataRow("NAME5", "VALUE5")]
        [DataRow("NAME6", "VALUE6")]
        [DataRow("NAME7", "VALUE7")]
        [TestMethod]
        public void MockConfig_SetConfigValue_ReturnsTrue(string name, string value)
        {
            //arrange
            MockConfig testSystem = new MockConfig();

            //act
            bool tf = testSystem.SetConfigValue(name, value);

            //assert
            Assert.IsTrue(tf);
        }
    }
}