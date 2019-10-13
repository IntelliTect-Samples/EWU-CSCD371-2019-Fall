using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string outPath;

        public FileLogger(string outPath)
        {
            this.outPath = outPath;
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }
    }

    public override void Log(LogLevel logLevel, string s)
    {
        using (StreamWriter sw = new StreamWriter(outPath, true))
        {
            sw.WriteLine($"{DateTime.Now.ToString()}{ClassName}{logLevel}{s}");
        }
    }
}