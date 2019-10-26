using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            try
            {
                value = Environment.GetEnvironmentVariable(name);
            }
            catch (ArgumentNullException)
            {
                value = null;
                return false;
            }

            return true;
        }

        public bool SetConfigValue(string name, string? value)
        {
            try
            {
                if (name is null || name.Contains(' ', 0)) { throw new ArgumentException(name); }
                Environment.SetEnvironmentVariable(name, value);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
    }
}
