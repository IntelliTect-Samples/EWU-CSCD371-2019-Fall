using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Configuration
{
    public class FileConfig
    {
        private string filePath;

        public FileConfig(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Tuple<string, string?>> ReadConfig()
        {
            string[] lines = File.ReadLines(filePath).ToArray();
            List<Tuple<string, string?>> configList = new List<Tuple<string, string?>>();

            foreach (string line in lines)
            {
                string[] lineValues = line.Split('=');
                if (lineValues.Length != 2)
                {
                    throw new ArgumentException("Multiple values on the same file line");
                }
                Tuple<string, string?> configItem = new Tuple<string, string?>(lineValues[0], lineValues[1]);
                configList.Add(configItem);
            }
            return configList;
        }

        public void WriteConfig(string name, string? value)
        {
            if(name is null || value is null)
            {
                throw new ArgumentNullException("Arguments cannot be null");
            }

            using(StreamWriter sw = new StreamWriter(filePath, true))
            {
                if(ValidateNameAndValue(name, value))
                {
                    sw.WriteLine($"{name}={value}");
                }
            }
        }

        public bool ValidateNameAndValue(string name, string? value)
        {
            if (name is null || value is null)
            {
                return false;
            }
            else if (name.Contains(' ') || name.Contains('='))
            {
                return false;
            }
            else if(value.Contains(' ') || value.Contains('='))
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
