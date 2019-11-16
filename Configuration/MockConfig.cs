using System;
using System.Collections.Generic;

namespace Configuration
{
    public class MockConfig : IConfig
    {
        // MMM Comment: Prefix fields with underscore or, even better, us PascalCase with a property.
        private Dictionary<string, string> treeValuePairs;

        private const string EQUALS = "=";
        private const string SPACE = " ";

        public MockConfig()
        {
            treeValuePairs = new Dictionary<string, string>();
            treeValuePairs.Add("TestingOne", "1");
            treeValuePairs.Add("testingTwo", "2");
            treeValuePairs.Add("testingthree", "3");
        }

        public bool GetConfigValue(string key, out string? value)
        {
            value = "";
            if (!nameCheck(key))
                return false;

            else if (treeValuePairs.ContainsKey(key))
                value = treeValuePairs[key];

            return !string.IsNullOrEmpty(value);
        }

        public bool SetConfigValue(string key, string? value)
        {
            if (!nameCheck(key) || !valueCheck(value))
                return false;

            else if (treeValuePairs.ContainsKey(key))
                // MMM Comment: Use null forgiveness operator here.
#pragma warning disable CS8601 // null reference
                treeValuePairs[key] = value;
#pragma warning restore CS8601 // null reference

            else
#pragma warning disable CS8604
                // MMM Comment: Use null forgiveness operator here.
                treeValuePairs.Add(key, value);
#pragma warning restore CS8604 

            return true;
        }

        private static bool nameCheck(string? key)
        {
            // MMM Comment: Inculude parameter name parameter with nameof operator.
            if (key is null)
                throw new ArgumentException($"The name: {key} is null!");

            else if (string.IsNullOrEmpty(key))
                throw new ArgumentException($"The name: {key} is empty and therefore invalid.");

            else if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"The name: {key} is just whitespace and therefore invalid.");

            // MMM Comment: Perhaps turn this off for the entire project?
#pragma warning disable CA1307 // Specify StringComparison
            else if (key.Contains(SPACE))
#pragma warning restore CA1307 // Specify StringComparison
                throw new ArgumentException($"The name: {key} contains spaces and this is not allowed.");

#pragma warning disable CA1307 
            else if (key.Contains(EQUALS))
#pragma warning restore CA1307 
                throw new ArgumentException($"The name: {key} cannot contains \'=\'.");

            return true;
        }

        private static bool valueCheck(string? value)
        {
            if (value is null)
                throw new ArgumentException($"The value: {value} is null!");

            else if (string.IsNullOrEmpty(value))
                throw new ArgumentException($"The value: {value} is empty and therefore invalid.");

            return true;
        }
    }
}