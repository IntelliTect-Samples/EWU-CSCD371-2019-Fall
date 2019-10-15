using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string path;

        public FileLogger(string filePath)
        {
            path = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if(!(path is null) && File.Exists(path))
            {
                string output = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + " " + ClassName + " " + logLevel + ": " + message + Environment.NewLine;
                File.AppendAllText(path, output);
            }
        }
    }
}
