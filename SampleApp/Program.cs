using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    public static class Program
    {
        public static void Main()
        {
            List<string> valueNames = new List<string>
            {
                "windir",
                "SystemRoot",
                "UserName"
            };

            IConfig config = new EnvironmentConfig();

            foreach (string valueName in valueNames)
            {
                config.GetConfigValue(valueName, out string? value);
                Console.WriteLine($"{valueName}={value}");
            }
        }
    }
}