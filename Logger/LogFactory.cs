namespace Logger
{
    public class LogFactory
    {
        private string FilePath { get; set; }
        public BaseLogger CreateLogger(string className)
        {
            if(className == "BlankLogger")
            {
                BlankLogger blankLogger = new BlankLogger();
                blankLogger.ClassName = className;
                return blankLogger;
            }
            else if(className == "FileLogger")
            {
                if(FilePath != null)
                {
                    FileLogger fileLogger = new FileLogger();
                    fileLogger.ClassName = className;
                    fileLogger.setPath(FilePath);
                    return fileLogger;
                }
                
            }
            return null;
        }

        public void ConfigureFileLogger(string path)
        {
            FilePath = path;
        }
    }
}
