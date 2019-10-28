using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        private List<string> _keys;

        public EnvironmentConfig()
        {
            _keys = new List<string>();
        }

        ~EnvironmentConfig() => CleanUp();

        public void CleanUp()
        {
            foreach (string key in _keys) Environment.SetEnvironmentVariable(key, null);
        }

        public bool GetConfigValue(string name, out string? value)
        {
            if(this.IsInvalidKeyName(name))
            {
                value = "";
                return false;
            }

            value = Environment.GetEnvironmentVariable(name);

            if (value is null)
            {
                value = "";
                return false;
            }

            return true;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (this.IsInvalidKeyName(name)) return false;

            if (value is null)
            {
                _keys.Remove(name);
            }
            else
            {
                _keys.Add(name);
            }

            Environment.SetEnvironmentVariable(name, value);
            return true;
        }
    }
}
