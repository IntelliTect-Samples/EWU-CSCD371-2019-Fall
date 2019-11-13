using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : BaseConfig
    {
        // backing list of keys to make sure any env vars created can be easily removed
        // dont care what the values are
        // MMM Comment: Consider read only property here.
        private readonly List<string> _Keys;

        public EnvironmentConfig()
        {
            _Keys = new List<string>();
        }

        // MMM Comment: Wait, why?  Surely this is mostly useful across instances of the app?
        // I would expect to see cleanup like this in the tests but not the system under test.
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

            // MMM Comment: Just return (value is object) or !(value is null)
            if (value is null)
            {
                // MMM Comment: This line isn't needed given you set it above?
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

            // MMM Comment: And if it does exist... how will it get updated to
            // a new value?
            if (!_Keys.Exists(key => key.Equals(name)))
            {
                _Keys.Add(name);
            }

            return true;
        }
    }
}
