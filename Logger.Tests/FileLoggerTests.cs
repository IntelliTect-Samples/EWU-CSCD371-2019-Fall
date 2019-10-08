using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void LogMessage_DidCreateFile() {
            FileLogger fileLogger = new FileLogger("TestFile") { LoggerName = "TestLogger" };
            fileLogger.Log(LogLevel.Warning, "Test Message");
            Assert.IsTrue(File.Exists("TestFile.log"));
        }
    }
}
