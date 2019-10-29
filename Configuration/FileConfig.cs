using System;
using System.Collections.Generic;
using System.IO;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        static readonly string path = Environment.CurrentDirectory + "//config.settings";

        public bool GetConfigValue(string name, out string? value)
        {
            value = "";
            if (!nameCheck(name))
                return false;

            string[] lines = File.ReadAllLines(path);

            for(int i = 0; i < lines.Length; i++)
            {
                string[] currentLine = lines[i].Split("=");

#pragma warning disable CA1307 // Specify StringComparison. No Globalizaton Required
                if (currentLine[0].Equals(name) && !string.IsNullOrEmpty(currentLine[1]))
#pragma warning restore CA1307 // Specify StringComparison. No Globalizaton Required
                {
                    value = currentLine[1];
                    break;
                }
            }

            return !string.IsNullOrEmpty(value);
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (!nameCheck(name) || !valueCheck(value))
                return false;

            if (!File.Exists(path))
                File.AppendAllText(path, "");

            List<string> lines = new List<string>(File.ReadAllLines(path));

            for(int i = 0; i < lines.Count; i++)
            {
#pragma warning disable CA1307 // Specify StringComparison. No Globalizaton Required
                if (lines[i].StartsWith(name + "="))
#pragma warning restore CA1307 // Specify StringComparison. No Globalizaton Required
                {
                    string[] currentLine = lines[i].Split("=");
#pragma warning disable CS8601 // Possible null reference assignment. Confirmed not null by strCheck
                    currentLine[1] = value;
#pragma warning restore CS8601 // Possible null reference assignment. Confirmed not null by strCheck

                    lines[i] = $"{currentLine[0]}={currentLine[1]}{Environment.NewLine}";
                    File.WriteAllLines(path, lines);
                    return true;
                }
            }

            File.AppendAllText(path, $"{name}={value}{Environment.NewLine}");
            return true;
        }

        public static void DeleteFile()
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        private static bool nameCheck(string? name)
        {
            if (name is null)
                throw new ArgumentException($"The name: {name} is null and not allowed.");

            else if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"The name: {name} is empty and not allowed.");

            else if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"The name: {name} is just whitespace and not allowed.");

#pragma warning disable CA1307 // Specify StringComparison
            else if (name.Contains(" "))
#pragma warning restore CA1307 // Specify StringComparison
                throw new ArgumentException($"The name: {name} contains spaces and is not allowed.");

#pragma warning disable CA1307 // Specify StringComparison
            else if (name.Contains("="))
#pragma warning restore CA1307 // Specify StringComparison
                throw new ArgumentException($"The name: {name} contains \'=\' and is not allowed.");

            return true;
        }

        private static bool valueCheck(string? value)
        {
            if (value is null)
                throw new ArgumentException($"The value: {value} is null and not allowed.");

            else if (string.IsNullOrEmpty(value))
                throw new ArgumentException($"The value: {value} is empty and not allowed.");

            return true;
        }
    }
}
