namespace Logger
{
    public class LogFactory
    {
        private string filepath;
        public BaseLogger CreateLogger(string className)
        {
            return string.IsNullOrEmpty(filepath) ? null : new FileLogger(filepath) { Name = className };
        }

        public void ConfigureFileLogger(string path)
        {
            filepath = path;
        }
    }
}
