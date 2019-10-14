namespace Logger
{
    public class LogFactory
    {
        public BaseLogger CreateLogger(string className)
        {
            if(className == "BlankLogger")
            {
                BlankLogger blankLogger = new BlankLogger();
                blankLogger.ClassName = className;
                return blankLogger;
            }
            return null;
        }
    }
}
