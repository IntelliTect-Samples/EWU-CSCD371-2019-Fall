using System;
using System.Collections.Generic;
using Configuration;

namespace SampleApp
{

    internal static class Program
    {

        static void Main()
        {
            var environmentConfig = new EnvironmentConfig();
            var variables = new List<string>
            {
                "OS",
                "NUMBER_OF_PROCESSORS",
                "JRE_HOME",
                "JAVA_HOME",
                "TEMP"
            };

            Console.WriteLine("Environment Variables:");
            foreach (var variable in variables)
            {
                environmentConfig.GetConfigValue(variable, out string? value);
                Console.WriteLine($"{variable}={value}");
            }

            Console.WriteLine();

            var fileConfig = new FileConfig();
            var kvps = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("entity-id", "3141"),
                new KeyValuePair<string, string>("mesh-name", "\"entity-mesh-digital-caller-main\""),
                new KeyValuePair<string, string>("mesh-compound", "\'variable-sync callback-enabled\'"),
                new KeyValuePair<string, string>("data-retrieval-method", "lazy"),
                new KeyValuePair<string, string>("signed", "true"),
                new KeyValuePair<string, string>("entity-stream", "disabled")
            };

            foreach (var (key, value) in kvps)
            {
                fileConfig.SetConfigValue(key, value);
            }

            Console.WriteLine("FileConfig Variables:");
            foreach (var (key, _) in kvps)
            {
                fileConfig.GetConfigValue(key, out string? value);
                Console.WriteLine($"{key}={value}");
            }

            fileConfig.Delete();
        }

    }

}
