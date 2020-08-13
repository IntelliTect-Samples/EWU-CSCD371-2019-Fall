using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    class EnvironmentConfig : BaseConfig
    {
        public override bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            if (value is object)
            {
                return true;
            }
            return false;//Change
        }

        public override bool SetConfigValue(string name, string? value)
        {
            Environment.SetEnvironmentVariable(name, value);
            return true;//Change
        }
    }
}
