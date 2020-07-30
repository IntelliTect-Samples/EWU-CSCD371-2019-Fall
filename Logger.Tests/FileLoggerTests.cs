using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileLogger_NullPath_ThrowsException()
        {
            // Arrange

            // Act
            FileLogger logger = new FileLogger(null);

            // Assert
        }


        [TestMethod]
        public void Log_WritesToFile()
        {
            // Arrange
            string className = "FileLoggerTests";
            string path = Path.GetFullPath(Path.GetRandomFileName());
            FileLogger logger = new FileLogger(path);
            logger.ClassName = className;

            // Act
            logger.Log(LogLevel.Error, string.Format("Message {0}", 42.ToString()));

            string[] lines = File.ReadAllLines(path);

            File.Delete(path);

            // Assert
            Assert.IsTrue(lines[lines.Length - 1].Contains(className));
            Assert.IsTrue(lines[lines.Length - 1].Contains("Error"));
            Assert.IsTrue(lines[lines.Length - 1].Contains("Message 42"));

        }

        [TestMethod]
        public void Log_AppendsToExitstingFile()
        {
            // Arrange
            string className = "FileLoggerTests";
            string path = Path.GetFullPath(Path.GetRandomFileName());
            FileLogger logger = new FileLogger(path);
            logger.ClassName = className;
            //write a few lines to a file.
            string[] fileContents = { "Hello", "World", "Test" };
            File.WriteAllLines(path, fileContents);

            // Act
            logger.Log(LogLevel.Error, string.Format("Message {0}", 42.ToString()));

            string[] lines = File.ReadAllLines(path);
            File.Delete(path);

            // Assert
            Assert.IsTrue(lines.Length == 4);
            Assert.IsTrue(lines[lines.Length - 1].Contains(className));
            Assert.IsTrue(lines[lines.Length - 1].Contains("Error"));
            Assert.IsTrue(lines[lines.Length - 1].Contains("Message 42"));

        }


    }
}
