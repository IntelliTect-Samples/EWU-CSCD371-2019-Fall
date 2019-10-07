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
        public void Constructor_WithNullFilePath_ThrowsException()
        {
            // Arrange

            // Act
            new FileLogger(null);

            // Assert
        }

        [TestMethod]
        public void Log_WithData_WritesFile()
        {
            // Arrange
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            var sut = new FileLogger(filePath) { ClassName = nameof(FileLoggerTests) };

            // Act
            sut.Log(LogLevel.Warning, "Test");

            // Assert
            string[] lines = File.ReadAllLines(filePath);
            File.Delete(filePath);
            Assert.AreEqual(1, lines.Length);
            Assert.IsTrue(lines[0].Contains($"{LogLevel.Warning}"));
            Assert.IsTrue(lines[0].Contains(nameof(FileLoggerTests)));
            Assert.IsTrue(lines[0].Contains("Test"));
        }

        [TestMethod]
        public void Log_WithData_AppendsDataToFile()
        {
            // Arrange
            string filePath = Path.GetFullPath(Path.GetRandomFileName());
            var sut = new FileLogger(filePath) { ClassName = nameof(FileLoggerTests) };

            // Act
            sut.Log(LogLevel.Warning, "Test");
            sut.Log(LogLevel.Error, "Test2");

            // Assert
            string[] lines = File.ReadAllLines(filePath);
            File.Delete(filePath);
            Assert.AreEqual(2, lines.Length);
            Assert.IsTrue(lines[0].Contains($"{LogLevel.Warning}"));
            Assert.IsTrue(lines[0].Contains("Test"));
            Assert.IsTrue(lines[0].Contains(nameof(FileLoggerTests)));
            Assert.IsTrue(lines[1].Contains($"{LogLevel.Error}"));
            Assert.IsTrue(lines[1].Contains(nameof(FileLoggerTests)));
            Assert.IsTrue(lines[1].Contains("Test2"));
        }
    }
}
