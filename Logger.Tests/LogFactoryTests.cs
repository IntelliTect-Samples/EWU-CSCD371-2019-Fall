using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_IsReturnedLoggerNull() {
            LogFactory logFactory = new LogFactory();
            Assert.IsNotNull(logFactory.CreateLogger("test"));
        }
    }
}
