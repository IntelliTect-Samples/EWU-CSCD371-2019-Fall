using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_Log_MessageIsCorrect()
        {
            string logFile = "FileLogger_Log_MessageIsCorrect.log";
            string testMessage = "abcdefghijklmnopqrstuvwxyz";
            FileLogger logger = new FileLogger(logFile)
            {
                ClassName = nameof(FileLoggerTests)
            };

            logger.Log(LogLevel.Error, testMessage);

            string[] logResults = File.ReadAllLines(logFile);

            Assert.IsTrue(logResults.Length == 1);
            Assert.IsTrue(logResults[0].Contains(testMessage));
        }
    }
}
