using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {

        [TestMethod]
        public void CreateLogger_CreatesLogger_Success()
        {
            // Arrange
            LogFactory testLogFactory = new LogFactory();
            testLogFactory.ConfigureFileLogger("test.txt");

            // Act
            BaseLogger testLogger = testLogFactory.CreateLogger("Test");

            // Assert
            Assert.IsNotNull(testLogger);
        }

        [TestMethod]
        public void CreateLogger_FilePath_IsNull()
        {
            // Arrange
            LogFactory testLogFactory = new LogFactory();

            // Act
            BaseLogger testLogger = testLogFactory.CreateLogger("Test");

            // Assert
            Assert.IsNull(testLogger);
        }
    }
}
