using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            string filePath = Path.GetFullPath("config.settings");

            if(!File.Exists(filePath))
            {
                value = null;
                return false;
            }
            else
            {
                string[] configFile = File.ReadAllLines(filePath);

                for(int i = 0; i < configFile.Length; i++)
                {
                    if(name == configFile[i].Split("=")[0])
                    {
                        value = configFile[i].Split("=")[1];
                        return true;
                    }
                }

                value = null;
                return false;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            if(isValidInput(name, value))
            {
                using (StreamWriter sr = new StreamWriter(Path.GetFullPath("config.settings")))
                {
                    sr.WriteLine($"{name}={value}");
                }
                return true;
            }

            return false;
        }

        private bool isValidInput(string name, string? value)
        {
            if(string.IsNullOrEmpty(name) || name.Contains(" ") || name.Contains("="))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(value) || value.Contains(" ") || name.Contains("="))
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
