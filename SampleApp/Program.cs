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
                Config.SetConfigValue(name, value);
            }
        }

        public void GetValues()
        {
            foreach (var (name, value) in SettingValues)
            {
                string? outValue;
                Console.WriteLine(
                    $"Getting value of {name} in {nameof(Config)} config.");
                Config.GetConfigValue(name, out outValue);
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
