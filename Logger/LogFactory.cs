namespace Logger
{
    public class LogFactory
    {
        private string filePath;
        public BaseLogger CreateLogger(string className)
        {
            if(filePath is null)
            {
                return null;
            }
            else
            {
                BaseLogger logger = new FileLogger(filePath)
                {
                    className = className
                };

                return logger;
            }
        }

        public void ConfigureFileLogger(string path)
        {
            filePath = path;
        }
    }
}
