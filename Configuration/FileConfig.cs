using System;
using System.IO;

namespace Configuration
{
    public class FileConfig : Config
    {
        public string FileName { get; set; }

        public override bool GetConfigValue(string name, out string? value)
        {
            using (var sr = new StreamReader(Environment.CurrentDirectory + FileName))
            {
            }
            value = null;
            return true;
        }

        public override bool SetConfigValue(string name, string? value)
        {
            using (var sw = new StreamWriter(Environment.CurrentDirectory + FileName))
            {
            }
            return true;
        }
    }
}
            
