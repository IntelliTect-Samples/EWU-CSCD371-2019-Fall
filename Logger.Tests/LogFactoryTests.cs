using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void LogFactory_PathConfigured()
        {
            string filePath = "TestFile.txt";
            try
            {
                //Arrange
                LogFactory logFactory = new LogFactory();

                //Act
                logFactory.ConfigureFileLogger(filePath);

                //Assert
                Assert.AreEqual(filePath, logFactory.filePath);
            }
            finally
            {
                File.Delete(filePath);
            }
            
        }

        [TestMethod]
        public void LogFactory_CreateLogger()
        {
            string filePath = "TestFile.txt";
            try
            {
                //Arrange
                LogFactory logFactory = new LogFactory();

                //Act
                logFactory.ConfigureFileLogger(filePath);
                var logger = logFactory.CreateLogger("LogFactoryTests");

                //Assert
                Assert.IsNotNull(logger);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
