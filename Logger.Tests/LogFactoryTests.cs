using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_WithNoLoggerConfigured_ItReturnsNull()
        {
            // Arrange
            var sut = new LogFactory();

            // Act
            BaseLogger logger = sut.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void CreateLogger_WithFileLoggerConfigured_ItReturnsFileLogger()
        {
            // Arrange
            var sut = new LogFactory();
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            sut.ConfigureFileLogger(filePath);

            // Act
            BaseLogger logger = sut.CreateLogger(nameof(LogFactoryTests));

            // Assert
            Assert.IsTrue(logger is FileLogger);
            Assert.AreEqual(nameof(LogFactoryTests), logger.ClassName);
        }
    }
}
