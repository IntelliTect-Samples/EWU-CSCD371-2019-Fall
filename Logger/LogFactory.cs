using System;

namespace Logger
{
    public class LogFactory
    {
        private string filePath;

        public BaseLogger CreateLogger(string className)
        {
            if (className is null)
                throw new ArgumentNullException("className was null");
            if (!(this.filePath is null))
            {
                FileLogger myLogger = new FileLogger(this.filePath) { name = className };
                return myLogger;
            }
            return null;
        }

        public void ConfigureFileLogger(string filePath)
        {
            if (filePath is null)
                throw new ArgumentNullException("filePath was null");
            this.filePath = filePath;
        }
    }
}