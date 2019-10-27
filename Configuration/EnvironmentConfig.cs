using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            if (name is null)
            {
                value = null;
                return false;
            }
            value = Environment.GetEnvironmentVariable(name);
            return true;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (name is null) return false;
            Environment.SetEnvironmentVariable(name, value);
            return true;
        }
    }
}
