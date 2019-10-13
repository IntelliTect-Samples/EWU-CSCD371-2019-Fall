using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_ReturnsNullIfoutPathIsNull()
        {
            //arrange

            //act
            LogFactory logFactory = new LogFactory();

            //assert
            Assert.IsNull(logFactory.CreateLogger("className"));
        }
        
        [TestMethod]
        public void CreateLogger_CreatesLogger()
        {
            //arrange
            string userName = Environment.UserName;
            string path = "C:/Users/" + userName + "/Documents/Visual Studio Logs/logs3.txt";

            //act
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger(path);

            //assert
            Assert.IsNotNull(logFactory.CreateLogger("className"));
        }
    }
}
