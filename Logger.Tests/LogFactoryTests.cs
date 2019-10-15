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
            var testLogger = logFactory.CreateLogger("FileLogger");

            //Assert
            Assert.IsTrue(testLogger is FileLogger);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LogFactory_Constructor_Invalid_ClassName()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            BaseLogger invalidLogger = logFactory.CreateLogger("SillyLogger");

            //Assert

        }


    }
}
