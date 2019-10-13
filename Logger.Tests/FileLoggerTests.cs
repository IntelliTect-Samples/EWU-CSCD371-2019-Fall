using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void SetFilePath_WithNewFile_CheckThatFileIsCreated()
        {
            File.Delete("newFile.txt");
            string newFile = "newFile.txt";

            FileLogger fileLogger = new FileLogger();
            fileLogger.SetFilePath(newFile);

            Assert.IsTrue(File.Exists(newFile));
        }

        [TestMethod]
        public void Log_FileMessageIsCorrect_isTrue()
        {
            string newFile = Path.GetTempFileName();
            string className = "FileLoggerTests";
            string message = "FileLoggerTests are running";

            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(className);

            FileLogger fileLogger = (FileLogger)logFactory.CreateLogger(className);
            fileLogger.SetFilePath(newFile);

            string fileLogTest = $"{DateTime.Now.ToString()} {className} {LogLevel.Information}: {message}";
            fileLogger.Information(message);

            Assert.AreEqual(fileLogTest, File.ReadAllText(newFile).Trim());
        }
    }
}
