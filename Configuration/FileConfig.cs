using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    public class FileConfig : BaseConfig
    {
        private const string _CONFIG_FILENAME = "config.settings";
        // MMM Comment: Yes, read-only!
        // MMM Comment: I suggest making this a read-only property.
        private readonly List<KeyValuePair<string,string>> _KVPairs;

        // MMM Comment: Fields should never be accessed outside the
        // property that wraps thems - thus allowing validation to
        // be insterted without changing code.
        public FileConfig()
        {
            _KVPairs = new List<KeyValuePair<string, string>>();

            if (File.Exists(_CONFIG_FILENAME))
            {
                // MMM Comment: Shame you didn't have test for this... it would seem
                // worth testing.

                // read in settings from file into the backing list
                foreach (string kv in File.ReadAllLines(_CONFIG_FILENAME))
                {
                    // MMM Comment: Where to you validate that there are
                    // two values returned (that the kv contains "=").
                    // Since files are editable outside an application, this seems
                    // worth considering.
                    string[] split = kv.Split('=');
                    _KVPairs.Add(new KeyValuePair<string, string>(split[0], split[1]));
                }
            }
        }

        // MMM Comment: This isn't adding sufficient value to warrent its own method IMO.
        public override void DeleteAllConfigs()
        {
            File.Delete(_CONFIG_FILENAME);
        }

        public override bool GetConfigValue(string name, out string? value)
        {
            if (IsInvalidString(name))
            {
                value = "";
                return false;
            }
            
            // search the backing list, much faster than reading from file each time
            KeyValuePair<string, string> kv = _KVPairs.Find(kv => kv.Key.Equals(name));

            // Wouldn't kv.Key == name be clearer?
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
            // allow null values, we treat them as a "delete key" option
            if (IsInvalidKeyValuePair(name, value)) return false;

            // remove any existing matching keys
            int removed = _KVPairs.RemoveAll(kv => kv.Key.Equals(name));

            if (value != null)
            {
                // if it wasn't deletion by setting value null, add new/updated config
                _KVPairs.Add(new KeyValuePair<string, string>(name, value));
            }

            if (removed > 0)
            {
                // if we removed anything, just overwrite file with updated settings
                // simpler than trying to modify the file on the fly
                using (StreamWriter writer = File.CreateText(_CONFIG_FILENAME))
                {
                    foreach (KeyValuePair<string, string> kv in _KVPairs)
                    {
                        writer.WriteLine($"{kv.Key}={kv.Value}");
                    }
                }

                return true;
            }

            if (value != null)
            {
                // if nothing was removed and a value was added, just append new config
                using (StreamWriter writer = File.AppendText(_CONFIG_FILENAME))
                {
                    writer.WriteLine($"{name}={value}");
                }

                return true;
            }

            // nothing was added or removed
            return false;
        }
    }
}
