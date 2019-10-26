using System;
using Configuration;
using System.Collections.Generic;
using Mock;

namespace SampleApp
{
    public class Program
    {
        public IConfig? Config { get; set; }

        public Program()
        {
            if (Config is null) Config = new MockConfig();
        }

        public void SetValues()
        {
            foreach (var (name, value) in SettingValues)
            {
                Console.WriteLine(
                    $"Setting {name} to value {value} in {nameof(Config)} config.");

                /*
                 * Null/empty is checked in the setting function,
                 * so we don't have to check here
                 */
                #pragma warning disable CS8602
                Config.SetConfigValue(name, value);
                #pragma warning restore
            }
        }

        public void GetValues()
        {
            foreach (var (name, value) in SettingValues)
            {
                string? outValue;
                Console.WriteLine(
                    $"Getting value of {name} in {nameof(Config)}.");

                /* 
                 * SanitizeValue will do the null checks for us
                 * here, so we can disable the warning and
                 * restore immediately
                 */
                #pragma warning disable CS8602
                MockConfig.SanitizeValue(name);
                Config.GetConfigValue(name, out outValue);
                #pragma warning restore
                if (outValue is null)
                    throw new NullReferenceException($"Got null value from {nameof(Config)}");
                Console.WriteLine($"Got value of {outValue}.");
            }
        }

        public static List<(string name, string value)> SettingValues =
            new List<(string name, string value)>()
        {
            ("Name"           , "Asher"           ),
            ("Editor"         , "Vim"             ),
            ("OS"             , "OSX"             ),
            ("Github.username", "ashermancinelli" ),
        };

        public static void RunApp(string configType)
        {
            var sampleApp = new Program();

            switch (configType)
            {
                case "mock":
                    sampleApp.Config = new MockConfig();
                    break;
                case "file":
                    sampleApp.Config = new FileConfig();
                    break;
                case "env":
                    sampleApp.Config = new EnvironmentConfig();
                    break;
                default:
                    throw new ArgumentException($"{nameof(configType)} cannot take passed value.");
            }

            sampleApp.SetValues();
            sampleApp.GetValues();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Running with specified config classes.");

            if (args.Length > 2)
            {
                throw new ArgumentException("Usage: SampleApp.exe (mock|file|env).");
            }
            else
            {
                RunApp(args[args.Length-1]);
            }
        } // function Main
    } // class Program
} // namespace SampleApp
