using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                baseLogger.Log(LogLevel.Error, string.Format(message, args));
            }
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                baseLogger.Log(LogLevel.Warning, string.Format(message, args));
            }
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                baseLogger.Log(LogLevel.Information, string.Format(message, args));
            }
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                baseLogger.Log(LogLevel.Debug, string.Format(message, args));
            }
        }
    }
}
