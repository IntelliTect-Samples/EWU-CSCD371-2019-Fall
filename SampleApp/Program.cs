using System;
using System.Collections.Generic;
using Configuration;

namespace SampleApp
{
    class Program
    {
        public static void Main()
        {
            IConfig envConfig = new EnvironmentConfig();

            List<String> configSettings = new List<String>
            {
                "USERPROFILE",
                "PATH",
                "TEMP",
                "HOME"
            };

            foreach(string setting in configSettings)
            {
                envConfig.GetConfigValue(setting, out string? value);
                Console.WriteLine($"{setting}={value}");
            }

        }
    }
}
