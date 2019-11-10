using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        public string FilePath { get; }

        public FileConfig(string? filePath)
        {
            // MMM Comment: Yes... I like it.
            FilePath = filePath ?? Path.GetFullPath("config.settings");
        }

        public bool GetConfigValue(string name, out string? value)
        {
            if (!File.Exists(FilePath))
            {
                // MMM Comment: Yes, an exception is correct here.
                throw new FileNotFoundException();
            }

            CheckValidText(name);
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                string[] nameAndValue = line.Split('=');
                if (nameAndValue[0] == name)
                {
                    value = nameAndValue[1];
                    return !(value is null);
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            CheckValidText(name);
            CheckValidText(value);

            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    string[] nameAndValue = line.Split('=');
                    if (nameAndValue[0].Equals(name))
                    {
                        string fileText = File.ReadAllText(FilePath);
                        fileText = fileText.Replace($"{name}={nameAndValue[1]}", $"{name}={value}");
                        File.WriteAllText(FilePath, fileText);
                        return true;
                    }
                }
            }
            //Reaches here if file does not exist or if name not found in settings
            File.AppendAllText(FilePath, $"{name}={value}{Environment.NewLine}");
            return true;
        }

        public List<string> GetAllConfigValues()
        {
            // You should provide a justification when disabling warnings.
#pragma warning disable CA1303
            // The message should be clearere here.  Also (not sure you intended it), but
            // parameter name is the second parameter on the exception constructor.
            if (!File.Exists(FilePath)) throw new FileNotFoundException(nameof(FilePath));
#pragma warning restore CA1303
            return File.ReadAllLines(FilePath).ToList();
        }

        // MMM Comment: Great refactoring here.
        private void CheckValidText(string? text)
        {
            if(string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));
            if (text.Contains(' ') || text.Contains('='))
            {
                string message = $"{nameof(text)} cannot contain white space or '='";
#pragma warning disable CA1303
                // You should povide the second parameter name argument here.
                throw new ArgumentException(message);
#pragma warning restore CA1303
            }
        }
    }
}
