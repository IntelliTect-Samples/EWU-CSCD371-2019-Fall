using System;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string path;
        
        public FileLogger(string path)
        {
            this.path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now);
            sb.Append(" ");
            sb.Append(ClassName);
            sb.Append(" ");
            sb.Append(logLevel);
            sb.Append(": ");
            sb.AppendLine(message);

            File.AppendAllText(path, sb.ToString());
        }
    }
}