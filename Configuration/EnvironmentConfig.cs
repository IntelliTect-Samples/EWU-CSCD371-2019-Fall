using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        private List<string> ConfigNames = new List<string>();

        public bool GetConfigValue(string name, string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            if(value is null)
            {
                return false;
            }
            return true;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if(value is null)
            {
                return false;
            }
            else
            {
                ConfigNames.Add(name);
                Environment.SetEnvironmentVariable(name, value);
            }
            return true;
        }

        ~EnvironmentConfig()
        {
            foreach(string name in ConfigNames)
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }

    }
}
