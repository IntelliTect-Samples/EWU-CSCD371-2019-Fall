using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
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

        [TestMethod]
        [DataRow(null, "null config")]
        [DataRow("Spaces are great", "Just kidding")]
        [DataRow("equals=great", "yes=please")]
        [DataRow("", "emptystring")]
        public void FileConfig_SetConfigValue_InvalidValuesNotSet(string configName, string configValue)
        {
            //Organize
            FileConfig fileconfig = new FileConfig();
            //Act
            bool settingWasSet = fileconfig.SetConfigValue(configName, configValue);

            string[] fileContents = System.IO.File.ReadAllLines("config.settings");


            //Assert
            Assert.IsFalse(settingWasSet);

            for (int i = 0; i < fileContents.Length; i++)
            {
                string[] settingLineArray = fileContents[i].Split("=");
                Assert.IsTrue(settingLineArray.Length == 2);
                Assert.IsFalse(fileContents[i].Contains(" "));
            }
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("something=else")]
        [DataRow("hey you")]
        [DataRow("")]
        public void FileConfig_GetConfigValue_InvalidValueReturnsFalse(string ConfigName)
        {
            //Organize
            FileConfig fileconfig = new FileConfig();
            //Act
            bool settingWasSet = fileconfig.SetConfigValue("Testing", "Hello");
            bool settingExists = fileconfig.GetConfigValue(ConfigName, out string? settingValue);

            //Assert
            Assert.IsFalse(settingExists);
            Assert.IsNull(settingValue);
        }
    }
}
