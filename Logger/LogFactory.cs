namespace Logger
{
    public class LogFactory
    {
        public string filePath;

        public BaseLogger CreateLogger(string className)
        {
            BaseLogger bLogger = new FileLogger(className,filePath);

            if (bLogger == null)
                return null;
            else
                return bLogger;
        }

        public void ConfigureFileLogger(string path)
        {
            filePath = path;
        }
    }
}
