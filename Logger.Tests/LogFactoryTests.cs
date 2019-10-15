using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_ConfigureWithNullPath_ThrowsException()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            logFactory.ConfigureFileLogger(null);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_ConfigureWithEmptyPath_ThrowsException()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            logFactory.ConfigureFileLogger("");

            //Assert
        }

        [TestMethod]
        public void LoggerNotConfigured()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            BaseLogger logger = logFactory.CreateLogger(null);

            //Assert
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void LoggerConfiguredCorrectly()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("Testing.txt");

            //Act
            BaseLogger logger = logFactory.CreateLogger("FileLogger");

            //Assert
            Assert.IsNotNull(logger);
            Assert.IsTrue(File.Exists("Testing.txt"));
            File.Delete("Testing.txt");
            Assert.IsFalse(File.Exists("Testing.txt"));
        }

    }
}
