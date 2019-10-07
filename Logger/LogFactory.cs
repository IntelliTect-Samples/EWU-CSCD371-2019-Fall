namespace Logger
{
    public class LogFactory
    {
        private string LogFile { get; set; }

        public void ConfigureFileLogger(string logFile)
        {
            LogFile = logFile;
        }

        public BaseLogger CreateLogger(string className)
        {
            if (!string.IsNullOrWhiteSpace(LogFile))
            {
                return new FileLogger(LogFile)
                {
                    ClassName = className
                };
            }

            return null;
        }
    }
}
