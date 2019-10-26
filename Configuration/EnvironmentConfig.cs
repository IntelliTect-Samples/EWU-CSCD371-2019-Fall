using System;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        public bool SetConfigValue(string name, string value)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            try
            {
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
            catch (System.Security.SecurityException)
            {
                return false;
            }
        }
    }
}
