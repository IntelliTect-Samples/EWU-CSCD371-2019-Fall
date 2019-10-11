using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_CreateFile_Qapla()
        {
            string path = "testPath.txt";
            _ = new FileLogger(path);
            Assert.IsNotNull(path);
        }

        [TestMethod]
        public void FileLogger_LogToFile_Qapla()
        {
            string path = Path.GetTempFileName();
            BaseLogger baseLogger = new FileLogger(path);
            baseLogger.Log(LogLevel.Debug, "This is a test");
            string line = File.ReadLines(path).First();
            Assert.IsTrue(line.Contains("This is a test"));
        }
    }
}
