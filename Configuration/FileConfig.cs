using System;
using System.Collections.Generic;
using System.IO;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        static readonly string filePath = Environment.CurrentDirectory + "//config.settings";

        private const string EQUALS = "=";
        private const string SPACE = " ";

        public bool GetConfigValue(string name, out string? value)
        {
            value = "";
            if (!nameCheck(name))
                return false;

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
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

            if (!File.Exists(filePath))
                File.AppendAllText(filePath, "");

            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            for (int walker = 0; walker < lines.Count; walker++)
            {
#pragma warning disable CA1307 // Specify StringComparison. No Globalizaton Required
                if (lines[walker].StartsWith(name + EQUALS))
#pragma warning restore CA1307 // Specify StringComparison. No Globalizaton Required
                {
                    string[] currentLine = lines[walker].Split(EQUALS);
#pragma warning disable CS8601 // null reference
                    currentLine[1] = value;
#pragma warning restore CS8601 // null reference

                    lines[walker] = $"{currentLine[0]}={currentLine[1]}{Environment.NewLine}";
                    File.WriteAllLines(filePath, lines);
                    return true;
                }
            }

            File.AppendAllText(filePath, $"{name}={value}{Environment.NewLine}");
            return true;
        }

        public static void DeleteFile()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        // MMM Comment: Why not refactor EnvironmentConfig for this logic?
        private static bool nameCheck(string? name)
        {
            if (name is null)
                throw new ArgumentException($"The name: {name} is null!");

            else if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"The name: {name} is empty and therefore invalid.");

            else if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"The name: {name} is just whitespace and therefore invalid.");

#pragma warning disable CA1307 // StringComparison
            else if (name.Contains(SPACE))
#pragma warning restore CA1307 // StringComparison
                throw new ArgumentException($"The name: {name} contains spaces and this is not allowed.");

#pragma warning disable CA1307
            else if (name.Contains(EQUALS))
#pragma warning restore CA1307
                throw new ArgumentException($"The name: {name} cannot contain \'=\'.");

            return true;
        }

        private static bool valueCheck(string? value)
        {
            if (value is null)
                throw new ArgumentException($"The value: {value} is null!");

            else if (string.IsNullOrEmpty(value))
                throw new ArgumentException($"The value: {value} is empty and therefore invalid.");

            return true;
        }
    }
}