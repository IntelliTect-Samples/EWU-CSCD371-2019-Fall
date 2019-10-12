using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    class FileLogger : BaseLogger
    {
        private string filepath;
        public FileLogger(string filepath) 
        {
            this.filepath = filepath;
            if (!File.Exists(filepath))
                File.Create(filepath);
        }

        public override void Log(LogLevel logLevel, string message)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                sw.WriteLine($"{DateTime.Now.ToString()} {Name} {logLevel.ToString() + ": "} {message}");
            }
        }
    }
}
