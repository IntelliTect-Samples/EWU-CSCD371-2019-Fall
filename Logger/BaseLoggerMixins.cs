using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }

            for (int i = 0; i < args.Length; i++)
            {
                string toBeReplaced = "{" + i + "}";
                message = message.Replace(toBeReplaced, args[i].ToString());
            }

            baseLogger.Log(LogLevel.Error, message);
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }

            for (int i = 0; i < args.Length; i++)
            {
                string toBeReplaced = "{" + i + "}";
                message = message.Replace(toBeReplaced, args[i].ToString());
            }

            baseLogger.Log(LogLevel.Warning, message);
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }

            for (int i = 0; i < args.Length; i++)
            {
                string toBeReplaced = "{" + i + "}";
                message = message.Replace(toBeReplaced, args[i].ToString());
            }

            baseLogger.Log(LogLevel.Information, message);
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }

            for (int i = 0; i < args.Length; i++)
            {
                string toBeReplaced = "{" + i + "}";
                message = message.Replace(toBeReplaced, args[i].ToString());
            }

            baseLogger.Log(LogLevel.Debug, message);
        }
    }
}