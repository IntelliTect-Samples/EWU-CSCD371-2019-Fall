using System;

namespace Configuration
{
    public class EnvironmentConfig : Config
    {
        public override bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        public override bool SetConfigValue(string name, string? value)
        {
            Environment.SetEnvironmentVariable(name, value);
            return true;
        }
    }
}
            
