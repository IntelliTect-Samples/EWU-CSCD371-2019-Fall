using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : BaseConfig
    {
        // backing list of keys to make sure any env vars created can be easily removed
        // dont care what the values are
        private List<string> _keys;

        public EnvironmentConfig()
        {
            _keys = new List<string>();
        }

        ~EnvironmentConfig() => DeleteAllConfigs();

        public override void DeleteAllConfigs()
        {
            foreach (string key in _keys) Environment.SetEnvironmentVariable(key, null);
        }

        public override bool GetConfigValue(string name, out string? value)
        {
            if(IsInvalidKeyName(name))
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

        public override bool SetConfigValue(string name, string? value)
        {
            if (IsInvalidKeyName(name)) return false;

            // setting null value on env var deletes that key
            Environment.SetEnvironmentVariable(name, value);

            if (value is null)
            {
                _keys.Remove(name);
            }

            if (!_keys.Exists(key => key.Equals(name)))
            {
                _keys.Add(name);
            }

            return true;
        }
    }
}
