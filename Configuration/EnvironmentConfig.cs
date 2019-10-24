using System;
using System.Xml;

namespace Configuration
{
    public sealed class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, string? value)
        {
            if(Environment.GetEnvironmentVariable(name) is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (value is null)
            {
                return false;
            }
            else
            {
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
        }

        //~EnvironmentConfig()
        //{
        //    //some kind of cleanup?
        //}
    }
}
