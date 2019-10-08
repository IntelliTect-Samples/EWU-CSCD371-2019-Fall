namespace Logger
{
    public class LogFactory
    {
        public BaseLogger CreateLogger(string className)
        {
            Logger logger = new BaseLogger() {
                LoggerName = className
            };
            return logger;
        }
    }
}
