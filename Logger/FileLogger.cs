using System;
using System.Text;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string FilePath { get; private set; }

        private static string GetDefaultPath() => Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt");

        public FileLogger() => FilePath = GetDefaultPath();

        public FileLogger(string logFilePath) => FilePath = string.IsNullOrEmpty(logFilePath) ? GetDefaultPath() : logFilePath;

        public override void Log(LogLevel logLevel, string message)
        {
            StringBuilder entry = new StringBuilder();
            entry.AppendLine(DateTime.Now.ToString("g")).Append(" ").Append(ClassName ?? "Unknown Class").Append(" ")
                 .Append(logLevel.ToString()).Append(": ").Append(message);

            StreamWriter logFile = File.AppendText(FilePath);
            try
            {
                logFile.WriteLine(entry.ToString());
                logFile.Flush();
            }
            finally
            {
                logFile.Close();
            }
        }
    }
}
