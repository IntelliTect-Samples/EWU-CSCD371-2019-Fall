using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger.Tests
{
    [TestClass]
    public class ConsoleLoggerTests
    {
        [TestMethod]
        public void Log_ConsoleLogger_ConsoleWrite()
        {
            //Arrange
            //setup Console.Out to go to a file so we can verify success.
            TextWriter originalOutput = Console.Out;

            string path = Path.GetFullPath(Path.GetRandomFileName());

            FileStream outStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(outStream);
            Console.SetOut(streamWriter);

            ConsoleLogger logger = new ConsoleLogger();
            logger.ClassName = "ConsoleLoggerTests.cs";

            //Act
            logger.Log(LogLevel.Information, "Message 42");

            //set the console back to original.
            Console.SetOut(originalOutput);
            streamWriter.Close();
            outStream.Close();

            string[] lines = File.ReadAllLines(path);

            File.Delete(path);
            //Assert
            Assert.IsTrue(lines[lines.Length - 1].Contains("Message 42"));
        }
    }
}
