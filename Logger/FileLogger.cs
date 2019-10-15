using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string FilePath { get; }

        public FileLogger(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public override void Log(LogLevel logLevel, string message)
        {
            string logMessage = $"{DateTime.Now:f} - {ClassName} - {logLevel}: {message}\n";
            File.AppendAllText(FilePath, logMessage);
        }
    }
}
