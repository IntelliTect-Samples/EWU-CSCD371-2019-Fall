using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        /*
        [TestMethod]
        public void BaseTest()
        {
            try
            {
                // Arrange
                // Act
                // Assert
            }
        }
        */

        [TestMethod]
        public void FileIO_OpensAndLogs()
        {
            FileLogger logger;
            string logFilePath = Path.GetRandomFileName();
            try
            {
                // Arrange
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
