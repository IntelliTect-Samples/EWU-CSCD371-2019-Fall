using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Filepath_ThrowsException()
        {
            LogFactory myFactory = new LogFactory();
            myFactory.ConfigureFileLogger(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Classname_ThrowsException()
        {
            LogFactory myFactory = new LogFactory();
            myFactory.ConfigureFileLogger("test.txt");
            FileLogger myLogger = (FileLogger)myFactory.CreateLogger(null);
        }
    }
}