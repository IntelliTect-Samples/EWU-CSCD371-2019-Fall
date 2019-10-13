using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_WithNullFilePath_ReturnsNull()
        {
            string className = "FileLoggerTests";
            LogFactory logFactory = new LogFactory();

            Assert.AreEqual(null, logFactory.CreateLogger(className));
        }

        [TestMethod]
        public void CreateLogger_AfterConfigureFilePath_ReturnsNotNull()
        {
            string className = "FileLoggerTests";
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(className);

            Assert.IsNotNull(logFactory.CreateLogger(className));
        }
    }
}
