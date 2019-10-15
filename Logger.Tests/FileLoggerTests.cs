using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{

    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        [DataRow("path_test.txt")]
        public void GivenPath_ReturnsValidLogger(string path)
        {
            var logger = new FileLogger(path);
            Assert.IsNotNull(logger);
            Assert.AreEqual(path, logger.Path);

            File.Delete(path);
        }

        [TestMethod]
        public void CreateFile_EnsuresValidFile()
        {
            string path = Path.GetTempFileName();
            var logger = new FileLogger(path);

            Assert.IsTrue(File.Exists(logger.Path));

            File.Delete(path);
        }

        [TestMethod]
        [DataRow("Test Message")]
        public void Log_EnsureCorrectWriteToFile(string message)
        {
            string path = Path.GetTempFileName();
            var expected = 1;
            if (File.Exists(path))
            {
                expected += File.ReadAllLines(path).Length;
            }

            var logger = new FileLogger(path);
            logger.Log(LogLevel.Information, message);

            Assert.AreEqual(expected, File.ReadAllLines(path).Length);

            File.Delete(path);
        }

    }

}
