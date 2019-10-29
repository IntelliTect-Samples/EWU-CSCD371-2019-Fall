using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    #nullable enable

    public class MockConfig : IConfig
    {
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
