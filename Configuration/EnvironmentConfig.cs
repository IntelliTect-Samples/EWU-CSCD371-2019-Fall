using System;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            value = "";
            if (!nameCheck(name))
                return false;

            value = Environment.GetEnvironmentVariable(name);

            return !string.IsNullOrEmpty(value);
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (!nameCheck(name) || !valueCheck(value))
                return false;

            Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.Process);
            return true;
        }

        private static bool nameCheck(string? name)
        {
            if (name is null)
                throw new ArgumentException($"The name: {name} is null and not allowed.");

            else if(string.IsNullOrEmpty(name))
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
