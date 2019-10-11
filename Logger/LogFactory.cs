namespace Logger
{
    public class LogFactory
    {
        private string filePath;
        public BaseLogger CreateLogger(string className)
        {
            if (!(this.filePath is null))
            {
                FileLogger myLogger = new FileLogger(this.filePath) { name = className };
                return myLogger;
            }
            return null;
        }

        public void ConfigureFileLogger(string filePath)
        {
            this.filePath = filePath;
        }
    }
}
