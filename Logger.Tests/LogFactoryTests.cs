using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_WithInvalidClassName()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            var logger = logFactory.CreateLogger("InvalidClassName");

            //Assert
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void CreateLogger_WithValidClassName()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            var logger = logFactory.CreateLogger("BlankLogger");

            //Assert
            Assert.IsNotNull(logger);
        }

        [TestMethod]
        public void CreateFileLogger_NoPathConfigured()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            var logger = logFactory.CreateLogger("FileLogger");

            //Assert
            Assert.IsNull(logger);
        }
    }
}
