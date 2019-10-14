namespace Logger
{
    public abstract class BaseLogger
    {
        public abstract void Log(LogLevel logLevel, string message);
        public abstract string ClassName {get; set;}
    }
}
