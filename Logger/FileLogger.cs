using System;
using System.IO;

namespace Logger
{
    public class FileLogger: BaseLogger
    {
        private string _LoggerName; // Is this the correct naming convention?
        private string fileName;
        private StreamWriter writer;

        public string LoggerName { get; set; }

        public FileLogger(string fileName)
        {
            this.fileName = fileName + ".log";
            this.writer = new StreamWriter(this.fileName);
        }

        ~FileLogger()
        {
            writer.Flush();
            writer.Close();
        }

        override public void Log(LogLevel logLevel, string message)
        {
            // "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
            var log = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt") +
                $" {LoggerName} {logLevel}: {message}";
            WriteToFile(log);
            return;
        }

        private void WriteToFile(string log) {
            writer.WriteLine(log);
            writer.Flush();
        }
    }
}
