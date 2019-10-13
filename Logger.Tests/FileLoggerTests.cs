using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        public void FileLogger_CreateFile_Success()
        {
            //Arrange
            string filePath = Path.GetRandomFileName();

            FileLogger fileLogger = new FileLogger(filePath);

            //Assert
            Assert.IsTrue(File.Exists(filePath));

            File.Delete(filePath);
        }

        [TestMethod]
        public void FileLogger_LogMessage_success()
        {
            //Arrange
            string filePath = Path.GetRandomFileName();

            //Act
            FileLogger fileLogger = new FileLogger(filePath);
            fileLogger.Log(LogLevel.Information, "Random message");

            //Assert
            Assert.AreEqual(1, File.ReadLines(filePath).Count());
        }
    }
}
