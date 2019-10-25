using System;
using System.Linq;
using System.Collections.Generic;

namespace Configuration
{
    public class Config : IConfig
    {
        private Dictionary<string, string?> ConfigDict { get; set; }

        public Config()
        {
            ConfigDict = new Dictionary<string, string?>();
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

        public virtual bool SetConfigValue(string name, string? value)
        {
            ConfigDict[name] = value;
            return true;
        }
    }
}
