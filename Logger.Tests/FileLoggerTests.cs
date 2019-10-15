using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Message_ThrowsException()
        {
            LogFactory myFactory = new LogFactory();
            myFactory.ConfigureFileLogger("test.txt");
            FileLogger myLogger = (FileLogger)myFactory.CreateLogger("test");
            myLogger.Log(LogLevel.Error, null);
        }
    }
}