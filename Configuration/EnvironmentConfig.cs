using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        private List<String> EnvironmentNames = new List<String>();

        public bool GetConfigValue(string name, out string? value)
        {
            value =  Environment.GetEnvironmentVariable(name);

            if (value is null)
            {
                return false;
            }

            return true;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if(IsValidInput(name, value))
            {
                EnvironmentNames.Add(name);
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
        
            return false;
        }

        public static bool IsValidInput(string name, string? value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
            {
                return false;
            }
            else if (name.Contains(" ") || name.Contains("=") || value.Contains("="))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        ~EnvironmentConfig()
        {
            foreach(string name in EnvironmentNames)
            {
                Environment.SetEnvironmentVariable(name, null);
            }
        }
    }
}
