using System;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private readonly string filePath;
        public FileLogger(string filePath) => this.filePath = filePath;
        public override void Log(LogLevel logLevel, string message)
        {
            string logMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}{Environment.NewLine}";

            System.IO.File.AppendAllText(filePath, logMessage);
        }
    }
}
