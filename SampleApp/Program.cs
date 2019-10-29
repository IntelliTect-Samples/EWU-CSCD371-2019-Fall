using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    public class Program
    {
        static void Main()
        {
            List<string> testNames = new List<string> {"TestingOne","testingTwo","testingthree" };

            IConfig fileConfig = new FileConfig();

            for (int walker = 0; walker < testNames.Count; walker++)           
                fileConfig.SetConfigValue(testNames[walker], walker.ToString());

            PrintConfigSettings(fileConfig, testNames);
            
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
                throw new ArgumentNullException($"The {nameof(config)} cannot be null");

            else if (names is null)
                throw new ArgumentNullException();

            foreach (string name in names)
                Console.WriteLine(FindSetting(config, name));
        }
    }
}
