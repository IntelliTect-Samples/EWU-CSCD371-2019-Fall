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

            if (File.Exists(filePath))
            {
                string[] settings = File.ReadAllLines(filePath);
                foreach (string setting in settings)
                {
                    string nameValue = setting.Split("=")[0];
                    string settingValue = setting.Split("=")[1];
                    if (name == nameValue)
                    {
                        value = settingValue;
                        return true;
                    }
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value) || name.Contains(" ") || value.Contains(" ")
                || name.Contains("=") || value.Contains("="))
            {
                return false;
            }
            else
            {
                string filePath = Path.GetFullPath("config.settings");
                File.AppendAllText(filePath, $"{name}={value}");
                return true;
            }
        }
    }
}