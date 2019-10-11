using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void LogFactory_WithNullFilePath_ReturnNull()
        {
            string className = "myLogger";
            LogFactory logFactory = new LogFactory();
            BaseLogger logger = logFactory.CreateLogger(className);
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void LogFactory_WithConfiguredFilePath_ReturnFileLoggerObject()
        {
            string className = "myLogger";
            LogFactory logFactory = new LogFactory();
            string path = Path.GetTempFileName();
            logFactory.ConfigureFileLogger(path);
            BaseLogger logger = logFactory.CreateLogger(className);
            Assert.IsNotNull(logger);
        }
    }
}

