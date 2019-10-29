using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Configuration
{
    public class FileConfig
    {
        private string path;

        public FileConfig(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }
            this.path = path;
        }

        public string GetPath()
        {
            return this.path;
        }

        public void WriteConfig(string name, string? value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            } else if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            } else if (!CheckValidArguments(name, value))
            {
                throw new ArgumentException("Value invalid", nameof(value));
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{name}={value}");
            }
        }

        public List<Tuple<string, string?>> ReadConfig()
        {
            string[] file = File.ReadLines(path).ToArray();
            List<Tuple<string, string?>> tuples = new List<Tuple<string, string?>>();
            foreach(string line in file)
            {
                string[] values = line.Split('=');
                tuples.Add(new Tuple<string, string?>(values[0], values[1]));
            }

            return tuples;
        }

        private static bool CheckValidArguments(string name, string value)
        {
            if (!name.Contains('=') && !name.Contains(' ') && !value.Contains('=') && !value.Contains(' ') && name.Length != 0 && value.Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
