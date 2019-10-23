using System;
using System.IO;

namespace Configuration
{
    public class FileConfig : Config
    {
        public string FileName { get; set; }

        private string FormatConfig(string name, string value) =>
            $"{name}={value}";

        public override bool GetConfigValue(string name, out string? value)
        {
            using (var sr = new StreamReader(Environment.CurrentDirectory + FileName))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split('=');
                    if (values[0] == name)
                    {
                        value = values[1];
                        return true;
                    }
                }
                value = null;
                return false;
            }
        }

        public override bool SetConfigValue(string name, string? value)
        {
            using (var sw = new StreamWriter(Environment.CurrentDirectory + FileName, append: true))
            {
                sw.WriteLine(FormatConfig(name, value)); 
            }
            return true;
        }
    }
}
            
