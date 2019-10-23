using System;
using System.Collections.Generic;

namespace Configuration
{
    public interface IConfig
    {
        public bool GetConfigValue(string name, out string? value);

        public bool SetConfigValue(string name, string? value);
    }
}
