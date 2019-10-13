namespace Logger
{
    public class LogFactory
    {
        private string filePath;
        public BaseLogger CreateLogger(string className)
        {
            if (filePath is null)
            {
                return null;
            }

            var logger = new FileLogger(filePath) { ClassName = className };
            if (logger.ClassName is null)
            {
                logger.ClassName = "CLASSNAME NOT GIVEN";
            }
            return logger;
        }

        public void ConfigureFileLogger(string filePath) => this.filePath = filePath;
    }
}
