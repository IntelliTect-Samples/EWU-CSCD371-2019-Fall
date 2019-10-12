using System;
using System.Text;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private static string FilePath { get; set; }

        public FileLogger() => FilePath = DateTime.Now.ToString("s") + ".txt";

        public FileLogger(string logFilePath) => FilePath = logFilePath;

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
