using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateFileLogger_PathSet_ReturnsFileLogger()
        {
            //Arrange
            LogFactory factory = new LogFactory();

            string path = Path.GetFullPath(Path.GetRandomFileName());

            //Act
            factory.ConfigureFileLogger(path);
            BaseLogger logger = factory.CreateLogger("LogFactoryTests");


            //Assert
            Assert.IsTrue(logger is FileLogger);
        }


        [TestMethod]
        public void CreateFileLogger_PathNotSet_ReturnsNull()
        {
            //Arrange
            LogFactory factory = new LogFactory();

            //Act
            BaseLogger logger = factory.CreateLogger("LogFactoryTests");


            //Assert
            Assert.IsNull(logger);
        }
    }
}
