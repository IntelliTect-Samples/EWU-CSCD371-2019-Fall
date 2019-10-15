using System;
using System.Text;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] argArray)
        {
            if (baseLogger is null)
                throw new ArgumentNullException();

            baseLogger.Log(LogLevel.Error, String.Format(message, argArray));

        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] argArray)
        {
            if (baseLogger is null)
                throw new ArgumentNullException();

            baseLogger.Log(LogLevel.Warning, String.Format(message, argArray));

        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] argArray)
        {
            if (baseLogger is null)
                throw new ArgumentNullException();

            baseLogger.Log(LogLevel.Information, String.Format(message, argArray));

        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] argArray)
        {
            if (baseLogger is null)
                throw new ArgumentNullException();

            baseLogger.Log(LogLevel.Debug, String.Format(message, argArray));

        }
    }
}
