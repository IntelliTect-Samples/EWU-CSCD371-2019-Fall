using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null || message is null || message == "")
            {
                throw new ArgumentNullException(nameof(baseLogger));
            } else
            {
                LogLevel level = LogLevel.Error;
                baseLogger.Log(level, string.Format(message, args));
            }
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null || message is null || message == "")
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                LogLevel level = LogLevel.Warning;
                baseLogger.Log(level, message);
            }
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null || message is null || message == "")
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                LogLevel level = LogLevel.Information;
                baseLogger.Log(level, message);
            }
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null || message is null || message == "")
            {
                throw new ArgumentNullException(nameof(baseLogger));
            }
            else
            {
                LogLevel level = LogLevel.Debug;
                baseLogger.Log(level, message);
            }
        }
    }
}
