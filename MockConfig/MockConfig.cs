using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MockConfig
{
    public class MockConfig : IConfig
    {

        private List<Tuple<string, string?>> configList;

        public MockConfig()
        {
            configList = new List<Tuple<string, string?>>();

            configList.Add(new Tuple<string, string?>("NAME1", "VALUE1"));
            configList.Add(new Tuple<string, string?>("NAME2", "VALUE2"));
            configList.Add(new Tuple<string, string?>("NAME3", "VALUE3"));
            configList.Add(new Tuple<string, string?>("NAME4", "VALUE4"));
        }

        public bool GetConfigValue(string name, string? value)
        {
            foreach (Tuple<string, string?> item in configList)
            {
                if (item.Item1.Contains(name))
                {
                    value = item.Item2;
                    return true;
                }
            }
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (value is null || value.Contains(' ') || value.Contains('=') || value.Equals(""))
            {
                return false;
            }
            else
            {
                Tuple<string, string?> configItem = new Tuple<string, string?>(name, value);
                configList.Add(configItem);
                return true;
            }
        }
    }
}
