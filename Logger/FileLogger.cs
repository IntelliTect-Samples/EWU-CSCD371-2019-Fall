using System;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public FileLogger()
        {
        }

        public override void Log(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }
    }
}