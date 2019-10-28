using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Configuration;
using System.IO;
using System.Linq;

namespace Configuration.Tests {
    [TestClass]
    public class ConfigurationTests {
        [TestMethod]
        public void EnvironmentConfig_GetAndSetConfigValue_Works() {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            string[] configNames = { "Day", "Name", "Time" };
            string[] values = { "Monday", "Joel", "Too Late" };

            //Act
            for (int i = 0; i < configNames.Length; i++) {
                config.SetConfigValue(configNames[i], values[i]);
            }
            config.GetConfigValue(configNames[0], out string value1);
            config.GetConfigValue(configNames[1], out string value2);
            config.GetConfigValue(configNames[2], out string value3);

            //Assert
            Assert.AreEqual("Monday", value1);
            Assert.AreEqual("Joel", value2);
            Assert.AreEqual("Too Late", value3);
        }

        [TestMethod]
        public void EnvironmentConfig_SetConfigValue_OnlyAcceptsValidInput() {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            string?[] configNames = { "Day ", "Name=", null, "", "Day", "Name" };
            string?[] values = { "Monday", "Joel", "Too Late", "Just a Test", null, "" };

            //Act

            //Assert
            for (int i = 0; i < configNames.Length; i++) {
                Assert.IsFalse(config.SetConfigValue(configNames[i], values[i]));
            }
        }

        [TestMethod]
        public void FileConfig_WriteToFile_Works() {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            string[] configNames = { "Day", "Name", "Time" };
            string[] values = { "Monday", "Joel", "Too Late" };
            for (int i = 0; i < configNames.Length; i++) {
                config.SetConfigValue(configNames[i], values[i]);
            }
            FileConfig file = new FileConfig("TestingWriteToFile.txt");

            //Act
            file.WriteToFile(config);
            string[] result = File.ReadAllLines(file.getPath());

            //Assert
            for (int i = 0; i < values.Length; i++) {
                Assert.AreEqual(configNames[i] + "=" + values[i], result[i]);
            }
        }
        [TestMethod]
        public void FileConfig_ReadFromFile_Works() {
            //Arrange
            EnvironmentConfig config = new EnvironmentConfig();
            string[] configNames = { "Day", "Name", "Time" };
            string[] values = { "Monday", "Joel", "Too Late" };
            List<string[]> expected = new List<string[]>();
            for (int i = 0; i < configNames.Length; i++) {
                config.SetConfigValue(configNames[i], values[i]);
                expected.Add(new string[] { configNames[i], values[i] });
            }
            FileConfig file = new FileConfig("TestingWriteToFile.txt");
            file.WriteToFile(config);

            //Act
            List<string[]> actual = file.ReadFromFile();

            //Assert
            foreach (var setting in expected.Zip(actual, (e, a) => new { exp = e, act = a })) {
                for (int i = 0; i < setting.exp.Length; i++) {
                    Assert.AreEqual(setting.exp[i], setting.act[i]);
                }
            }
        }
    }
}
