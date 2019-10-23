using System;
using System.Linq;
using System.Collections.Generic;

namespace Configuration
{
    public class Config : IConfig
    {
        public Dictionary<string, string?> ConfigDict { get; set; }

        public Config()
        {
            ConfigDict = new Dictionary<string, string?>();
        }

        public (string, string?) ParseConfigString(string input)
        {
            if (input.Count(c => c == '=') != 1)
            {
                throw new ArgumentException("Config string does not contain exactly one '='.");
            }
            else
            {
                // Because there is only one '=', we know that
                // when the string is split on '=', the resulting list
                // will have a length of two.
                string[] values = input.Split('=');
                var config = (name: values[0], value: values[1]);
                return config;
            }

        }

        public virtual void ParseToConfigDict(string input)
        {
            var (key, value) = ParseConfigString(input);
            ConfigDict[key] = value;
        }

        public virtual bool GetConfigValue(string name, out string? value)
        {
            if (ConfigDict.ContainsKey(name))
            {
                value = ConfigDict[name];
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }

        public virtual bool SetConfigValue(string name, string value)
        {
            ConfigDict[name] = value;
            return true;
        }
    }
}
