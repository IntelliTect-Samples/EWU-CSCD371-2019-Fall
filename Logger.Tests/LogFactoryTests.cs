using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_UnconfiguredLogFactory_IsLoggerNull() {
            LogFactory logFactory = new LogFactory();
            Assert.IsNull(logFactory.CreateLogger("test"));
        }

        [TestMethod]
        public void CreateLogger_ConfiguredLogFactory_IsLoggerNotNull() {
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("SomePath.log");
            Assert.IsNotNull(logFactory.CreateLogger("test"));
        }
    }
}
