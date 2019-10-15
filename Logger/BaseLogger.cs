namespace Logger
{
    public abstract class BaseLogger
    {
        public string cName { get; set; }

        public abstract void Log(LogLevel logLevel, string message);
    }
}
