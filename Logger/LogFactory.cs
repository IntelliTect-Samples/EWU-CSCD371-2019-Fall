namespace Logger
{
    public class LogFactory
    {
        private BaseLogger logger;

        public BaseLogger CreateLogger(string className)
        {
            logger = new FileLogger("FactoryLogger") {
                LoggerName = className
            };
            return logger;
        }

        public void ConfigureFileLogger() {}
    }
}
