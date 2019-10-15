using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_Output()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                string[] whiteSpace = new string[] { "" };
                File.AppendAllLines(filePath, whiteSpace);

                // Act
                FileLogger logger = new FileLogger(filePath) { ClassName = this.GetType().Name };
                logger.Error("{0} {1}", "Hello", "World");
                string[] text = File.ReadAllLines(filePath);
                string output = text[text.Length - 1];

                // Assert 
                Assert.AreEqual(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + " " + logger.ClassName + " Error: Hello World", output);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
