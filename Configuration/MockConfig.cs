using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Configuration
{
    public class MockConfig : IConfig
    {
        public List<MockSetting> tempSettings;

        public struct MockSetting
        {
            public string name;
            public string? value;
            public string toString()
            {
                return name + " : " + (value is null ? "null" : value);
            }
        }
        public MockConfig()
        {
            tempSettings = new List<MockSetting>();
        }
        public bool GetConfigValue(string name, out string? value)
        {
            if(name is null || name.Length < 1 || name.Contains(" ") || name.Contains("="))
            {
                value = null;
                return false;
            }
            foreach(MockSetting ms in tempSettings)
            {
                if (ms.name == name)
                {
                    value = ms.value;
                    return true;
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (name is null || name.Length < 1 || name.Contains(" ") || name.Contains("="))
            {
                return false;
            }

            MockSetting ms = new MockSetting { name = name, value = value };
            if (tempSettings.Contains(ms)) return false;
            tempSettings.Add(ms);
            return true;
        }
    }
}
