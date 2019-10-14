using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_BeforeConfiguring_ReturnsNull()
        {
            //Arrange
            LogFactory lF = new LogFactory();
            BaseLogger bL =  new FileLogger("placeholder.txt"); //Starting with non-null to ensure the action is what made bL null

            //Act
            bL = lF.CreateLogger("LogFactoryTests");

            //Assert
            Assert.IsTrue(bL is null);
        }

        [TestMethod]
        public void CreateLogger_AfterConfiguring_ReturnsBaseLogger()
        {
            //Arrange
            LogFactory lF = new LogFactory();
            BaseLogger bL;

            //Act
            lF.ConfigureFileLogger("placeholder.txt");
            bL = lF.CreateLogger("LogFactoryTests");

            //Assert
            Assert.IsNotNull(bL);
        }
    }
}
