using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void LogFactory_createLoggerWithoutConfigure_SuccessReturnsTrue()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            BaseLogger baseLogger = logFactory.CreateLogger("SomeFile.txt");

            //Assert
            Assert.IsNull(baseLogger);
        }

        [TestMethod]
        public void LogFactory_createLogger_SuccessReturnsTrue()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            logFactory.ConfigureFileLogger("TestFile.txt");
            BaseLogger baseLogger = logFactory.CreateLogger("TestFile.txt");

            //Assert
            Assert.IsNotNull(baseLogger);
        }
    }
}