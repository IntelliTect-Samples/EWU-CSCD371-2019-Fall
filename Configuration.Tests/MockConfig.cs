using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    public class MockConfig : IConfig
    {
        private Dictionary<string, string?> keyValuePairs = new Dictionary<string, string?> 
        {
            {"USERPROFILE","test1"},
            {"TEMP","test2"},
            {"OS","test3"},
            {"windir","test4"},
            {"PATHEXT","test5"},
            {"DriverData","test6"},
            {"NUMBER_OF_PROCESSORS","test7"},
        };

        public bool GetConfigValue(string name, out string? value)
        {
            value = keyValuePairs[name];
            return !(value is null);
        }

        public bool SetConfigValue(string name, string? value)
        {
            keyValuePairs.Add(name, value);
            return GetConfigValue(name, out value);
        }
    }
}
