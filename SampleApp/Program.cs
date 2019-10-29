using System;
using System.Collections.Generic;
using Configuration.Tests;

namespace SampleApp
{
    class SampleApp
    {
        static void Main()
        {
            MockConfig config = new MockConfig();

            foreach (var name in config.Settings)
            {
                config.ReadConfigValue(name, out string? outVal);
                Console.WriteLine($"{name}={outVal}");
            }
        }
    }
}
