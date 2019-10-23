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
            Environment.SetEnvironmentVariable(name, value);
            UsedKeys.Add(name);
            return true;
        }

        // Using destructor for automatic cleanup
        public void Cleanup()
        {
            foreach (string key in UsedKeys)
            {
                Console.WriteLine($"Key: {key}");
                Environment.SetEnvironmentVariable(key, null);
            }
        }

        ~EnvironmentConfig() => Cleanup();
    }
}
            
