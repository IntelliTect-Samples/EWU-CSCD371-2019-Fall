using System;

namespace Logger
{
    public class FileLogger: BaseLogger
    {
        private string _LoggerName; // Is this the correct naming convention?

        override public string LoggerName
        {
            public  get { return _LoggerName; }

            // TODO: check for existing filepath before creating new file
            private set {}
        }

        public static void Main(string[] args)
        {

        }

        override public void Log(LogLevel logLevel, string message)
        {

            return;
        }
    }
}
