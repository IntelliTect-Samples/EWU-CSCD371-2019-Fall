
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;


namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Getpath_Success()
        {
        
            string path = Path.GetTempFileName();
            _ = new FileLogger(path);

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]

        public void CreatedLog_Success()
        {
            string path = Path.GetTempFileName();
            FileLogger fileLogger = new FileLogger(path);

            fileLogger.Log(LogLevel.Error, "Error test.");
            fileLogger.Log(LogLevel.Warning, "Warning test.");
            fileLogger.Log(LogLevel.Information, "Information test.");
            fileLogger.Log(LogLevel.Debug, "Debug test.");
            
            string logContent = File.ReadLines(path).First();
            Assert.IsTrue(logContent.Contains("Error test."));

            logContent = File.ReadLines(path).ElementAt(1);
            Assert.IsTrue(logContent.Contains("Warning test."));

            logContent = File.ReadLines(path).ElementAt(2);
            Assert.IsTrue(logContent.Contains("Information test."));

            logContent = File.ReadLines(path).ElementAt(3);
            Assert.IsTrue(logContent.Contains("Debug test."));
        }
    }
}
