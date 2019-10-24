using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass()]
    public class EnvironmentConfigTests
    {
        [TestMethod]

        public void EnvironmentConfig_GetConfigValue_ReturnsFalse()
        {
            //arrange
            string name = "Wrong Path Name", value = "TESTVALUE";
            EnvironmentConfig testSystem = new EnvironmentConfig();

            //act
            bool tf = testSystem.GetConfigValue(name, value);

            //assert
            Assert.IsFalse(tf);
        }

        [TestMethod]
        public void EnvironmentConfig_GetConfigValue_ReturnsTrue()
        {
            //arrange
            string name = "TEMP", value = "TESTVALUE";
            EnvironmentConfig testSystem = new EnvironmentConfig();

            //act
            bool tf = testSystem.GetConfigValue(name, value);

            //assert
            Assert.IsTrue(tf);
        }

        [TestMethod]
        public void EnvironmentConfig_SetConfigValue_ReturnsFalse()
        {
            //arrange
            string name = "Wrong Path Name";
            string? value = null;
            EnvironmentConfig testSystem = new EnvironmentConfig();

            //act
            bool tf = testSystem.SetConfigValue(name, value);

            //assert
            Assert.IsFalse(tf);
        }

        [TestMethod]
        public void EnvironmentConfig_SetConfigValue_ReturnsTrue()
        {
            //arrange
            string name = "TEMP", value = "TESTVALUE";
            EnvironmentConfig testSystem = new EnvironmentConfig();

            //act
            bool tf = testSystem.SetConfigValue(name, value);

            //assert
            Assert.IsTrue(tf);
        }
    }
}
