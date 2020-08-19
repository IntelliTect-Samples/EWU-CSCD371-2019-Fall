using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.Tests
{
    public class MockConfig : BaseConfig
    {
        private readonly Dictionary<string, string> ConfigValues = new Dictionary<string, string>();

        public MockConfig()
        {
            for (int i = 0; i < 5; i++)
            {
                SetConfigValue($"test{i}", $"value{i}");
            }
        }

        public override bool GetConfigValue(string name, out string? value)
        {
            if (!CheckValidConfigName(name))
            {
                throw new ArgumentException("Parameter name cannot contain ' ', '=', or be null or empty", nameof(name));
            }

            return ConfigValues.TryGetValue(name, out value);
        }

        public override bool SetConfigValue(string name, string? value)
        {
            if (!CheckValidConfigName(name))
            {
                throw new ArgumentException("Parameter name cannot contain ' ', '=', or be null or empty", nameof(name));
            }

            if (string.IsNullOrEmpty(value))
            {
                return ConfigValues.Remove(name);
            }
            else
            {
                if (ConfigValues.ContainsKey(name))
                {
                    ConfigValues.Remove(name);
                    ConfigValues.Add(name, value);
                    return true;
                }
                ConfigValues.Add(name, value);
                return true;
            }

        }
    }
}
