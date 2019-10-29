using Configuration;
using Configuration.Tests;
using System;

namespace SampleApp
{
    public class Program
    {
        public static void Main()
        {
            RunApp(new EnvironmentConfig());
        }

        public static bool RunApp(IConfig configToUse) 
        {
            IConfig config = configToUse;
            string[] settings =
            {
                "USERPROFILE",
                "TEMP",
                "OS",
                "windir",
                "DriverData",
                "PATHEXT",
                "NUMBER_OF_PROCESSORS"
            };

            foreach (string s in settings) 
            {
                config.GetConfigValue(s, out string? value);
                Console.WriteLine($"{s}={value}");
            }

            return true;
        }
    }
}
