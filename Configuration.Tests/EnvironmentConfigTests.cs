using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    // MMM Comment: Wait, this is private.  How did you ever run your tests?
    [TestClass]
    public class EnvironmentConfigTests
    {
        [TestMethod]
        public void EnvironmentConfig_GetValue_ReturnTrue()
        {
            string nameTest = "test name";
            string valueTest = "test value";
            bool check;

            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            check = environmentConfig.GetConfigValue(nameTest, valueTest);

            Assert.IsTrue(check);

        }

        [TestMethod]
        public void EnvironmentConfig_GetValue_ReturnFalse()
        {
            string nameTest = "test name";
            string valueTest = "test value";
            bool check;

            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            check = environmentConfig.GetConfigValue(nameTest, valueTest);

            Assert.IsFalse(check);

        }

        [TestMethod]
        public void EnvironmentConfig_AssignValue_ReturnTrue()
        {
            string nameTest = "test name";
            string valueTest = "test value";
            bool check;

            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            check = environmentConfig.SetConfigValue(nameTest, valueTest);

            Assert.IsTrue(check);

        }

        [TestMethod]
        public void EnvironmentConfig_AssignValue_ReturnFalse()
        {
            string nameTest = "test name";
            string valueTest = "test value";
            bool check;

            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            check = environmentConfig.SetConfigValue(nameTest, valueTest);

            Assert.IsFalse(check);

        }


    }
}
