using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Configuration
{

    public class FileConfig : IConfig
    {

        public string FilePath { get; }

        public FileConfig(string? path)
        {
            FilePath = Path.GetFullPath($"{path ?? "config.settings"}");
        }

        public FileConfig() : this(null)
        {
        }

        public bool GetConfigValue(string name, out string? value)
        {
            if (!File.Exists(FilePath))
            {
                value = null;
                return false;
            }

            foreach (var line in File.ReadAllLines(FilePath))
            {
                string[] split = line.Split("=");
                if (split.Length == 2 && split[0] == name)
                {
                    value = split[1];
                    return true;
                }
            }

            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (name is null || name.Length == 0 || new Regex("[\\s=]").IsMatch(name))
            {
                throw new ArgumentException("Invalid Key Name", nameof(name));
            }

            if (value is null
             || value.Length == 0
             || !new Regex("(\"([^\"]|\"\")*\")|(\'([^\']|\'\')*\')").IsMatch(value) && value.Contains(" ")
             || value.Contains("="))
            {
                throw new ArgumentException("Invalid Value", nameof(value));
            }

            File.AppendAllText(FilePath, $"{name}={value}");
            return true;
        }

        public void Delete()
        {
            File.Delete(FilePath);
        }

    }

}
