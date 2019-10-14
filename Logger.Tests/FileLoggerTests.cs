using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        public void Log_AppendsMessage()
        {
            //Arrange
            string path = "AppendsMessage.txt";
            if (File.Exists(path) is false) { File.Create(path); }
            string[] fileLines = File.ReadAllLines(path);
            int lineCount = fileLines.Length;
            BaseLogger fileLogger = new FileLogger(path);

            //Act
            fileLogger.Log(LogLevel.Error, "this is stuff to note");
            fileLines = File.ReadAllLines(path);

            //Assert
            Assert.IsTrue(fileLines.Length > lineCount);
            Assert.IsTrue(fileLines[fileLines.Length-1].Contains("this is stuff to note"));
        }

    }
}
