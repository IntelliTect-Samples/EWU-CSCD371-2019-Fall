using System;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool ReadConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        public bool WriteConfigValue(string name, string? value)
        {
            if (value is null)
            {
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
            if (string.IsNullOrEmpty(name) || name.Contains(" ") || name.Contains("=") ||
                value.Contains(" ") || value.Contains("=") || value.Equals(""))
            {
                return false;
            }
            Environment.SetEnvironmentVariable(name, value);

            return true;
        }
    }
}
