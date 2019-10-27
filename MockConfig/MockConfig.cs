using Configuration;
using System;
using System.Collections.Generic;

namespace MockConfig
{
    public class MockConfig : IConfig
    {
        private List<string> ConfigNames = new List<string>();

        public MockConfig()
        {
            
        }

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
