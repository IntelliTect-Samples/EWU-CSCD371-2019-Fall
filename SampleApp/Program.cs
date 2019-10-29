using System;
using System.Collections.Generic;
using System.IO;
using Configuration;

namespace SampleApp
{
    public static class Program
    {
        public static IConfig? Config { get; set; }
        public static List<string>? SettingList { get; private set; }

        public static void Main()
        {
            PrintAllSettings();
        }

        private static void PrintAllSettings()
        {
            SettingList = Config?.GetAllConfigValues() ?? new List<string> { "Config not initialized!" };
            if (SettingList.Count == 0)
            {
                SettingList.Add("No settings to display.");
            }
            foreach (string str in SettingList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
