using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Test_File_Contents_Match_Empty_File()
        {
            LogFactory myFactory = new LogFactory();
            //File.WriteAllText("test.txt", "");
            myFactory.ConfigureFileLogger("test.txt");
            FileLogger myLogger = (FileLogger)myFactory.CreateLogger("FileLoggerTests");
            myLogger.Log(LogLevel.Debug, "Testing to see if written to file correctly");
        }
    }
}
