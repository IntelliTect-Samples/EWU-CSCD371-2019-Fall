using System;
using System.Linq;
using System.Collections.Generic;
using Configuration;

namespace Mock
{
    public class MockConfig : IConfig
    {
        private Dictionary<string, string?> ConfigDict;

        public MockConfig()
        {
            ConfigDict = new Dictionary<string, string?>();
        }

        public bool GetConfigValue(string name, out string? value)
        {
            if (ConfigDict.ContainsKey(name))
            {
                value = ConfigDict[name];
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (value is null)
                throw new ArgumentNullException("Cannot pass null config value.");
            else if (value == "")
                throw new ArgumentException("Cannot pass empty string to config.");
            else if (value.Contains('='))
                throw new ArgumentException("Cannot pass config value with '=' char.");
            else if (value.Contains(' '))
                throw new ArgumentException("Cannot pass config value with whitespace.");
            ConfigDict[name] = value;
            return true;
        }
    }
}
