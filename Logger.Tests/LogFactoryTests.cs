using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{

    [TestClass]
    public class LogFactoryTests
    {

        [TestMethod]
        public void CreateLogger_NullIfNotConfigured()
        {
            Assert.IsNull(new LogFactory().CreateLogger("BaseLogger"));
        }

        [TestMethod]
        public void CreateLogger_NotNullIfConfigured()
        {
            var factory = new LogFactory();
            factory.ConfigureFileLogger(Path.GetTempFileName());
            var logger = factory.CreateLogger("BaseLogger");
            Assert.IsNotNull(logger);
        }

    }

}
