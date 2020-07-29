namespace Logger
{
    public class LogFactory
    {
        private string FilePath { get; set; }

        public void ConfigureFileLogger(string path)
        {
            FilePath = path;
        }

        public BaseLogger CreateLogger(string className)
        {

            if (FilePath == null)
            {
                return null;
            }

            return new FileLogger(FilePath)
            {
                ClassName = className
            };
        }
    }
}
