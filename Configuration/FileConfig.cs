using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        private string ConfigFileName => "config.settings";
        public bool GetConfigValue(string name, out string? value)
        {
            value = null;

            if (String.IsNullOrWhiteSpace(name) || name.Contains("=") || name.Contains(" "))
            {
                return false;
            }

            string[] fileContents = System.IO.File.ReadAllLines(this.ConfigFileName);

            int fileLine = 0;

            for(int i = 0; i < fileContents.Length; i++)
            {
                if (fileContents[i].Contains(name))
                {
                    string[] lineArray = fileContents[i].Split("=");
                    value = lineArray[1];
                    return true;
                }
                continue;
            }

            return false;

        }

        public bool SetConfigValue(string name, string? value)
        {
            if (String.IsNullOrWhiteSpace(name) || name.Contains("=") || name.Contains(" "))
            {
                return false;
            }
            else if (String.IsNullOrWhiteSpace(value) || value.Contains("=") || value.Contains(" "))
            {
                return false;
            }


            using(StreamWriter configFile = new StreamWriter(path: ConfigFileName, append: true))
            {
                configFile.WriteLine($"{name}={value}");
            }

            return true;
        }
    }
}
