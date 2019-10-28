using Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace SampleApp.Tests {
    public class Tests {

        [TestMethod]
        public void SampleApp_() {
            //Not Implemented
            Assert.Pass();
        }
    }

    class MockConfig : IConfig {
        List<string[]> settings;
        public MockConfig() {
            this.settings = new List<string[]>();
        }

        public bool GetConfigValue(string name, out string? value) {
            foreach (string[] setting in settings) {
                if (setting[0] == name) {
                    value = setting[1];
                    return true;
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string? name, string? value) {
            if (name is null || value is null || name == "" || value == "") {
                return false;
            }
            this.settings.Add(new string[] { name, value });
            return true;
        }
    }
}