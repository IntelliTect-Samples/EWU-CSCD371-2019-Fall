using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        private string FileName;

        public FileConfig(string fileName) 
        {
            FileName = fileName;
        }

        public bool GetConfigValue(string name, out string? value)
        {
            using (var sr = new StreamReader(FileName)) 
            {
                while (!sr.EndOfStream) 
                {
                    string currentLine = sr.ReadLine();

                    (string, string?) data = RetrieveValues(currentLine);

                    if (data.Item1 == name) 
                    {
                        value = data.Item2;
                        return true;
                    }

                }
                value = null;
                return false;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            this.ValidateInput(name, value);
            using (var sr = new StreamWriter(FileName)) 
            {
                sr.WriteLine($"{name}={value}");
            }
            return GetConfigValue(name, out value);
        }

        private (string, string?) RetrieveValues(string input) 
        {
            var data = input.Split("=");

            this.ValidateInput(data[0], data[1]);

            return (data[0], data[1]);
        }


    }
}
