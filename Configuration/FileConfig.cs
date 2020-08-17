using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Configuration
{
    public class FileConfig : BaseConfig
    {

        protected const string ConfigFile = "config.settings";

        public override bool GetConfigValue(string name, out string? value)
        {
            if (!CheckValidConfigName(name))
            {
                throw new ArgumentException("Parameter name cannot contain ' ', '=', or be null or empty", nameof(name));
            }
            string filePath = Path.GetFullPath(ConfigFile);
            Console.WriteLine(filePath);


            //check file exists if so search for var.
            if (File.Exists(filePath))
            {
                //if name not in file, return false
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string variableName = "";
                    string[] split = line.Split('=');
                    if (split.Length == 2)
                    {
                        variableName = split[0];
                    }
                    else
                    {
                        continue;
                    }
                    if (variableName.Equals(name))
                    {
                        value = line.Split('=')[1];
                        return true;
                    }
                }
                value = "";
                return false;
            }
            value = "";
            return false;

        }

        public override bool SetConfigValue(string name, string? value)
        {
            if (!CheckValidConfigName(name))
            {
                throw new ArgumentException("Parameter name cannot contain ' ', '=', or be null or empty", nameof(name));
            }

            string filePath = Path.GetFullPath(ConfigFile);

            if (!File.Exists(filePath))
            {
                if (string.IsNullOrEmpty(value))
                {
                    //trying to unset a value that doesn't exist because the file doesn't exist.
                    return false;
                }
                else
                {
                    File.WriteAllText(ConfigFile, $"{name}={value}{Environment.NewLine}");
                    return true;
                }
            }

            //Check for value inside the file.
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] splitLine = lines[i].Split('=');
                if (splitLine.Length != 2)
                {
                    continue;
                }

                //if you find it in the file
                if (splitLine[0].Equals(name))
                {
                    //if we are unsetting then
                    if (string.IsNullOrEmpty(value))
                    {
                        lines[i] = "";
                    }
                    else
                    {
                        lines[i] = $"{name}={value}";
                    }
                    File.WriteAllLines(ConfigFile, lines);
                    return true;
                }

            }
            File.AppendAllText(ConfigFile, $"{name}={value}{Environment.NewLine}");
            return true;

        }
    }
}
