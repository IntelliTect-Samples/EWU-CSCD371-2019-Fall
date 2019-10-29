using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using static SampleApp.Program;

namespace Configuration.Tests
{
    [TestClass]
    public class SampleAppTests
    {
        [TestMethod]
        public void SetConfigValue_GivenValidNameAndValue_ReturnsTrue()
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            bool worked = mockConfig.SetConfigValue("variable1", "true");

            //Assert
            Assert.IsTrue(worked);
        }

        [TestMethod]
        public void SetConfigValue_GivenInvalidName_ReturnsFalse()
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            bool worked = mockConfig.SetConfigValue("variable 1", "true");

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void SetConfigValue_GivenValidName_NullValue_ReturnsFalse()
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            bool worked = mockConfig.SetConfigValue("variable1", null);

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void GetConfigValue_GivenValidName_ReturnsTrue()
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();
            string? output;

            //Act
            mockConfig.SetConfigValue("variable1", "true");
            bool worked = mockConfig.GetConfigValue("variable1", out output);

            //Assert
            Assert.IsTrue(worked);
            Assert.AreEqual(output, "true");
        }

        [TestMethod]
        public void GetConfigValue_GivenInvalidName_ReturnsFalse()
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            bool worked = mockConfig.GetConfigValue("variable 1", out _);

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void GetConfigValue_GivenValidButUnsetName_ReturnsFalse()
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            bool worked = mockConfig.GetConfigValue("thisistexas", out _);

            //Assert
            Assert.IsFalse(worked);
        }

        [TestMethod]
        public void GetConfigValue_GivenNullName_ReturnsFalse()
        {
            //Arrange
            MockConfig mockConfig = new MockConfig();

            //Act
            bool worked = mockConfig.GetConfigValue(null, out _);

            //Assert
            Assert.IsFalse(worked);
        }
    }
}
