using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Mock.Tests
{
    [TestClass]
    class MockConfigTests
    {
        [TestMethod]
        public void MockConfig_GetValue_ReturnTrue()
        {
            string nameTest = "testKey";
            string valueTest = "testValue";

            MockConfig mockConfig = new MockConfig();




            Assert.IsTrue(mockConfig.GetConfigValue(nameTest, valueTest));

        }

        [TestMethod]
        public void MockConfig_GetValue_ReturnFalse()
        {
            string nameTest = "test false name";
            string valueTest = "test false value";


            MockConfig mockConfig = new MockConfig();



            Assert.IsFalse(mockConfig.GetConfigValue(nameTest, valueTest));

        }

        [TestMethod]
        public void MockConfig_AssignValue_ReturnTrue()
        {
            string nameTest = "testKey";
            string valueTest = "testValue";


            MockConfig mockConfig = new MockConfig();

            Assert.IsTrue(mockConfig.SetConfigValue(nameTest, valueTest));

        }

        [TestMethod]
        public void MockConfig_AssignValue_ReturnFalse()
        {
            string nameTest = " ";
            string valueTest = "=";


            MockConfig mockConfig = new MockConfig();



            Assert.IsFalse(mockConfig.SetConfigValue(nameTest, valueTest));

        }


    }
}
