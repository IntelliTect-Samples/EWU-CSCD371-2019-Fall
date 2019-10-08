using System;

namespace Logger
{
    public class FileLogger: BaseLogger
    {
        private string _LoggerName; // Is this the correct naming convention?

        public string LoggerName
        {
            get { return _LoggerName; }

            // TODO: check for existing filepath before creating new file?
            set { _LoggerName = value; }
        }

        public static void Main(string[] args) { }

        override public void Log(LogLevel logLevel, string message)
        {
            // "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
            string log = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt") +
                $"{LoggerName} {logLevel}: {message}";
            return;
        }

        private void WriteToFile() {}
    }
}
