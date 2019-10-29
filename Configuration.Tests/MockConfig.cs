using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    public class MockConfig : BaseConfig
    {
        private readonly List<KeyValuePair<string, string>> _KVPairs;

        public MockConfig() => _KVPairs = new List<KeyValuePair<string, string>>();

        public override void DeleteAllConfigs() => _KVPairs.Clear();

        public override bool GetConfigValue(string name, out string? value)
        {
            if (IsInvalidString(name))
            {
                value = "";
                return false;
            }

            KeyValuePair<string, string> kv = _KVPairs.Find(kv => kv.Key.Equals(name));

            // check keys match to make sure we found it (a failed find returns default values)
            if (string.Equals(kv.Key, name))
            {
                value = kv.Value;
                return true;
            }

            value = "";
            return false;
        }

        public override bool SetConfigValue(string name, string? value)
        {
            if (IsInvalidKeyValuePair(name, value)) return false;

            // remove any existing matching keys
            int removed = _KVPairs.RemoveAll(kv => kv.Key.Equals(name));

            if (value != null)
            {
                // if it wasn't deletion by setting value null, add new/updated config
                _KVPairs.Add(new KeyValuePair<string, string>(name, value));

                return true;
            }
            else if (removed > 0)
            {
                // deleted a key by passing null value
                return true;
            }

            // nothing was added or removed
            return false;
        }
    }
}
