namespace Logger
{
    public static class BaseLoggerMixins 
    {
        public static void Error(this BaseLogger baseLogger, string message, params string[] args)
        { 
            if(baseLogger is null)
            {
                throw new System.ArgumentNullException();
            }
            LogLevel logLevelError = LogLevel.Error;
            baseLogger.Log(logLevelError, string.Format(message, args));
        }

        public static void Warning(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger is null)
            {
                throw new System.ArgumentNullException();
            }
            LogLevel logLevelWarning = LogLevel.Warning;
            baseLogger.Log(logLevelWarning, string.Format(message, args));
        }
        public static void Information(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger is null)
            {
                throw new System.ArgumentNullException();
            }
            LogLevel logLevelInformation = LogLevel.Information;
            baseLogger.Log(logLevelInformation, string.Format(message, args));
        }

        public static void Debug(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger is null)
            {
                throw new System.ArgumentNullException();
            }
            LogLevel logLevelDebug = LogLevel.Debug;
            baseLogger.Log(logLevelDebug, string.Format(message, args));
        }
    }
}
