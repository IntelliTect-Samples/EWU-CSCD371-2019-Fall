using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void LogMessage_DidCreateFile() {
            string fileName = "TestFile";
            FileLogger fileLogger = new FileLogger(fileName) { LoggerName = "TestLogger" };
            fileLogger.Log(LogLevel.Warning, "Test Message");
            Assert.IsTrue(File.Exists($"{fileName}.log"));
            File.Delete($"{fileName}.log");
        }
    }
}
