using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_WroteToFile_Success()
        {
            string path = Path.GetTempFileName();
            try
            {
                // Arrange
                LogFactory testLogFactory = new LogFactory();
                testLogFactory.ConfigureFileLogger(path);
                BaseLogger testLogger = testLogFactory.CreateLogger("Test");

                // Act
                testLogger.Log(LogLevel.Debug, "Test Text");

                // Assert
                string line = File.ReadAllText(path);
                Assert.IsTrue(line.Contains("Test Text"));
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
