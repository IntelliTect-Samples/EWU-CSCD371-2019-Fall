namespace Logger
{
    public class LogFactory
    {
        public string outPath;

        public BaseLogger CreateLogger(string className)
        {
            if (outPath == null){
                return null;
            }
            BaseLogger baseLogger = new FileLogger(outPath){
                className = className
            };
            return BaseLogger;
        }

        public void ConfigureFileLogger(string outPath){
            this.outPath = outPath;
        }
    }
}
