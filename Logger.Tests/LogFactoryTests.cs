using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void Not_Configured_Return_Null()
        {
            // Arrange
            LogFactory factory = new LogFactory();

            // Act
            var logger = factory.CreateLogger(this.GetType().Name);

            // Assert
            Assert.IsNull(logger);
        }

        [TestMethod]
        public void Configured_Return_Correct_Logger()
        {
            string filePath = Path.GetRandomFileName();

            try
            {
                // Arrange
                LogFactory factory = new LogFactory();
                factory.ConfigureFileLogger(filePath);

                // Act
                var logger = factory.CreateLogger(this.GetType().Name);

                // Assert
                Assert.IsNotNull(logger);
                Assert.AreEqual(this.GetType().Name, logger.ClassName);
            }

            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
