using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_Test()
        {
            string filePath = "TestFile.txt";
            try
            {
                //Arrange
                LogFactory logFactory = new LogFactory();
                logFactory.ConfigureFileLogger(filePath);
                var logger = logFactory.CreateLogger("FileLoggerTests");

                //Act
                logger.Log(LogLevel.Debug, "This is a message");

                string toTest = File.ReadAllText(filePath);

                //Assert
                Assert.IsTrue(toTest.Contains("Debug"));
                Assert.IsTrue(toTest.Contains("This is a message"));

            }
            finally
            {
                File.Delete(filePath);
            }

        }
    }
}
