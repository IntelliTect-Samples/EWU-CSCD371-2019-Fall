using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string FilePath { get; }

        public FileLogger(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public override void Log(LogLevel logLevel, string message)
        {
            File.AppendAllText(FilePath, $"{DateTime.Now:G} {ClassName} {logLevel}: {message}{Environment.NewLine}");
        }
    }
}
