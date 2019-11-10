using System;
using System.Linq;
using System.Collections.Generic;

namespace Configuration
{
    public class EnvironmentConfig : Config
    {
        private List<string> UsedKeys;

        public EnvironmentConfig()
        {
            UsedKeys = new List<string>();
        }

        public override bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value == null);
        }

        public override bool SetConfigValue(string name, string? value)
        {
            SanitizeValue(name);
            SanitizeValue(value);
            Environment.SetEnvironmentVariable(name, value);
            UsedKeys.Add(name);
            return true;
        }

        // Using destructor for automatic cleanup
        // Also using helper function if manual
        // cleanup is desired.
        public void Cleanup()
        {
            foreach (string key in UsedKeys)
            {
                Console.WriteLine($"Key: {key}");
                Environment.SetEnvironmentVariable(key, null);
            }
        }

        /// MMM Comment: This pattern should also implement IDisposable
        ~EnvironmentConfig() => Cleanup();
    }
}
            
