namespace Logger
{
    public abstract class BaseLogger
    {
        private string _LoggerName;
        public abstract string LoggerName { get; set; }
        public abstract void Log(LogLevel logLevel, string message);
    }
}
