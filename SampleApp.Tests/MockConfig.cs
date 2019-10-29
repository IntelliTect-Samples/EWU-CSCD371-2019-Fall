using System;
using System.Collections.Generic;
using Configuration;

namespace SampleApp.Tests
{
    public class MockConfig : IConfig
    {
        public List<(string, string)> Settings { get; private set; } = new List<(string, string)>();

        public MockConfig()
        {
            CreateSettings();
        }

        public bool GetConfigValue(string name, out string? value)
        {
            foreach ((string, string) setting in Settings)
            {
                if (setting.Item1.Equals(name))
                {
                    value = setting.Item2;
                    return !(value is null);
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (value is null)
            {
                Settings.Add((name, ""));
            }
            else
            {
                Settings.Add((name, value));
            }
            return true;
        }

        private void CreateSettings()
        {
            SetConfigValue("name1", "value1");
            SetConfigValue("name2", "value2");
            SetConfigValue("name3", "value3");
            SetConfigValue("name4", "value4");
            SetConfigValue("name5", "value5");
        }

        public List<string> GetAllConfigValues()
        {
            var list = new List<string>();
            foreach ((string name, string value) in Settings)
            {
                list.Add($"{name}={value}");
            }

            return list;
        }

        public void ClearConfig()
        {
            Settings = new List<(string, string)>();
        }
    }
}
