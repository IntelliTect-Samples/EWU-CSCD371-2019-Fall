using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params object[] messageArguments)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Error, string.Format(message, messageArguments));
        }

        public static void Warning(this BaseLogger logger, string message, params object[] messageArguments)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Warning, string.Format(message, messageArguments));
        }

        public static void Info(this BaseLogger logger, string message, params object[] messageArguments)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Information, string.Format(message, messageArguments));
        }

        public static void Debug(this BaseLogger logger, string message, params object[] messageArguments)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Debug, string.Format(message, messageArguments));
        }
    }
}
