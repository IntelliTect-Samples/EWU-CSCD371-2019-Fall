using System;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public String filePath { get; }

        public FileLogger(String filePath)
        {
            this.filePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(System.DateTime.Now + " ");
            sb.Append(this.name + " ");
            sb.Append(logLevel.ToString() + " ");
            sb.Append(message + Environment.NewLine);
            System.IO.File.AppendAllText(filePath, sb.ToString());
        }
    }
}