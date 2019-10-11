namespace Logger
{
    public class LogFactory
    {
        private string filePath;
        public BaseLogger CreateLogger(string className)
        {
            if(filePath == null)
            {
                return null;
            }
            else
            {
                FileLogger fileLogger = new FileLogger
                {
                    ClassName = className
                };

                fileLogger.SetFilePath(filePath);
                return fileLogger;
            }
        }

        public void ConfigureFileLogger(string newFilePath)
        {
            filePath = newFilePath;
        }
    }
}
