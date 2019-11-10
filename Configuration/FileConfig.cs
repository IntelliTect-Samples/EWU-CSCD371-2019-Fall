using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    // MMM Comment: Why are you not implmenting IConfig here?
    public class FileConfig
    {
        private string fileConfigPath;
        public FileConfig()
        {
            this.fileConfigPath = Path.GetFullPath("config.settings");
        }

        public FileConfig(string filePath)
        {
            this.fileConfigPath = filePath;
        }
        public List<String> ReadConfig()
        {
            string[] lines = File.ReadAllLines(this.fileConfigPath);
            List<String> configLines = new List<String>();

            foreach(string line in lines)
            {
                if(line.Split("=").Length != 2)
                {
                    // MMM Comment: Or too few?
                    throw new ArgumentException("Too many arguments on one line");
                }

                configLines.Add(line);
            }

            return configLines;
        }

        public void WriteConfig(string name, string? value)
        {
            if(IsValidInput(name, value))
            {
                using (StreamWriter sr = new StreamWriter(this.fileConfigPath, true))
                {
                    sr.WriteLine($"{name}={value}");
                }
            }

        }

        // MMM Comment: Storing the return in a variable for a single return would be preferable.
        // MMM Comment: How do you comunicate which argument is invalid?
        public static bool IsValidInput(string name, string? value)
        {
            if(string.IsNullOrEmpty(name) || name.Contains(' ') || name.Contains('='))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(value) || value.Contains(' ') || value.Contains('='))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
