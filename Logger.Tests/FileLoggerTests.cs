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
            string path = Path.GetRandomFileName();
            try
            {
                // Arrange
                LogFactory testLogFactory = new LogFactory();
                testLogFactory.ConfigureFileLogger(path);
                BaseLogger testLogger = testLogFactory.CreateLogger("Test");

                // Act
                testLogger.Log(LogLevel.Debug, "Test Text");

                // Assert
                Assert.AreEqual("Test Text", File.ReadAllLines(path));
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
