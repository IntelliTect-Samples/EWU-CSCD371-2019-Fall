using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Configuration
{
    public static class ConfigExtensions
    {
        public static void ValidateInput(this IConfig config, string name, string value)
        {
            if (string.IsNullOrEmpty(name)
                || name.Contains(" ")
                || name.Count(c => c == '=') > 1)
                throw new ArgumentException("Name contains invalid character or is empty");

            if (string.IsNullOrEmpty(value)
                || value.Contains(" ")
                || value.Count(c => c == '=') > 1)
                throw new ArgumentException("Value contains invalid character or is empty");
        }
    }
}
