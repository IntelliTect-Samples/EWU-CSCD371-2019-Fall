using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Configuration
{
    public abstract class BaseConfig : IConfig
    {
        public abstract bool GetConfigValue(string name, out string? value);
        public abstract bool SetConfigValue(string name, string? value);
        public abstract void DeleteAllConfigs();

        public static bool IsInvalidKeyName(string key)
        {
            // lax: "[=\\s]+" matches to 1 or more of '=' or whitespace
            // strict: "[^a-Z_]+" matches 1 or more of anything that isn't a to cap z, or underscore
            return string.IsNullOrEmpty(key) || Regex.IsMatch(key, "[=\\s]+");
        }
    }
}
