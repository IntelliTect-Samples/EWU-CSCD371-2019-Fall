using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    class EnvironmentConfig : BaseConfig
    {
        public override bool GetConfigValue(string name, out string? value)
        {
            if (!CheckValidConfigName(name))
            {
                throw new ArgumentException("Parameter name cannot contain ' ', '=', or be null or empty", nameof(name));
            }

            value = Environment.GetEnvironmentVariable(name);
            if (value is object)
            {
                return true;
            }
            return false;
        }

        public override bool SetConfigValue(string name, string? value)
        {
            if (!CheckValidConfigName(name))
            {
                throw new ArgumentException("Parameter name cannot contain ' ', '=', or be null or empty", nameof(name));
            }
            
            Environment.SetEnvironmentVariable(name, value);
            return true;//Change
        }
    }
}
