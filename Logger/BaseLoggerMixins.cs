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

            baseLogger.Log(LogLevel.Warning, message);
        }

        public static void Error(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException("baseLogger");
            }
            baseLogger.Log(LogLevel.Error, message);
        }

        public static void Information(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException("baseLogger");
            }
            baseLogger.Log(LogLevel.Information, message);
        }

        public static void Debug(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new System.ArgumentNullException("baseLogger");
            }
            baseLogger.Log(LogLevel.Debug, message);
        }
    }
}
