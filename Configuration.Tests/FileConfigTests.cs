using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        public void FileConfig_CreatesFile_Success()
        {
            string fileName = "somefilename.txt";
            string name = "SomeName", value = "SomeValue";
            try 
            {
                var sut = new FileConfig()
                {
                    FileName = fileName
                };

                sut.SetConfigValue(name, value);

                Assert.IsTrue(File.Exists(Environment.CurrentDirectory + fileName));
            }
            finally
            {
                File.Delete(Environment.CurrentDirectory + fileName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("SomeName", "Some Value")]
        [DataRow("Some Name", "SomeValue")]
        [DataRow("SomeName", "Some=Value")]
        public void FileConfig_SanitizeConfig_ExceptionOnBadInput(string name, string value)
        {
            string fileName = "SomeFileName";
            try
            {
                var sut = new FileConfig()
                {
                    FileName = fileName
                };
                sut.SetConfigValue(name, value);
            }
            finally
            {
                File.Delete(Environment.CurrentDirectory + fileName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow("SomeName", null)]
        [DataRow("SomeName", "")]
        [DataRow("", "SomeValue")]
        public void FileConfig_SanitizeConfig_NullExceptionOnBadInput(string name, string value)
        {
            string fileName = "SomeFileName";
            try
            {
                var sut = new FileConfig()
                {
                    FileName = fileName
                };
                sut.SetConfigValue(name, value);
            }
            finally
            {
                File.Delete(Environment.CurrentDirectory + fileName);
            }
        }
    }
}

