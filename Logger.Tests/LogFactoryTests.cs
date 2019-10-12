using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreatedLogger_BaseLogger_ReturnNull()
        {
            BaseLogger baseLogger = new LogFactory().CreateLogger("path.txt");

            Assert.IsNull(baseLogger);
        }

        [TestMethod]

        public void CreatedLogger_Configured_BaseLogger_ReturnNotNull()
        {
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("path.txt");

            BaseLogger baseLogger = logFactory.CreateLogger("anotherpath.txt");
            Assert.IsNotNull(baseLogger);
        }

        
    }
}
