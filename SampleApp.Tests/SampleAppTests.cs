using Configuration.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace SampleApp.Tests
{
    [TestClass]
    public class SampleAppTests
    {
        private readonly string[] expectedOutput =
            {
                "test0=value0",
                "test1=value1",
                "test2=value2",
                "test3=value3",
                "test4=value4"
            };

        [TestMethod]
        public void SampleAppMain_ConfigNotSet_UseEnvironmentConfig()
        {
            //Set the "console" to go to a file so we can verify our work. 
            //We trust the inners of System.Console handles file vs console output. 
            TextWriter originalOutput = Console.Out;
            string path = Path.GetFullPath(Path.GetRandomFileName());
            FileStream outStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(outStream);
            Console.SetOut(streamWriter);

            //run the program
            SampleAppMain.Main();


            //set the console back to original.
            Console.SetOut(originalOutput);
            streamWriter.Close();
            outStream.Close();


            string[] lines = File.ReadAllLines(path);
            File.Delete(path);

            //Assert
            Assert.IsTrue(expectedOutput.Length == lines.Length);
            for (int i = 0; i < lines.Length; i++)
            {
                Assert.AreEqual(expectedOutput[i], lines[i]);
            }

        }

        [TestMethod]
        public void SampleAppMain_PrintHardCodedSettings()
        {
            //Set the "console" to go to a file so we can verify our work. 
            //We trust the inners of System.Console handles file vs console output. 
            TextWriter originalOutput = Console.Out;
            string path = Path.GetFullPath(Path.GetRandomFileName());
            FileStream outStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(outStream);
            Console.SetOut(streamWriter);

            SampleAppMain.Config = new MockConfig();
            //run the program
            SampleAppMain.Main();


            //set the console back to original.
            Console.SetOut(originalOutput);
            streamWriter.Close();
            outStream.Close();

            string[] lines = File.ReadAllLines(path);
            File.Delete(path);

            //Assert
            Assert.IsTrue(expectedOutput.Length == lines.Length);
            for (int i = 0; i < lines.Length; i++)
            {
                Assert.AreEqual(expectedOutput[i], lines[i]);
            }
        }
    }
}
