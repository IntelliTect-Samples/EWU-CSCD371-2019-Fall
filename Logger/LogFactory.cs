namespace Logger
{
    public class LogFactory
    {
        private string filePath;

        public BaseLogger CreateLogger(string className)
        {
            BaseLogger logger;
            if (filePath is null) return null;
            else {
                logger = new FileLogger(filePath) {
                    LoggerName = className
                };
            }
            return logger;
        }

        public void ConfigureFileLogger(string path)
        {
            filePath = path;
        }
    }
}
