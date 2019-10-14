using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params object[] args)
            => WriteLog(logger, LogLevel.Error, message, args);

        public static void Warning(this BaseLogger logger, string message, params object[] args)
            => WriteLog(logger, LogLevel.Warning, message, args);

        public static void Information(this BaseLogger logger, string message, params object[] args)
            => WriteLog(logger, LogLevel.Information, message, args);

        public static void Debug(this BaseLogger logger, string message, params object[] args)
            => WriteLog(logger, LogLevel.Debug, message, args);

        private static void WriteLog(BaseLogger logger, LogLevel level, string message, params object[] args)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            logger.Log(level, string.Format(message, args));
        }
    }
}
