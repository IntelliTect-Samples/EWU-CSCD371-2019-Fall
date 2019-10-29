using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : BaseConfig
    {
        // backing list of keys to make sure any env vars created can be easily removed
        // dont care what the values are
        private readonly List<string> _Keys;

        public EnvironmentConfig()
        {
            _Keys = new List<string>();
        }

        ~EnvironmentConfig() => DeleteAllConfigs();

        public override void DeleteAllConfigs()
        {
            foreach (string key in _Keys) Environment.SetEnvironmentVariable(key, null);
        }

        public override bool GetConfigValue(string name, out string? value)
        {
            if(IsInvalidString(name))
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
            if (IsInvalidKeyValuePair(name, value)) return false;

            // setting null value on env var deletes that key
            Environment.SetEnvironmentVariable(name, value);

            if (value is null)
            {
                _Keys.Remove(name);
            }

            if (!_Keys.Exists(key => key.Equals(name)))
            {
                _Keys.Add(name);
            }

            return true;
        }
    }
}
