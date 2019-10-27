using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
#pragma warning disable CA1707///////////////
namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetConfigValue_FileDoesNotExist_ThrowsException()
        {
            string filePath = Path.GetFullPath("TestPath.txt");
            var sut = new FileConfig(filePath);
            _ = sut.GetConfigValue("", out string? value);
        }

        [TestMethod]
        public void GetConfigValue_ConfigNameDoesNotExistInFile_ReturnNull()
        {
            string filePath = Path.GetFullPath("TestPath.txt");
            var sut = new FileConfig(filePath);
            string name1 = "TestName1", name2 = "TestName2";
            
            try
            {
                sut.SetConfigValue(name1, "TestValue");

                Assert.IsFalse(sut.GetConfigValue(name2, out string? value));
                Assert.IsNull(value);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void SetConfigValue_CreatesFile_Success()
        {
            string filePath = Path.GetFullPath("TestPath.txt");
            var sut = new FileConfig(filePath);
            try
            {
                string name = "TestName";
                sut.SetConfigValue(name, "TestValue");

                Assert.IsTrue(File.Exists(filePath));
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("name=value")]
        [DataRow("name value")]
        public void SetConfigValue_NameContainsWhiteSpaceOrEquals_ThrowsException(string? name)
        {
            string filePath = Path.GetFullPath("TestPath.txt");
            try
            {
                var sut = new FileConfig(filePath);
                _ = sut.SetConfigValue(name!, null);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null)]
        [DataRow("")]
        public void SetConfigValue_NullOrEmptyName_ThrowsException(string? name)
        {
            string filePath = Path.GetFullPath("TestPath.txt");
            try
            {
                var sut = new FileConfig(filePath);
                _ = sut.SetConfigValue(name!, null);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
