using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Configuration
{
    public static class ExtensionIConfig
    {
        public static bool IsInvalidKeyName(this IConfig config, string key)
        {
            // regex string matches to 1 or more of whitespace or '='
            return string.IsNullOrEmpty(key) || Regex.IsMatch(key, "[=\\s]+");
        }
    }
}
