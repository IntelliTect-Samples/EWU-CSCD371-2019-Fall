using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Configuration
{
    public class FileConfig : BaseConfig
    {

        private static string ConfigFile = "config.settings";

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
                    string variableName = line.Split('=')[0];
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
            //write file
            return true;//CHANGE
        }
    }
}
