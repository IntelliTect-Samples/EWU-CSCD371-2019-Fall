using Configuration;
using System;

namespace SampleApp
{
    public static class Program
    {
        public static void Main()
        {
            IConfig environmentConfig = new EnvironmentConfig();

            string[] names = { "mkdir", "ls", "SystemRoot" };
            
            for(int i = 0; i < names.Length; i++)
            {
                environmentConfig.GetConfigValue(names[i], out string? value);
                Console.WriteLine($"{names[i]}={value}");
            }
        }
    }
}
