using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Configuration
{
    class FileConfig : IConfig
    {
        private string FileName;

        public FileConfig(string fileName) 
        {
            FileName = fileName;
        }

        public bool GetConfigValue(string name, out string? value)
        {
            using (var sr = new StreamReader(Environment.CurrentDirectory + FileName)) 
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
            ValidateInput(name, value);
            using (var sr = new StreamWriter(Environment.CurrentDirectory + FileName)) 
            {
                sr.WriteLine($"{name}={value}");
            }
            return true;
        }

        private (string, string?) RetrieveValues(string input) 
        {
            var data = input.Split("=");

            ValidateInput(data[0], data[1]);

            return (data[0], data[1]);
        }

        private void ValidateInput(string name, string? value) 
        {
            if (string.IsNullOrEmpty(name) 
                || name.Contains(" ") 
                || name.Count(c => c == '=') > 1)
                throw new ArgumentException("Name contains invalid character or is empty");

            if (string.IsNullOrEmpty(value)
                || value.Contains(" ")
                || value.Count(c=>c == '=') > 1)
                throw new ArgumentException("Value contains invalid character or is empty");
        }
    }
}
