namespace Logger
{
    public abstract class BaseLogger
    {
        public abstract string LoggerName { get; set; }
        public abstract void Log(LogLevel logLevel, string message);
    }
}
