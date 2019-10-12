namespace Logger
{
    public abstract class BaseLogger
    {

        public string Name { get; set; }
        public abstract void Log(LogLevel logLevel, string message);
    }
}
