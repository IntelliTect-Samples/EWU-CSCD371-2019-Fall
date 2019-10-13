using System;

namespace Logger
{
    public class LogFactory
    {
        private string logFilePath = null;

        public BaseLogger CreateLogger(string className)
        {
            return string.IsNullOrEmpty(logFilePath) ? null : new FileLogger(logFilePath) { ClassName = className };
        }

        public void ConfigureLogger(string path) => logFilePath = path;
    }
}
