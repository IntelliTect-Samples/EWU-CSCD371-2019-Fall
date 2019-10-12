using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_NotConfigured() 
        {
            LogFactory logFactory = new LogFactory();

            BaseLogger testLog = logFactory.CreateLogger("Logger name");

            Assert.IsNull(testLog);
        }

        [TestMethod]
        public void CreateLogger_Configured()
        {
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("testFile.txt");

            BaseLogger testLog = logFactory.CreateLogger("Logger name");

            Assert.AreEqual("Logger name", testLog.Name);
        }
    }
}
