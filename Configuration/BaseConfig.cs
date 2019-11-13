using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Configuration
{
    // MMM Comment: Yes!!! You refactored.  Nice job!!!!
    public abstract class BaseConfig : IConfig
    {
        public abstract bool GetConfigValue(string name, out string? value);
        public abstract bool SetConfigValue(string name, string? value);
        public abstract void DeleteAllConfigs();

        // strict: matches 1 or more of anything that isn't alphanumeric, underscore, or dash
        // lax: matches to 1 or more of '=' or whitespace
        public static bool IsInvalidString(string? name, bool strict = true)
        {
            // MMM Config: Nice use of regex.
            return string.IsNullOrEmpty(name) || ( strict ? Regex.IsMatch(name, "[^\\d\\w\\-]+") : Regex.IsMatch(name, "[=\\s]+") );
        }

        public static bool IsInvalidKeyValuePair(string? key, string? value, bool allowNullValue = true, bool strictNaming = true)
        {
            bool invalidKey = IsInvalidString(key, strictNaming);

            bool invalidValue;
            if (string.IsNullOrEmpty(value))
            {
                if (value is null)
                {
                    invalidValue = !allowNullValue;
                }
                else
                {
                    invalidValue = true;
                }
            }
            else
            {
                invalidValue = IsInvalidString(value, strictNaming);
            }

            return invalidKey || invalidValue;
        }
    }
}
