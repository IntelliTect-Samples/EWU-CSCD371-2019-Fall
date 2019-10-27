using System;
using System.Collections.Generic;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {

        private List<string> keys;

        public EnvironmentConfig() 
        {
            keys = new List<string>();
        }

        public bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        public bool SetConfigValue(string name, string? value)
        {
            Environment.SetEnvironmentVariable(name, value);
            keys.Add(name);
            return GetConfigValue(name, out _);
        }
    }
}
