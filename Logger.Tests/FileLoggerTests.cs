using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void CreateFileLogger_AppendToFile_Successful()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();
            string path = "testLog.txt";
            logFactory.ConfigureFileLogger(path);
            var fileLogger = logFactory.CreateLogger("FileLogger");
            int lineCount = File.ReadLines(path).Count();

            //Act
            fileLogger.Log(LogLevel.Warning, "Test Warning");

            //Assert
            Assert.IsTrue(File.Exists(path)); //Check if the file still exists
            Assert.IsTrue(new FileInfo(path).Length > 0); //Check if the file is non-empty
            Assert.IsTrue(File.ReadLines(path).Count() == lineCount+1); //Check to see if it appended one line exactly
        }
    }
}
