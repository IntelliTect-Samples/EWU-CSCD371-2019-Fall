using System;
using System.Collections.Generic;
using Configuration;

namespace SampleApp
{
    class Program
    {
        public static IConfig? Config { get; set; }
        static void Main()
        {
            if (Config is null)
            {
                Config = new EnvironmentConfig();
                for (int i = 0; i < 5; i++)
                {
                    Config.SetConfigValue($"test{i}", $"value{i}");
                }
            }
            PrintHardCodedSettings();
        }

        public static void PrintHardCodedSettings()
        {
            if (Config is null)
            {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentNullException(nameof(Config), "Config must be set before attempting get or set config operations.");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            List<string> settings = new List<string>() { "test0", "test1", "test2", "test3", "test4" };

            foreach (string setting in settings)
            {
                string? value;
                if (Config.GetConfigValue(setting, out value))
                {
                    Console.WriteLine($"{setting}={value}");
                }
                else
                {
                    Console.WriteLine($"No setting with name {setting}");
                }

            }


        }
    }
}
