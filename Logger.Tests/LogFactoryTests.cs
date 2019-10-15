using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void LogFactory_Constructor_Returns_Logger()
        {
            //Arrange

            LogFactory logFactory = new LogFactory();

            //Act
            logFactory.ConfigureFileLogger("testfile.txt");
            var testLogger = logFactory.CreateLogger("FileLogger");

            //Assert
            Assert.IsTrue(testLogger is BaseLogger);
        }

        [TestMethod]
        public void LogFactory_Constructor_Returns_FileLogger()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            logFactory.ConfigureFileLogger("testfile.txt");
            var testLogger = logFactory.CreateLogger("FileLogger");

            //Assert
            Assert.IsTrue(testLogger is FileLogger);
        }

        [TestMethod]
        public void LogFactory_Constructor_Sets_ClassNameProperty()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            logFactory.ConfigureFileLogger("testfile.txt");
            var fileLogger = logFactory.CreateLogger("FileLogger");

            Assert.AreEqual("FileLogger", fileLogger.ClassName);
        }

        [TestMethod]
        public void LogFactory_UnconfiguredFileLogger_ReturnsNull()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            var fileLogger = logFactory.CreateLogger("FileLogger");

            //Assert
            Assert.IsNull(fileLogger);
        }

    }
}
