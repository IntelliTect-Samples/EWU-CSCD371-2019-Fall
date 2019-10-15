using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ExceptionLogger : FileLogger
    {
        public ExceptionLogger() : base() { }
        public ExceptionLogger(string path) : base(path) { }

        public void Log(LogLevel level, Exception exception)
        {
            if (exception is null) return;

            base.Log(level, $"{exception}");
        }
    }
}
