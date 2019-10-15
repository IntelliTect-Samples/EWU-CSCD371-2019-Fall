namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger bLogger, string message,params string[] args)
        {
            if (bLogger == null) { throw new System.ArgumentNullException("The BaseLogger Parameter is null"); }
            bLogger.Log(LogLevel.Error, message);
        }
        public static void Debug(this BaseLogger bLogger, string message, params string[] args)
        {
            if (bLogger == null) { throw new System.ArgumentNullException("The BaseLogger Parameter is null"); }
            bLogger.Log(LogLevel.Debug, message);
        }
        public static void Warning(this BaseLogger bLogger, string message, params string[] args)
        {
            if (bLogger == null) { throw new System.ArgumentNullException("The BaseLogger Parameter is null"); }
            bLogger.Log(LogLevel.Warning, message);
        }
        public static void Information(this BaseLogger bLogger, string message, params string[] args)
        {
            if (bLogger == null) { throw new System.ArgumentNullException("The BaseLogger Parameter is null"); }
            bLogger.Log(LogLevel.Information, message);
        }
    }
}
