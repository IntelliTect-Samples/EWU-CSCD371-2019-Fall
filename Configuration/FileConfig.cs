using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    public class FileConfig : BaseConfig
    {
        private const string CONFIG_FILENAME = "config.settings";
        private List<KeyValuePair<string,string>> _kvPairs;

        public FileConfig()
        {
            _kvPairs = new List<KeyValuePair<string, string>>();

            if (File.Exists(CONFIG_FILENAME))
            {
                // read in settings from file into the backing list
                foreach (string kv in File.ReadAllLines(CONFIG_FILENAME))
                {
                    string[] split = kv.Split('=');
                    _kvPairs.Add(new KeyValuePair<string, string>(split[0], split[1]));
                }
            }
        }

        public override void DeleteAllConfigs()
        {
            File.Delete(CONFIG_FILENAME);
        }

        public override bool GetConfigValue(string name, out string? value)
        {
            if (IsInvalidKeyName(name))
            {
                value = "";
                return false;
            }
            
            // search the backing list, much faster than reading from file each time
            KeyValuePair<string, string> kv = _kvPairs.Find(kv => kv.Key.Equals(name));

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
            if (IsInvalidKeyName(name)) return false;

            // remove any existing matching keys
            int removed = _kvPairs.RemoveAll(kv => kv.Key.Equals(name));

            if (value != null)
            {
                // if it wasn't deletion by setting value null, add new/updated config
                _kvPairs.Add(new KeyValuePair<string, string>(name, value));
            }

            if (removed > 0)
            {
                // if we removed anything, just overwrite file with updated settings
                // simpler than trying to modify the file on the fly
                using (StreamWriter writer = File.CreateText(CONFIG_FILENAME))
                {
                    foreach (KeyValuePair<string, string> kv in _kvPairs)
                    {
                        writer.WriteLine($"{kv.Key}={kv.Value}");
                    }
                }

                return true;
            }

            if (value != null)
            {
                // if nothing was removed and a value was added, just append new config
                using (StreamWriter writer = File.AppendText(CONFIG_FILENAME))
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
