using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class MockConfig : IConfig
    {
        List<(string,string)> configSettings = new List<(string, string)>
        {
            ("testName1","testValue1"),
            ("testName2","testValue2"),
            ("testName3","testValue3")

        };

        public bool GetConfigValue(string name, out string? value)
        {
            foreach((string, string) tuple in configSettings)
            {
                if(tuple.Item1 == name)
                {
                    value = tuple.Item2;
                    return true;
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value) || name.Contains(" ") || value.Contains(" ")
                || name.Contains("=") || value.Contains("="))
            {
                return false;
            }
            else
            {
                configSettings.Add((name, value));
                return true;
            }
        }
    }
}
