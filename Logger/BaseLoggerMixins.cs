namespace Logger
{
    public static class BaseLoggerMixins
    {
        /*
         Inside of BaseLoggerMixins implement extension methods on BaseLogger for Error, Warning, Information, and Debug. 
         Each of these methods should take in a string for the message, as well as a parameter array of arguments for the message. 
         Each of these extension methods is expected to be a shortcut for calling the BaseLogger.Log method, by automatically supplying the appropriate LogLevel. 
         These methods should throw an exception if the BaseLogger parameter is null. There are a couple example unit tests to get you started.
        */


        public static void Warning(BaseLogger logger, string message, params object[] args)
        {
            if (logger is null)
                throw new System.Exception();

            logger.Log(LogLevel.Warning, string.Format(message, args));
        }
        public static void Information(BaseLogger logger, string message, params object[] args)
        {
            if (logger is null)
                throw new System.Exception();

            logger.Log(LogLevel.Information, string.Format(message, args));
        }
        public static void Debug(BaseLogger logger, string message, params object[] args)
        {
            if (logger is null)
                throw new System.Exception();

            logger.Log(LogLevel.Debug, string.Format(message, args));
        }
        public static void Error(BaseLogger logger, string message, params object[] args) 
        {
            if (logger is null) 
                throw new System.Exception();
            
            logger.Log(LogLevel.Error, string.Format(message, args));
        }
    }
}
