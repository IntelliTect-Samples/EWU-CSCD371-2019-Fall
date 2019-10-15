using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_Constructor_Sets_FilePath()
        {
            try
            {
                //Arrange
                FileLogger testLogger = new FileLogger("testfile.txt");
                //Act

                //Assert
                Assert.AreNotEqual(null, testLogger.FilePath);
            }
            finally
            {
                File.Delete("testfile.txt");
            }
        }

        [TestMethod]
        public void FileLogger_creates_new_file()
        {
            try
            {
                //Arrange
                FileLogger testLogger = new FileLogger("newfile.txt");

                //act

                //Assert
                Assert.AreEqual(true, File.Exists("newfile.txt"));
            }
            finally
            {
                File.Delete("newfile.txt");
            }
        }

        [TestMethod]
        public void FileLogger_Log_AppendsToFile()
        {
            try
            {
                //Arrange
                FileLogger testLogger = new FileLogger("logfile.txt");

                //act
                testLogger.Log(LogLevel.Error, "teststring");
                string logFileConents = File.ReadAllText("logfile.txt");
                //Assert
                Assert.AreEqual($"{DateTime.Now} FileLoggerTests {LogLevel.Error}: teststring", logFileConents);
            }
            finally
            {
                File.Delete("logfile.txt");
            }
        }
    }
}
