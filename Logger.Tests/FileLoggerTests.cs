using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.RegularExpressions;

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
            foreach (string line in File.ReadLines($"{fileName}.log")) {
                string[] splits = line.Split(": ");
                Assert.AreEqual("Test Message", splits[splits.Length-1]);
            }
            File.Delete($"{fileName}.log");
        }

        [TestMethod]
        public void LogMessage_DidFormatDate_Correct()
        {
            Regex AMPMRegex = new Regex(@".+[AP]M");
            Regex dateRegex = new Regex(@"[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}");
            Regex timeRegex = new Regex(@"[0-9]{1,2}:[0-9]{2}:[0-9]{2}");
            string fileName = "TestFile";
            FileLogger fileLogger = new FileLogger(fileName) { LoggerName = "TestLogger" };
            fileLogger.Log(LogLevel.Warning, "Test Message");
            fileLogger.Log(LogLevel.Error, "Test Message");
            fileLogger.Log(LogLevel.Information, "Test Message");
            fileLogger.Log(LogLevel.Debug, "Test Message");
            foreach (string line in File.ReadLines($"{fileName}.log")) {
                MatchCollection matches = AMPMRegex.Matches(line);
                Assert.AreEqual(matches.Count, 1);
                matches = dateRegex.Matches(line);
                Assert.AreEqual(matches.Count, 1);
                matches = timeRegex.Matches(line);
                Assert.AreEqual(matches.Count, 1);
            }
            File.Delete($"{fileName}.log");
        }
    }
}
