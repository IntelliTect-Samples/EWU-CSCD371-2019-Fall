using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string path;
        public FileLogger(string filePath) 
        {
            this.path = filePath;
            if (!File.Exists(filePath))
            {
                File.CreateText(filePath);
            }
            
        }

        public override void Log(LogLevel logLevel, string message)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine($"{DateTime.Now} {className} {logLevel.ToString() + ": "} {message}");
            }           
        }
    }
}
