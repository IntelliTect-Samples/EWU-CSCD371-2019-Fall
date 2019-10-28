using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            
            if(value is null)
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
            if(value is null)
            {
                return false;
            }
            else
            {
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
        }
    }
}
