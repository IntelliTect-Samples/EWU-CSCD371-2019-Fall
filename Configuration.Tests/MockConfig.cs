using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    class MockConfig : IConfig
    {
        private Dictionary<string, string?> keyValuePairs = new Dictionary<string, string?>();

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
