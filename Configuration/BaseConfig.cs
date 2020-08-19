using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public abstract class BaseConfig : IConfig
    {
        public abstract bool GetConfigValue(string name, out string? value);

        public abstract bool SetConfigValue(string name, string? value);

        public static bool CheckValidConfigName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Contains(' ') || name.Contains('='))
            {
                return false;
            }
            return true;
        }
    }
}
