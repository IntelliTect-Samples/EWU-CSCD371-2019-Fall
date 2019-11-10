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
            SanitizeValue(name);
            SanitizeValue(value);
            ConfigDict[name] = value;
            return true;
        }


        // MMM Comment: This method appears more than once.  Refactor into one method.
        public static void SanitizeValue(string? value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException($"Cannot pass null or empty value for {nameof(value)}.");
            else if (value.Contains('='))
                throw new ArgumentException($"Cannot pass '=' char in {nameof(value)}.");
            else if (value.Contains(' '))
                throw new ArgumentException($"Cannot pass whitespace in {nameof(value)}.");
        }
    }
}
