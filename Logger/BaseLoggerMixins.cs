using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] messageArgs)
        {
            if (baseLogger == null) throw new ArgumentNullException("BaseLogger is null");
            baseLogger.Log(LogLevel.Error, string.Format(message, messageArgs));
        }
        public static void Warning(this BaseLogger baseLogger, string message, params object[] messageArgs)
        {
            if (baseLogger == null) throw new ArgumentNullException("BaseLogger is null");
            baseLogger.Log(LogLevel.Warning, string.Format(message, messageArgs));
        }
        public static void Information(this BaseLogger baseLogger, string message, params object[] messageArgs)
        {
            if (baseLogger == null) throw new ArgumentNullException("BaseLogger is null");
            baseLogger.Log(LogLevel.Information, string.Format(message, messageArgs));
        }
        public static void Debug(this BaseLogger baseLogger, string message, params object[] messageArgs)
        {
            if (baseLogger == null) throw new ArgumentNullException("BaseLogger is null");
            baseLogger.Log(LogLevel.Debug, string.Format(message, messageArgs));
        }
    }
}
