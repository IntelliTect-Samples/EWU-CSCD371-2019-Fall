using System;
namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void GenericMixin(this BaseLogger baseLogger, string message, int logLevel, params object[] args)
        {
            if (baseLogger == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                baseLogger.Log((Logger.LogLevel)logLevel, string.Format(message, args));
            }
        }

        public static void Error(this BaseLogger baseLogger, string message, params object[] args) => GenericMixin(baseLogger, message, 0, args);

        public static void Warning(this BaseLogger baseLogger, string message, params object[] args) => GenericMixin(baseLogger, message, 1, args);

        public static void Information(this BaseLogger baseLogger, string message, params object[] args) => GenericMixin(baseLogger, message, 2, args);

        public static void Debug(this BaseLogger baseLogger, string message, params object[] args) => GenericMixin(baseLogger, message, 3, args);
    }
}
