using System;
using System.Collections.Generic;

namespace Configuration.Tests
{
    public class MockConfig : IConfig
    {
        public MockConfig()
        {
            //These settings are for MacOS
            Settings.Add("PATH");
            Settings.Add("USER");
            Settings.Add("LANG");
            Settings.Add("SHELL");
            Settings.Add("TERM");
            //These settings are for Windows
            Settings.Add("OS");
            Settings.Add("HOMEPATH");
            Settings.Add("WINDIR");
            Settings.Add("NUMBER_OF_PROCESSORS");
            Settings.Add("PROCESSOR_LEVEL");
        }

        public List<string> Settings { get; } = new List<string>();

        public bool ReadConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        public bool WriteConfigValue(string name, string? value)
        {
            if (string.IsNullOrEmpty(name) || name.Contains("=") || name.Contains(" "))
            {
                return false;
            }
            Environment.SetEnvironmentVariable(name, value);
            return true;
        }
    }
}
