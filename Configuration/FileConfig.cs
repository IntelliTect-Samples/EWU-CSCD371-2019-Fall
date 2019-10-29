using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    public class FileConfig
    {

        private string _FilePath = Environment.CurrentDirectory+Path.DirectorySeparatorChar+"config.settings";

        public FileConfig()
        {

        }

        public Dictionary<string,string> FileRead()
        {
            StreamReader reader = new StreamReader(_FilePath);
            Dictionary<string,string> map = new Dictionary<string, string>();
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                string[] br = line.Split("=");

                map.Add(br[0], br[1]);
            }
            reader.Close();
            return map;
        }

        public bool FileWrite(string type,string value)
        {
            StreamWriter writer = new StreamWriter(_FilePath);

            if (type == null || type == "" || type.Contains("=") || type.Contains(" "))
            {
                writer.Close();
                return false;
            }

            if (value == null || value == "" || value.Contains("=") || value.Contains(" "))
            {
                writer.Close();
                return false;
            }

            writer.WriteLine($"{type}={value}");

            writer.Close();
            return true;
        }
    }
}
