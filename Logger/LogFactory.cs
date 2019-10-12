﻿namespace Logger
{
    public class LogFactory
    {
        private string path;

        public BaseLogger CreateLogger(string className)
        {
            if (path is null)
            {
                return null;
            } else
            {
                BaseLogger logger = new FileLogger(path)
                {
                    LoggerName = className
                };

                return logger;
            }
        }

        public void ConfigureFileLogger(string path)
        {
            this.path = path;
        }
    }
}
