using System;

namespace Logger
{
    public class LogFactory
    {
        public BaseLogger CreateLogger(string className)
        {
            if (className.Equals("FileLogger"))
                return new FileLogger(className);
            else
                throw new ArgumentException();
        }
    }
}
