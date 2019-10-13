namespace Logger
{
    public class LogFactory
    {
        private string filePath;

        
        public BaseLogger CreateLogger(string className)
        {
            if (filePath != null)
            {
                BaseLogger baseLogger = new FileLogger(filePath)
                {
                    ClassName = className
                };
                return baseLogger;
            }
            return null;
        }

        public void ConfigureFileLogger(string filePath) => this.filePath = filePath;
        
    }
}
