using System;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private String path;
        
        public FileLogger(String path)
        {
            this.path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now);
            sb.Append(ClassName);
            sb.Append(logLevel);
            sb.Append(message);
            sb.Append(Environment.NewLine);

            File.AppendAllText(path, sb.ToString());
        }
    }
}