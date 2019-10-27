using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            if(name is null) throw new ArgumentNullException(nameof(name));

            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));

            Environment.SetEnvironmentVariable(name, value);
            return true;
        }
    }
}
