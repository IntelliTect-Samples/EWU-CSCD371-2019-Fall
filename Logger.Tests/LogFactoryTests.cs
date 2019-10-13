using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void LogFactory_Constructor_Returns_Logger()
        {
            //Arrange

            LogFactory logFactory = new LogFactory();

            //Act
            var testLogger = logFactory.CreateLogger("TestLogger");

            //Assert
            Assert.IsNotNull(testLogger);
        }
    }
}
