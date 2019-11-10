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

            // MMM Comment: use string (keyword) rather than String (Framework name).
            if (String.IsNullOrWhiteSpace(name) || name.Contains("=") || name.Contains(" "))
            {
                return false;
            }

            string[] fileContents = System.IO.File.ReadAllLines(this.ConfigFileName);

            for(int i = 0; i < fileContents.Length; i++)
            {
                if (fileContents[i].Contains(name))
                {
                    // MMM Comment: What happens if there is not '='?
                    value =  fileContents[i].Split("=")[1];
                    return true;
                }
                // MMM Comment: What is the purpose of 'continue' here?  Can't it be deleted?
                continue;
            }

            return false;

        }

        public bool SetConfigValue(string name, string? value)
        {
            if (String.IsNullOrWhiteSpace(name) || name.Contains("=") || name.Contains(" ") || name is null)
            {
                return false;
            }
            else if (String.IsNullOrWhiteSpace(value) || value.Contains("=") || value.Contains(" "))
            {
                return false;
            }

            // MMM Comment: Good use of using statement
            using(StreamWriter configFile = new StreamWriter(path: ConfigFileName, append: true))
            {
                configFile.WriteLine($"{name}={value}");
            }

            return true;
        }
    }
}
