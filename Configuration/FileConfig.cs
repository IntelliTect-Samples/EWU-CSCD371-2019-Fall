using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Configuration
{
    // MMM Comment: IConfig was not implemented?
    public class FileConfig
    {
        // MMM Comment: What if file does not exist?
        // MMM Comment: System.IO.Path.Combine() preferable.
        private string _FilePath = Environment.CurrentDirectory+Path.DirectorySeparatorChar+"config.settings";

        // MMM Comment: An empty public default constructor is unnecessary as the compiler generates this.
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
                // MMM Comment: What if line is blank?
                string[] br = line.Split("=");

                map.Add(br[0], br[1]);
            }
            reader.Close();
            return map;
        }

        public bool FileWrite(string type,string value)
        {
            // MMM Comment:  Levearge using statement
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
