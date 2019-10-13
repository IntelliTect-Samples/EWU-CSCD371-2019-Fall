using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {

        [TestMethod]
        public void Configure_CreatesLoggerUsingGivenPath()
        {
            // Arrange
            string targetPath = Path.GetRandomFileName();
            LogFactory factory = new LogFactory();

            // Act
            factory.ConfigureLogger(targetPath);
            FileLogger logger = (FileLogger)factory.CreateLogger("test class");

            // Assert
            Assert.IsTrue(string.Equals(logger.FilePath, targetPath));
        }

        [TestMethod]
        public void Configure_UnconfiguredReturnsNullLogger()
        {
            // Arrange
            string targetPath = Path.GetRandomFileName();
            LogFactory factory = new LogFactory();

            // Act
            BaseLogger logger = factory.CreateLogger("test class");

            // Assert
            Assert.IsNull(logger);
        }
    }
}
