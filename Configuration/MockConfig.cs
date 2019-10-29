using System;
using System.Collections.Generic;

namespace Configuration
{
    public class MockConfig : IConfig
    {
        private Dictionary<string, string> dictionary;

        public MockConfig()
        {
            dictionary = new Dictionary<string, string>();
            dictionary.Add("Test1", "1");
            dictionary.Add("Test2", "2");
            dictionary.Add("Test3", "3");
        }

        public bool GetConfigValue(string name, out string? value)
        {
            value = "";
            if (!nameCheck(name))
                return false;

            else if (dictionary.ContainsKey(name))
                value = dictionary[name];

            return !string.IsNullOrEmpty(value);
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (!nameCheck(name) || !valueCheck(value))
                return false;

            else if (dictionary.ContainsKey(name))
#pragma warning disable CS8601 // Possible null reference assignment. Confirmed not null by strCheck
                dictionary[name] = value;
#pragma warning restore CS8601 // Possible null reference assignment. Confirmed not null by strCheck

            else
#pragma warning disable CS8604 // Possible null reference argument. Confirmed not null by strCheck
                dictionary.Add(name, value);
#pragma warning restore CS8604 // Possible null reference argument. Confirmed not null by strCheck

            return true;
        }

        private static bool nameCheck(string? name)
        {
            if (name is null)
                throw new ArgumentException($"The name: {name} is null and not allowed.");

            else if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"The name: {name} is empty and not allowed.");

            else if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"The name: {name} is just whitespace and not allowed.");

#pragma warning disable CA1307 // Specify StringComparison
            else if (name.Contains(" "))
#pragma warning restore CA1307 // Specify StringComparison
                throw new ArgumentException($"The name: {name} contains spaces and is not allowed.");

#pragma warning disable CA1307 // Specify StringComparison
            else if (name.Contains("="))
#pragma warning restore CA1307 // Specify StringComparison
                throw new ArgumentException($"The name: {name} contains \'=\' and is not allowed.");

            return true;
        }

        private static bool valueCheck(string? value)
        {
            if (value is null)
                throw new ArgumentException($"The value: {value} is null and not allowed.");

            else if (string.IsNullOrEmpty(value))
                throw new ArgumentException($"The value: {value} is empty and not allowed.");

            return true;
        }
    }
}
