using System;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {

        private const string EQUALS = "=";
        private const string SPACE = " ";
        public bool GetConfigValue(string key, out string? pair)
        {
            pair = "";
            if (!nameCheck(key))
                return false;

            pair = Environment.GetEnvironmentVariable(key);

            return !string.IsNullOrEmpty(pair);
        }

        public bool SetConfigValue(string key, string? pair)
        {
            if (!nameCheck(key) || !valueCheck(pair))
                return false;

            Environment.SetEnvironmentVariable(key, pair, EnvironmentVariableTarget.Process);
            return true;
        }

        // MMM Comment: Use Pascal Case for all members.
        // MMM Comment: Good to see you refactored the parameter validation logic out.
        private static bool nameCheck(string? key)
        {
            if (key is null)
                // MMM Comment: Throw ArgumentNullException here.
                throw new ArgumentException($"The name: {key} is null!");

            else if (string.IsNullOrEmpty(key))
                throw new ArgumentException($"The name: {key} is empty and therefore invalid.");

            else if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException($"The name: {key} is just whitespace therefore invalid.");

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

        private static bool valueCheck(string? pair)
        {
            if (pair is null)
                throw new ArgumentException($"The value: {pair} is null!");

            else if (string.IsNullOrEmpty(pair))
                throw new ArgumentException($"The value: {pair} is empty and therefore invalid.");

            return true;
        }
    }
}