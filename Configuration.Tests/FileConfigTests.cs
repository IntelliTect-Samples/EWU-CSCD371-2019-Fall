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
            try 
            {
                var sut = new FileConfig()
                {
                    FileName = fileName
                };

                Assert.IsTrue(File.Exists(Environment.CurrentDirectory + fileName));
            }
            finally
            {
                File.Delete(Environment.CurrentDirectory + fileName);
            }
        }
    }
}

