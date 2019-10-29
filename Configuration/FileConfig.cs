using System;
using System.IO;
using System.Linq;

namespace Configuration
{
    public class FileConfig : Config
    {
        public string? FileName { get; set; }
        private static string DefaultFileName = "DefaultFileName.ini";

        // ~FileConfig() => FileCleanup();

        public void FileCleanup() =>
            File.Delete(Environment.CurrentDirectory + FileName);

        public override bool GetConfigValue(string name, out string? value)
        {
            if (FileName is null) FileName = DefaultFileName;
            using (var sr = new StreamReader(Environment.CurrentDirectory + FileName))
            {
                string? line = "";
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

        #pragma warning disable CA1303
        public override bool SetConfigValue(string name, string? value)
        {
            SanitizeValue(name);
            SanitizeValue(value);
            if (FileName is null) FileName = DefaultFileName;
            using (var sw = new StreamWriter(Environment.CurrentDirectory + FileName, append: true))
            {
                #nullable disable
                sw.WriteLine(FormatConfig(name, value)); 
                #nullable enable
            }
            return true;
        }

        private static string FormatConfig(string name, string value) =>
            $"{name}={value}";

        public static (string, string?) ParseConfigString(string input)
        {
            if (input is null)
                throw new ArgumentNullException($"{nameof(input)} parameter cannot be null.");
            string[] values = input.Split('=');
            if (values.Length != 2) 
                throw new ArgumentException($"Got multiple '=' characters for {nameof(input)}.");

            string name = values[0], value = values[1];

            SanitizeInput(name, value);
            
            return (name, value);
        }

        private static void SanitizeInput(string name, string? value)
        {
            if ((name.Any(c => c == ' ')) || (value.Any(c => c == ' ')))
                throw new ArgumentException($"{nameof(value)} contains internal whitespace.");
            else if ((name.Any(c => c == '=')) || (value.Any(c => c == '=')))
                throw new ArgumentException($"{nameof(value)} does not contain exactly one '=' char.");
            else if (String.IsNullOrEmpty(value))
                throw new ArgumentException($"Cannot take null or empty values for {nameof(value)}.");
            else if (String.IsNullOrEmpty(name))
                throw new ArgumentException($"Cannot take null or empty values for {nameof(name)}.");
        }
        #pragma warning restore
    }
}
            
