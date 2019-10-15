using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] args)
        {
            if(baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }
            else
            {
                LogLevel logLevel = LogLevel.Error;
                baseLogger.Log(logLevel, String.Format(message, args));
            }
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }
            else
            {
                LogLevel logLevel = LogLevel.Warning;
                baseLogger.Log(logLevel, String.Format(message, args));
            }
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }
            else
            {
                LogLevel logLevel = LogLevel.Information;
                baseLogger.Log(logLevel, String.Format(message, args));
            }
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new System.ArgumentNullException("baseLogger is null");
            }
            else
            {
                LogLevel logLevel = LogLevel.Debug;
                baseLogger.Log(logLevel, String.Format(message, args));
            }
        }
    }
}
