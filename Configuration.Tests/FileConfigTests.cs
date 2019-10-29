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
        public void FileConfig_GetConfigValue_ReturnsValues()
        {
            //Organize
            FileConfig fileconfig = new FileConfig();
            //Act
            bool settingWasSet = fileconfig.SetConfigValue("Test", "Hello");
            bool settingExists = fileconfig.GetConfigValue("Test", out string? settingValue);

            //Assert
            Assert.IsTrue(settingExists);
            Assert.IsNotNull(settingValue);
        }

        [TestMethod]
        public void FileConfig_SetConfigValue_SetsValue()
        {
            //Organize
            FileConfig fileconfig = new FileConfig();
            //Act
            bool settingWasSet = fileconfig.SetConfigValue("Test", "Hello");
            //Assert
            Assert.IsTrue(settingWasSet);
        }
    }
}
