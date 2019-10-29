using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    public class Program
    {
        static void Main()
        {
            List<string> hardcodedNames = new List<string> { "Test1", "Test2", "Test3" };

            IConfig fileConfig = new FileConfig();

            for (int i = 0; i < hardcodedNames.Count; i++)
                fileConfig.SetConfigValue(hardcodedNames[i], i.ToString());

            PrintConfigSettings(fileConfig, hardcodedNames);
        }

        public static string FindSetting(IConfig config, string name)
        {
            if (config is null)
                throw new ArgumentNullException("Config cannont be null");

            else if (name is null)
                throw new ArgumentException("The Name cannont be null");

            string? value = "";
            config.GetConfigValue(name, out value);

            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid Setting's Name");

            return $"{name}={value}";
        }

        public static void PrintConfigSettings(IConfig config, List<string> names)
        {
            if (config is null)
                throw new ArgumentNullException($"The {nameof(config)} cannont be null");

            else if (names is null)
                throw new ArgumentNullException($"The {nameof(names)} variable is null");

            foreach (string name in names)
                Console.WriteLine(FindSetting(config, name));
        }
    }
}
