using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {

        private List<string> keyName;

        public EnvironmentConfig()
        {
            keyName = new List<string>();
        }
        public bool GetConfigValue(string name, string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            if (value == null)
            {
                return true;
            }
            else return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            Environment.SetEnvironmentVariable(name, value);
            // MMM Comment: "is null" preferable
            if (value == null)
            {
                return false;
            }
            else
            {
                keyName.Add(name);
                return true;
            }
        }

        // MMM Comment: Great to see the finalizer. 
        // MMM Commet: To do this correctly, it should be implemented with IDisposable.
        ~EnvironmentConfig()
        {
            foreach (string name in keyName)
                Environment.SetEnvironmentVariable(name, null);
        }
    }
}
