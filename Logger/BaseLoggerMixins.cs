using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Error;

            if(baseLogger is null)
            {
                throw new ArgumentNullException(baseLogger.ToString());
            }
            else
            {
                baseLogger.Log(logLevel, message);
            }
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Warning;

            if (baseLogger is null)
            {
                throw new ArgumentNullException(baseLogger.ToString());
            }
            else
            {
                baseLogger.Log(logLevel, message);
            }
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Information;

            if (baseLogger is null)
            {
                throw new ArgumentNullException(baseLogger.ToString());
            }
            else
            {
                baseLogger.Log(logLevel, message);
            }
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] args)
        {
            LogLevel logLevel = LogLevel.Debug;

            if (baseLogger is null)
            {
                throw new ArgumentNullException(baseLogger.ToString());
            }
            else
            {
                baseLogger.Log(logLevel, message);
            }
        }
    }
}
