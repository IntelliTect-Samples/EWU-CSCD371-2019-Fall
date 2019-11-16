using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class MockConfigTests
    {

        [DataTestMethod]
        [DataRow(null,"word")]
        [DataRow("word", null)]
        [DataRow("", "word")]
        [DataRow("word", "")]
        [DataRow("wo=rd", "word")]
        [DataRow("word", "wo=rd")]
        [DataRow("wo rd", "word")]
        [DataRow("word", "wo rd")]
        public void SetConfigValue_Fails(string name, string value)
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            bool result = mockConfig.SetConfigValue(name, value);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetConfigValue_Success()
        {
            //Arrange 
            MockConfig mockConfig = new MockConfig();

            //Act
            bool result = mockConfig.SetConfigValue("word", "more");

            //Assert
            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(null, "word")]
        [DataRow("word", null)]
        [DataRow("", "word")]
        [DataRow("word", "")]
        [DataRow("wo=rd", "word")]
        [DataRow("word", "wo=rd")]
        [DataRow("wo rd", "word")]
        [DataRow("word", "wo rd")]
        public void GetConfigValue_Fails_DataError(string name, string value)
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            bool result = mockConfig.GetConfigValue(name, value);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetConfigValue_FailsDidNotExist()
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            bool result = mockConfig.GetConfigValue("hello", "hhh");

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetConfigValue_Success()
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            _ = mockConfig.SetConfigValue("hello", "word");
            bool result = mockConfig.GetConfigValue("hello", "word");

            //Assert
            Assert.IsTrue(result);
        }
    }
}
