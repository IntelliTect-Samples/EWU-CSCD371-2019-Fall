using System;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            if (!(ConfigUtils.IsValidName(name)))
            {
                value = null;
                return false;
            }
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (!(value is null) && ConfigUtils.IsValidName(name))
            {
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
            return false;
        }
    }
}