using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Configuration
{
    public class FileConfig
    {
        private string FilePath;

        public FileConfig(string newPath)
        {
            FilePath = newPath;
        }

        public List<Tuple<string, string?>> Read()
        {
            string[] configLines = File.ReadLines(FilePath).ToArray();
            List<Tuple<string, string?>> configList = new List<Tuple<string, string?>>();

            foreach(string line in configLines)
            {
                string name = line.Split("=")[0];
                string value = line.Split("=")[1];
                Tuple<string, string?> newConfig = new Tuple<string, string?>(name, value);
                configList.Add(newConfig);
            }
            return configList;

        }

        public bool Write(string name, string? value)
        {
            if (name is null || name is "" || name.Contains("=", 0) || name.Contains(" ", 0))
            {
                return false;
            }

            if (value is null || value is "" || value.Contains("=", 0) || value.Contains(" ", 0))
            {
                return false;
            }

            using (StreamWriter writer = new StreamWriter(Path.GetFullPath(FilePath)))
            {
                writer.WriteLine($"{name}={value}");
            }
            return true;
        }
    }
}
