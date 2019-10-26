using System;
using System.Collections.Generic;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        private List<string> valueNames;

        public EnvironmentConfig()
        {
            valueNames = new List<string>();
        }

        public bool GetConfigValue(string name, string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            if (value is null)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (value is null)
            {
                return false;
            } else
            {
                valueNames.Add(name);
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
        }

        ~EnvironmentConfig()
        {
            foreach(string name in valueNames)
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }
    }
}
