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

            try
            {
                FileLogger logger = new FileLogger(logFile)
                {
                    ClassName = nameof(FileLoggerTests)
                };

                logger.Log(LogLevel.Error, testMessage);

                string[] logResults = File.ReadAllLines(logFile);

                Assert.AreEqual(1, logResults.Length);
                Assert.IsTrue(logResults[0].Contains(testMessage));
            }
            finally
            {
                File.Delete(logFile);
            }
        }
    }
}
