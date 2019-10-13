using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_LogFactoryNotConfigured_ReturnsNull()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act

            //Assert
            Assert.IsNull(logFactory.CreateLogger("TestClass"));
        }

        [TestMethod]
        public void CreateLogger_LogFactoryConfigured_ReturnsNotNull()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            logFactory.ConfigureFileLogger("TestFile.txt");

            //Assert
            Assert.IsNotNull(logFactory.CreateLogger("TestClass"));
        }

        [TestMethod]
        public void CreateLogger_NullClassNameGiven_ReturnsNotNull()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("TestFile.txt");

            //Act
            BaseLogger logger = logFactory.CreateLogger(null);

            //Assert
            Assert.IsNotNull(logger.ClassName);
        }
    }
}
