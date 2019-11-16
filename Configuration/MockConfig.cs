using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    // MMM Comment: Why enable here when it is enabled in the project file?
#nullable enable
    // MMM Comment: Preferable for this to be in a test project.
    public class MockConfig : IConfig
    {
        // MMM Comment: Use underscore prefix for all filed names.
        private Dictionary<string, string> settings { get; set; }

        public MockConfig()
        {
            settings = new Dictionary<string, string>();
        }

        public bool GetConfigValue(string name, string? value)
        {
            if(name!=null && name!="" && !name.Contains("=") && !name.Contains(" "))
            {
                if(value != null && value != "" && !value.Contains("=") && !value.Contains(" "))
                {
                    return settings.TryGetValue(name,out value);
                }
            }
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (name != null && name != "" && !name.Contains("=") && !name.Contains(" "))
            {
                if (value != null && value != "" && !value.Contains("=") && !value.Contains(" "))
                {
                    settings.Add(name, value);
                    return true;
                }
            }
            return false;
        }
    }
}
