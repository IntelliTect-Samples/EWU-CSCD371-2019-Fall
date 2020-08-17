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
            var sut = new FileConfig();

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
                //File.Delete(Path.GetFullPath());
            }
        }
    }
}
