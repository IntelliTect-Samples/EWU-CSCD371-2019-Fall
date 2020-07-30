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
            if (path == null)
            {
                throw new ArgumentNullException("path");
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

            string finalMessage = string.Format("{0} {1} {2} {3} {4}",
                                                DateTime.Now, ClassName, loggingLevel, message, System.Environment.NewLine);
            File.AppendAllText(FilePath, finalMessage);

        }
    }
}
