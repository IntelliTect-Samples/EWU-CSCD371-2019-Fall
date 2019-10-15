using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class ExceptionLoggerTests
    {
        [TestMethod]
        public void DefaultConstructor_ReturnsValidObject()
        {
            // Arrange

            // Act
            var logger = new ExceptionLogger();

            // Assert
            Assert.IsNotNull(logger);
            Assert.IsFalse(string.IsNullOrEmpty(logger.FilePath));
        }

        [TestMethod]
        public void PathConstructor_ReturnsValidObject()
        {
            // Arrange
            string path = Path.GetRandomFileName();

            // Act
            var logger = new ExceptionLogger(path);

            // Assert
            Assert.IsNotNull(logger);
            Assert.IsTrue(string.Equals(path, logger.FilePath));
        }

        [TestMethod]
        public void Logging_NullArgument_NoWrite()
        {
            string path = Path.GetRandomFileName();
            try
            {
                // Arrange
                var logger = new ExceptionLogger(path);

                // Act
                logger.Log(LogLevel.Error, null);

                // Assert
                Assert.IsFalse(File.Exists(path));
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [TestMethod]
        public void Logging_LogsException()
        {
            string path = Path.GetRandomFileName();
            try
            {
                // Arrange
                var logger = new ExceptionLogger(path);

                // Act
                logger.Log(LogLevel.Error, new System.Exception("Testing"));

                // Assert
                Assert.IsFalse(string.IsNullOrEmpty(File.ReadAllText(path)));
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
