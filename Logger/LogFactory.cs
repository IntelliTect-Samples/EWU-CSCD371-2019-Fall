namespace Logger
{
    public class LogFactory
    {
        private string path;
        public BaseLogger CreateLogger(string className)
        {
            BaseLogger newBaseLogger = new FileLogger(this.path);
            newBaseLogger.className = className;

            return newBaseLogger;
        }

        public void ConfigureFileLogger(string newPath)
        {

        }
    }
}
