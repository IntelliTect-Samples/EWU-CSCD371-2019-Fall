using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        private List<string> ConfigNames = new List<string>();

        public bool GetConfigValue(string name, out string? value)
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
            if (name is null || name is "" || name.Contains("=", 0) || name.Contains(" ", 0))
            {
                value = null;
                return false;
            }

            if (value is null || value is "" || value.Contains("=", 0) || value.Contains(" ", 0))
            {
                value = null;
                return false;
            }
            ConfigNames.Add(name);
            Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.Process);
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
