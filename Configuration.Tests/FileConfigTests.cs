using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    [TestClass]
    public class FileConfigTests
    {
        [TestMethod]
        public void SetFileConfig_Then_GetFileConfig()
        {
            //Arrange
            FileConfig fileConfig = new FileConfig();
            bool getFileConfig, setFileConfig;
            string? getValue = null, setValue = "data";

            //Act
            setFileConfig = fileConfig.SetConfigValue("key1", setValue);
            getFileConfig = fileConfig.GetConfigValue("key1", out getValue);

            //Assert
            Assert.IsTrue(setFileConfig);
            Assert.IsTrue(getFileConfig);
            Assert.IsNotNull(getValue);
            Assert.AreEqual("data", getValue);
        }
    }
}
