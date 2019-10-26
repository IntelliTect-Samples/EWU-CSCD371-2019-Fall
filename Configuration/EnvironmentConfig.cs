using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, string? value)
        {
            return value == Environment.GetEnvironmentVariable(name);
        }

        public bool SetConfigValue(string name, string? value)
        {
            Environment.SetEnvironmentVariable(name, value);
            return GetConfigValue(name, value);
        }
    }
}
