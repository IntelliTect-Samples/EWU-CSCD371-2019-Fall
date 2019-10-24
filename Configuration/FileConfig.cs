using System;
using System.IO;
using System.Linq;

namespace Configuration
{
    public class FileConfig : Config
    {
        public string FileName { get; set; }

        public override bool GetConfigValue(string name, out string? value)
        {
            using (var sr = new StreamReader(Environment.CurrentDirectory + FileName))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    var (_name, _value) = ParseConfigString(line);
                    if (name == _name)
                    {
                        value = _value;
                        return true;
                    }
                }
                value = null;
                return false;
            }
        }

        public override bool SetConfigValue(string name, string? value)
        {
            if (value is null) throw new ArgumentException("Setting value cannot be null.");
            SanitizeInput(name, value);
            using (var sw = new StreamWriter(Environment.CurrentDirectory + FileName, append: true))
            {
                sw.WriteLine(FormatConfig(name, value)); 
            }
            return true;
        }

        private static string FormatConfig(string name, string value) =>
            $"{name}={value}";

        public static (string, string?) ParseConfigString(string input)
        {
            string[] values = input.Split('=');
            if (values.Length != 2) throw new ArgumentException("Got multiple '=' characters.");

            string name = values[0], value = values[1];

            SanitizeInput(name, value);
            
            return (name: name, value: value);
        }

        private static void SanitizeInput(string name, string? value)
        {
            if ((name.Any(c => c == ' ')) || (value.Any(c => c == ' ')))
                throw new ArgumentException("Input contains internal whitespace.");
            else if ((name.Any(c => c == '=')) || (value.Any(c => c == '=')))
                throw new ArgumentException("Input does not contain exactly one '=' char.");
            else if (name == "" || value == "")
                throw new ArgumentException("Input does not contain exactly one '=' char.");
            else if (value is null)
                throw new ArgumentException("Cannot take null values.");
        }
    }
}
            
