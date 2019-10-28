using System;
using System.Collections.Generic;
using System.Text;
using Configuration;

namespace Mock
{
    public class MockConfig : IConfig
    {
        private readonly Dictionary<string, string> configList;
        public MockConfig()
        {
            configList = new Dictionary<string, string>();

            configList.Add("testKey", "testValue");
            configList.Add("testKey1", "testValue1");
        }



        public bool GetConfigValue(string key, string value)
        {
            if (configList.ContainsKey(key))
            {
                Console.WriteLine("found the key: " + key + ", which containing value: " + value);
                return true;
            }
            else
            {
                Console.WriteLine("could not find the requested key");
                return false;
            }
        }

        public bool SetConfigValue(string key, string value)
        {
            if (key != null || value != null || !value.Contains(" ") || !value.Contains("=") || !key.Contains(" ") || !key.Contains("="))
            {
                configList.Add(key, value);
                return true;
            }

            else return false;
        }
    }
}
