namespace Logger
{
    public abstract class BaseLogger
    {
        public string name{get;set;}
        public abstract void Log(LogLevel logLevel, string message);
    }
}
