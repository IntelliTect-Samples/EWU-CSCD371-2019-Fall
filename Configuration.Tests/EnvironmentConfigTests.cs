using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    class EnvironmentConfigTests
    {
        [TestMethod]
        public void EnvironmentConfig_AssignValue_ReturnTrue()
        {
            string nameTest = "test name";
            string valueTest = "test value";
            bool check;

            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            check = environmentConfig.GetConfigValue(nameTest, valueTest);

            Assert.IsTrue(check);

        }
    }
}
