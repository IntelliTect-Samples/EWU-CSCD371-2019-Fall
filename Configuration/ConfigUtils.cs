using System;

namespace Configuration
{
    // MMM Comment: I like the refactoring here. :)
    public static class ConfigUtils
    {
        public static bool IsValidName(string? name)
        {
            if (String.IsNullOrEmpty(name))
                return false;
            if (name.Contains("=") || name.Contains(" "))
                return false;
            return true;
        }
    }
}