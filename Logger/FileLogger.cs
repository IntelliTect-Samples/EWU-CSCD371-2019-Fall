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
            string loggingLevel;

            switch (logLevel)
            {
                case LogLevel.Information:
                    loggingLevel = "Information";
                    break;
                case LogLevel.Error:
                    loggingLevel = "Error";
                    break;
                case LogLevel.Warning:
                    loggingLevel = "Warning";
                    break;
                default:
                    loggingLevel = "Debug";
                    break;
            }

            string finalMessage = $"{DateTime.Now} {ClassName} {loggingLevel} {message} {Environment.NewLine}";
            File.AppendAllText(FilePath, finalMessage);

        }
    }
}
