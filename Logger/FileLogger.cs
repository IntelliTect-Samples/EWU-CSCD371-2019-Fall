using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string FilePath { get; }

        public FileLogger(string filePath)
        {
            FilePath = filePath;

            if (!File.Exists(FilePath))
            {
                var file = File.Create(filePath);
                file.Close();
            }
        }
        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter streamWriter = File.AppendText(this.FilePath);

            streamWriter.Write($"{DateTime.Now} FileLoggerTests {LogLevel.Error}: {message}");

            streamWriter.Close();
        }
    }
}
