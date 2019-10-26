using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    class FileConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            throw new NotImplementedException();
        }

        public bool SetConfigValue(string name, string? value)
        {
            throw new NotImplementedException();
        }
    }
}
