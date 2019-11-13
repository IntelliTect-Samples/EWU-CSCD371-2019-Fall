using System;
using System.Collections.Generic;
using Configuration;

namespace SampleApp
{
    public static class Program
    {
        public static void Main()
        {
            // MMM Comment: IConfig would have been preferable.
            BaseConfig config = new FileConfig();

            // MMM Comment: This too would have been a great place to use Tuples.
            string[] keys = new string[] { "K1", "K2", "K3" };
            string[] values = new string[] { "V1", "V2", "V3" };

            for (int i = 0; i < keys.Length; i++) config.SetConfigValue(keys[i], values[i]);

            PrintAllKVPairs(config, keys);

            config.DeleteAllConfigs();
        }

        public static void PrintAllKVPairs(IConfig config, string[] keys)
        {
            foreach(KeyValuePair<string, string> kvPair in IterateKVPairs(config, keys))
            {
                Console.WriteLine($"Key: {kvPair.Key}, Value: {kvPair.Value}");
            }
        }
        
        // MMM Comment: IMO, it think it would be a lot eaiser to work with tuples here.
        public static List<KeyValuePair<string,string>> IterateKVPairs(IConfig config, string[] keys)
        {
            List<KeyValuePair<string, string>> kvPairs = new List<KeyValuePair<string, string>>();

            if (config is null) throw new ArgumentNullException(nameof(config));
            if (keys is null) throw new ArgumentNullException(nameof(keys));

            foreach (string key in keys)
            {
                config.GetConfigValue(key, out string? value);
                kvPairs.Add(new KeyValuePair<string, string>(key, value ?? ""));
            }

            return kvPairs;
        }
    }
}
