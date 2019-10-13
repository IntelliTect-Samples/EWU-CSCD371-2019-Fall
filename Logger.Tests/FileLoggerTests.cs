using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_Constructor_Sets_FilePath()
        {
            try
            {
                //Arrange
                FileLogger testLogger = new FileLogger("testfile.txt");
                //Act

                //Assert
                Assert.AreNotEqual(null, testLogger.FilePath);
            }
            finally
            {
                File.Delete("testfile.txt");
            }
        }

        [TestMethod]
        public void FileLogger_creates_new_file()
        {
            try
            {
                //Arrange
                FileLogger testLogger = new FileLogger("newfile.txt");

                //act

                //Assert
                Assert.AreEqual(true, File.Exists("newfile.txt"));
            }
            finally
            {
                File.Delete("newfile.txt");
            }
        }
    }
}
