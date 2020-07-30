namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Warning(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException("baseLogger");
            }

            baseLogger.Log(LogLevel.Warning, string.Format(message, args));
        }

        public static void Error(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException("baseLogger");
            }
            baseLogger.Log(LogLevel.Error, string.Format(message,args));
        }

        public static void Information(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException("baseLogger");
            }
            baseLogger.Log(LogLevel.Information, string.Format(message, args));
        }

        public static void Debug(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException("baseLogger");
            }
            baseLogger.Log(LogLevel.Debug, string.Format(message,args));
        }
    }
}
