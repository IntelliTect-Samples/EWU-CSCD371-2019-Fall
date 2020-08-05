using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string FilePath { get; }

        public FileLogger(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("message", nameof(path));
            }

            FilePath = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            string finalMessage = $"{DateTime.Now} {ClassName} {logLevel} {message} {Environment.NewLine}";
            File.AppendAllText(FilePath, finalMessage);
        }
    }
}
