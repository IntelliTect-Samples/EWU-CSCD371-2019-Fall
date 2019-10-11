namespace Logger
{
    public class LogFactory
    {
        private string filePath;
        public BaseLogger CreateLogger(string className)
        {
            if(this.filePath is null)
            {
                return null;
            }
            else
            {
                BaseLogger newBaseLogger = new FileLogger(filePath) 
                { 
                    className = className 
                };
                return newBaseLogger;
            }           
        }

        public void ConfigureFileLogger(string newPath)
        {
            this.filePath = newPath;
        }
    }
}
