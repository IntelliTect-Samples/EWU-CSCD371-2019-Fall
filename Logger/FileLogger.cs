using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        StreamWriter sw;

        public FileLogger(string filePath) 
        {
            if(!File.Exists(filePath))
            {
                sw = File.CreateText(filePath);
            }   
        }

        public override void Log(LogLevel logLevel, string message)
        {
            DateTime now = DateTime.Now;
            sw.WriteLine(now);
            sw.WriteLine(className);
            sw.WriteLine(logLevel.ToString() + ":");
            sw.WriteLine(message);
        }
    }
}
