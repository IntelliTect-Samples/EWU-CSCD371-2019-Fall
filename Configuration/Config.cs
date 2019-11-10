using System;
using System.Linq;
using System.Collections.Generic;

namespace Configuration
{
    public class Config : IConfig
    {
        // MMM Comment: While it is not wrong, I would likely spell out Dictionary rather than Dict.
        // MMM Comment: Why is the dictionary Read/Write?  I would have expected a child.
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

        /// MMM Comment: This method doesn't seem to actually do any sanitization, perhaps there is a better name?
        public static void SanitizeValue(string? value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException($"Cannot pass null or empty value for {nameof(value)}.");
            // Please disable 1307 in the future.
            else if (value.Contains('='))
                // Great to see you are using the nameof operator.
                throw new ArgumentException($"Cannot pass '=' char in {nameof(value)}.");
            else if (value.Contains(' '))
                throw new ArgumentException($"Cannot pass whitespace in {nameof(value)}.");
        }
    }
}
