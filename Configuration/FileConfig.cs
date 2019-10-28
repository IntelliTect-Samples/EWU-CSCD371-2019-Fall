using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Configuration
{
    public class FileConfig
    {
        private string path;

        public FileConfig(string newPath)
        {
            this.path = newPath;
        }

        public List<string> ReadConfig()
        {
            string[] readLine = File.ReadAllLines(path);

            List<string> res = new List<string>();

            foreach(string s in readLine)
            {
                if(s.Split("=").Length != 2)
                    throw new ArgumentException("must have two args");

                res.Add(s);
            }

            return res;
        }

#pragma warning disable CA1822 // Mark members as static
        public void WriteConfig(string name, string? value)
#pragma warning restore CA1822 // Mark members as static
        {
            if (name != null || value != null || !value.Contains(" ") || !value.Contains("=") || !name.Contains(" ") || !name.Contains("="))
            {
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    streamWriter.WriteLine($"{name}={value}");
                }
            }

            else Console.WriteLine("error to write the content");
        }


    }
}
