using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileIO_DefaultConstructor_OpensAndLogs()
        {
            FileLogger logger = new FileLogger();
            string logFilePath = logger.FilePath;
            try
            {
                // Arrange
                LogLevel level = LogLevel.Information;
                string message = "test";

                // Act
                logger.Log(level, message);

                // Assert
                Assert.IsFalse(string.IsNullOrEmpty(File.ReadAllText(logFilePath)));
            }
            finally
            {
                File.Delete(logFilePath);
            }
        }

        [TestMethod]
        public void FileIO_CustomPathConstructor_OpensAndLogs()
        {
            string logFilePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                FileLogger logger;
                LogLevel level = LogLevel.Information;
                string message = "test";

                // Act
                logger = new FileLogger(logFilePath);
                logger.Log(level, message);

                // Assert
                Assert.IsFalse( string.IsNullOrEmpty( File.ReadAllText(logFilePath) ));
            }
            finally
            {
                File.Delete(logFilePath);
            }
        }
    }
}
