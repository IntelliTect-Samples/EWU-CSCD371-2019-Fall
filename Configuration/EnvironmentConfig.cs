using System;
using System.Collections.Generic;

namespace Configuration
{
    public sealed class EnvironmentConfig : IConfig
    {
        private List<string> setNames;

        public EnvironmentConfig()
        {
            setNames = new List<string>();
        }

        public bool GetConfigValue(string name, string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            if (value is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (value is null)
            {
                return false;
            }
            else
            {
                setNames.Add(name);
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
        }

        ~EnvironmentConfig()
        {
            foreach(string name in setNames)
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }
    }
}
