using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params string[] args)
        {
            if(baseLogger == null)
            {
                throw new ArgumentNullException();
            }

            baseLogger.Log(LogLevel.Error, message);
        }

        public static void Warning(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException();
            }

            baseLogger.Log(LogLevel.Warning, message);
        }

        public static void Information(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException();
            }

            baseLogger.Log(LogLevel.Information, message);
        }

        public static void Debug(this BaseLogger baseLogger, string message, params string[] args)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException();
            }

            baseLogger.Log(LogLevel.Debug, message);
        }
    }
}
