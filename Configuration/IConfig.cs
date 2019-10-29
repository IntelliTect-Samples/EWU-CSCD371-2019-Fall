using System;
using System.Collections.Generic;

namespace Configuration
{
    public interface IConfig
    {
        public bool ReadConfigValue(string name, out string? value);

        public bool WriteConfigValue(string name, string? value);
    }
}
