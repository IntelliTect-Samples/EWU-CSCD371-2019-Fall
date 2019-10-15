namespace Logger
{
    public class LogFactory
    {
        private string path;

        public BaseLogger CreateLogger(string className)
        {
            if (path is null)
                return null;

            return new FileLogger(path) { ClassName = className };
        }

        public void ConfigureFileLogger(string filePath)
        {
            path = filePath;
        }
    }
}
