using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void LogMessage_DidCreateFile_Success() {
            string fileName = "TestFile";
            FileLogger fileLogger = new FileLogger(fileName) { LoggerName = "TestLogger" };
            fileLogger.Log(LogLevel.Warning, "Test Message");
            Assert.IsTrue(File.Exists($"{fileName}.log"));
            File.Delete($"{fileName}.log");
        }

        [TestMethod]
        public void LogMessage_DidFormatLogMessage_Correct()
        {
            string fileName = "TestFile";
            FileLogger fileLogger = new FileLogger(fileName) { LoggerName = "TestLogger" };
            fileLogger.Log(LogLevel.Warning, "Test Message");
            fileLogger.Log(LogLevel.Error, "Test Message");
            fileLogger.Log(LogLevel.Information, "Test Message");
            fileLogger.Log(LogLevel.Debug, "Test Message");
            foreach (line in File.ReadLines($"{fileName}.log")) {
                string[] words = line.Split(" ");
                Assert.
            }

            File.Delete($"{fileName}.log");
        }
    }
}
