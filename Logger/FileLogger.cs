using System;
using System.IO;

namespace Logger
{
    class FileLogger : BaseLogger
    {
        private string path;

        public FileLogger(string filePath)
        {
            path = filePath;

            if (!File.Exists(path))
            {
                File.CreateText(path);
            }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine($"{DateTime.Now} {className} {logLevel} {message}");
            }
        }
    }
}