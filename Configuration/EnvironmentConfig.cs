using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, string? value)
        {
            throw new NotImplementedException();
        }

        public bool SetConfigValue(string name, string? value)
        {
            throw new NotImplementedException();
        }
    }
}
