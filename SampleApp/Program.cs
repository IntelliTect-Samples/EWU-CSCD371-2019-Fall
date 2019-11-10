using System;
using System.Collections.Generic;
using Configuration;

namespace SampleApp
{
    public static class Program
    {
        // MMM Comment... Yay... Finally, someone has the right implementation at last!!! :)
        public static IConfig? Config { get; set; }

        // This is a clever way to enable mostly testing console output.
        public static List<string>? SettingList { get; private set; }

        public static void Main()
        {
            PrintAllSettings();
        }

        public static void PrintAllSettings()
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
