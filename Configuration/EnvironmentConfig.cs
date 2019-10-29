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

        public bool GetConfigValue(string name, out string? value)
        {
            if (name is null)
            {
                throw new ArgumentNullException("Name of variable cannot be null");
            }
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
            if (name is null)
            {
                throw new ArgumentNullException("Name of variable cannot be null");
            }
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
