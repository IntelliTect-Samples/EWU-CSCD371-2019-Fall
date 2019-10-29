using Configuration;
using System.Collections.Generic;

namespace SampleApp.Tests
{
    public class MockConfig : IConfig
    {
        private readonly List<Setting> Settings = new List<Setting>();

        public bool GetConfigValue(string name, out string? value)
        {
            if (ConfigUtils.IsValidName(name) && !(Settings is null))
            {
                foreach (Setting setting in Settings)
                {
                    if (setting.Name.Equals(name))
                    {
                        value = setting.Value;
                        return true;
                    }
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (ConfigUtils.IsValidName(name) && !(value is null))
            {
                Settings.Add(new Setting(name, value));
                return true;
            }
            return false;
        }
    }
}