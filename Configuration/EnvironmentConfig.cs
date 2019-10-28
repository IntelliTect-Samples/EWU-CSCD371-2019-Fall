using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : BaseConfig
    {
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
