using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_FileCreated_IsTrue()
        {
            //Arrange
            string filePath = "TestFile.txt";
            string className = "TestClass";
            FileLogger fileLogger = new FileLogger(filePath) { ClassName = className };

            //Act
            fileLogger.Error("Test Message");

            //Assert
            Assert.IsTrue(File.Exists(filePath));

            File.Delete(filePath);
        }
        
        [TestMethod]
        public void Log_FileFormatIsCorrect_IsTrue()
        {
            //Arrange
            string filePath = "TestFile.txt";
            string className = "TestClass";
            string testLog = $"{System.DateTime.Now.ToString()} TestClass Error: Test Message\n";
            FileLogger fileLogger = new FileLogger(filePath) { ClassName = className };

            //Act
            fileLogger.Error("Test Message");

            //Assert
            Assert.AreEqual(testLog, File.ReadAllText(filePath));

            File.Delete(filePath);
        }
    }
}
