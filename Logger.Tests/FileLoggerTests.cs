using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void FileLogger_CreatedFile()
        {
            //arrange
            string userName = Environment.UserName;
            string path = "C:/Users/" + userName + "/Documents/Visual Studio Logs/logs.txt";

            //act
            FileLogger fLogger = new FileLogger(path);

            //assert
            Assert.IsTrue(File.Exists(path));

            //cleanup
            File.Delete(path);
        }

        [TestMethod]
        public void Log_WritesToFileCorrectly()
        {
            //arrnge
            string userName = Environment.UserName;
            string path = "C:/Users/"+userName+"/Documents/Visual Studio Logs/logs2.txt";
            FileLogger fLogger = new FileLogger(path);

            //act
            fLogger.Log(LogLevel.Error, "Test 1: Testing Error");
            fLogger.Log(LogLevel.Warning, "Test 2: Testing Warning");
            fLogger.Log(LogLevel.Information, "Test 3: Testing Information");
            fLogger.Log(LogLevel.Debug, "Test 4: Testing Debug");

            //assert
            Assert.AreEqual(212, File.ReadAllText(path).Length);

            //cleanup
            File.Delete(path);
        }
    }
}
