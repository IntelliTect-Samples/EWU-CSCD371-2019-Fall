using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Configuration.Tests
{

    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        public void FileConfig_SetConfigValue_GetConfigValue()
        {
            string filePath = Path.GetFullPath("test.settings");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            var sut = new FileConfig(filePath);

            string name = "testName";
            string value = "testValue";

            try
            {
                //set variable
                bool setReturnValue = sut.SetConfigValue(name, value);

                Assert.IsTrue(setReturnValue);

                //get value back
                bool getReturnValue = sut.GetConfigValue(name, out string? outReturned);

                Assert.IsTrue(getReturnValue);
                Assert.IsNotNull(outReturned);
                Assert.AreEqual(value, outReturned);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(null)]
        [DataRow("Hello World")]
        [DataRow("Hello=World")]
        public void FileConfig_GetConfigValue_BadName(string badName)
        {
            string filePath = Path.GetFullPath("test.settings");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            try
            {
                var sut = new FileConfig(filePath);
                sut.SetConfigValue("TEST", "VALUE");

                sut.GetConfigValue(badName, out string? value);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void FileConfig_GetConfigValue_FileNotExist()
        {
            //arrange
            string filePath = Path.GetFullPath("test.settings");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            var sut = new FileConfig(filePath);
            //act
            bool getReturn = sut.GetConfigValue("test", out string? value);


            //assert
            Assert.IsFalse(getReturn);
            Assert.IsTrue(string.IsNullOrEmpty(value));
        }

        [TestMethod]
        public void FileConfig_GetConfigValue_ConfigNotExist()
        {
            //arrange
            string filePath = Path.GetFullPath("test.settings");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            try
            {

                var sut = new FileConfig(filePath);
                //act
                //put something in the file to make sure it exists
                sut.SetConfigValue("Test", "Value");

                //Search for something not in the file
                bool getReturn = sut.GetConfigValue("tests", out string? value);


                //assert
                Assert.IsFalse(getReturn);
                Assert.IsTrue(string.IsNullOrEmpty(value));
            }
            finally
            {
                File.Delete(filePath);
            }
        }


        [TestMethod]
        public void FileConfig_SetConfigValue_CreatesNewFile()
        {
            //arrange
            string filePath = Path.GetFullPath("test.settings");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            try
            {

                var sut = new FileConfig(filePath);
                //act

                //put something in the file to make sure it exists
                sut.SetConfigValue("Test", "Value");
                //Prove that the file was written to as well
                bool getReturn = sut.GetConfigValue("Test", out string? value);

                //assert
                Assert.IsTrue(File.Exists(filePath));
                Assert.IsTrue(getReturn);
                Assert.AreEqual("Value", value);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        public void FileConfig_SetConfigValue_UpdateSetting()
        {
            //arrange
            string filePath = Path.GetFullPath("test.settings");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            try
            {
                string key = "Test";
                string beforeValue = "BeforeValue";
                string afterValue = "AfterValue";
                string writeFileBefore = $"{key}={beforeValue}{Environment.NewLine}";

                //Write a line to the file for the key Test
                File.WriteAllText(filePath, writeFileBefore);


                var sut = new FileConfig(filePath);
                //act
                bool firstGet = sut.GetConfigValue(key, out string? returnedBefore);
                bool setReturnVal = sut.SetConfigValue(key, afterValue);//Update the value
                bool secondGet = sut.GetConfigValue(key, out string? returnedAfter);

                //Assert
                Assert.IsTrue(firstGet);
                Assert.IsTrue(setReturnVal);
                Assert.IsTrue(secondGet);

                Assert.IsNotNull(returnedBefore);
                Assert.IsNotNull(returnedAfter);
                Assert.AreNotEqual(returnedBefore, returnedAfter);
                Assert.AreEqual(beforeValue, returnedBefore);
                Assert.AreEqual(afterValue, returnedAfter);

            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void FileConfig_SetConfigValue_UnsetSetting(string? testValue)
        {
            //arrange
            string filePath = Path.GetFullPath("test.settings");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            try
            {
                string key = "Test";
                string value = "BeforeValue";
                string writeFileBefore = $"{key}={value}{Environment.NewLine}";

                //Write a line to the file for the key Test
                File.WriteAllText(filePath, writeFileBefore);


                var sut = new FileConfig(filePath);
                //act
                bool firstGet = sut.GetConfigValue(key, out string? returnedBefore);
                bool setReturnVal = sut.SetConfigValue(key, testValue);//Update the value
                bool secondGet = sut.GetConfigValue(key, out string? returnedAfter);

                //Assert
                Assert.IsTrue(firstGet);
                Assert.IsTrue(setReturnVal);
                Assert.IsFalse(secondGet);

                Assert.IsNotNull(returnedBefore);
                Assert.IsTrue(string.IsNullOrEmpty(returnedAfter));

            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [DataTestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(null, "value")]
        [DataRow("", "value")]
        public void FileConfig_SetConfigValue_BadName_BadValue(string name, string value)
        {
            string filePath = Path.GetFullPath("test.settings");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }


            var sut = new FileConfig(filePath);
            //act
            sut.SetConfigValue(name, value);


        }

        [TestMethod]
        public void FileConfig_SetConfigValue_UnsetNonExistingSetting()
        {
            //arrange
            string filePath = Path.GetFullPath("test.settings");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            try
            {
                string writeFile = $"Test=Value{Environment.NewLine}";

                //Write a line to the file for the key Test
                File.WriteAllText(filePath, writeFile);


                var sut = new FileConfig(filePath);
                //act
                bool setReturnVal = sut.SetConfigValue("Test1", ""); //Update a value that doesn't exist returns true does nothing

                //Assert
                Assert.IsTrue(setReturnVal);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
