using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        private string settingsPath = "config.settings";

        public bool GetConfigValue(string name, out string? value)
        {
            if (!isValidName(name) || !File.Exists(settingsPath))
            {
                value = null;
                return false;
            }

            foreach(string setting in File.ReadAllLines(settingsPath))
            {
                if (setting.StartsWith(name, StringComparison.CurrentCulture))
                {
                    string[] nameAndValue = setting.Split("=");
                    if (nameAndValue.Length != 2)
                    {
                        throw new FormatException("Invalid Setting In " + settingsPath);
                    }
                    else
                    {
                        value = nameAndValue[1];
                        return true;
                    }
                }
            }

            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (!isValidName(name) || value is null) { return false; }

            Hashtable settingsHashTable = new Hashtable();

            if (File.Exists(settingsPath))
            {
                string[] fileText = File.ReadAllLines(settingsPath);
                
                foreach(string setting in fileText)
                {
                    string[] nameAndValue = setting.Split('=');
                    if (nameAndValue.Length != 2) { throw new FormatException("Invalid Setting In " + settingsPath); }

                    try
                    {
                        settingsHashTable.Add(nameAndValue[0], nameAndValue[1]);
                    }
                    catch (ArgumentException)
                    {
                        throw new FormatException("Duplicate Entry In " + settingsPath);
                    }
                }
            }

            settingsHashTable.Remove(name);
            settingsHashTable.Add(name, value);

            string[] keys = new string[settingsHashTable.Count];
            string[] values = new string[settingsHashTable.Count];
            string[] keyValuePairs = new string[settingsHashTable.Count];

            settingsHashTable.Keys.CopyTo(keys, 0);
            settingsHashTable.Values.CopyTo(values, 0);

            for (int i = 0; i < keyValuePairs.Length; i++)
            {
                keyValuePairs[i] = keys[i] + '=' + values[i];
            }

            File.WriteAllLines(settingsPath, keyValuePairs);
            
            return true;
        }

        private static bool isValidName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Contains(' ', StringComparison.CurrentCulture) || name.Contains('=', StringComparison.CurrentCulture))
            {
                return false;
            }

            return true;
        }
    }
}
