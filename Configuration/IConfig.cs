using System;
using System.Collections.Generic;

namespace Configuration
{
    public interface IConfig
    {
        public bool GetConfigValue(string name, out string? value);

        // Notice that input value is not nullable anymore
        public bool SetConfigValue(string name, string value);
    }
}
