using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Configuration
{

    public class MockConfig : IConfig
    {

        private readonly Dictionary<string, string> _kvps = new Dictionary<string, string>();

        public bool GetConfigValue(string name, out string? value)
        {
            if (_kvps.ContainsKey(name))
            {
                return _kvps.TryGetValue(name, out value);
            }

            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (name is null || name.Length == 0 || new Regex("[\\s=]").IsMatch(name))
            {
                throw new ArgumentException("Invalid Key Name", nameof(name));
            }

            if (value is null
             || value.Length == 0
             || !new Regex("(\"([^\"]|\"\")*\")|(\'([^\']|\'\')*\')").IsMatch(value) && value.Contains(" ")
             || value.Contains("="))
            {
                throw new ArgumentException("Invalid Value", nameof(value));
            }

            _kvps.Add(name, value);
            return true;
        }

    }

}
