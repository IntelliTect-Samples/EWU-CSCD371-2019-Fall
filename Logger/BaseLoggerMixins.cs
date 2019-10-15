using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params int[] v)
        {
            LogLevelMessage(LogLevel.Error, baseLogger, message, v);
        }

        public static void Warning(this BaseLogger baseLogger, string message, params int[] v)
        {
            LogLevelMessage(LogLevel.Warning, baseLogger, message, v);
        }

        public static void Information(this BaseLogger baseLogger, string message, params int[] v)
        {
            LogLevelMessage(LogLevel.Information, baseLogger, message, v);
        }

        public static void Debug(this BaseLogger baseLogger, string message, params int[] v)
        {
            LogLevelMessage(LogLevel.Debug, baseLogger, message, v);
        }

        private static void LogLevelMessage(LogLevel LL, BaseLogger baseLogger, string message, params int[] v)
        {
            if (baseLogger is null) { throw new ArgumentNullException(); }

            string[] parameters = new string[v.Length];

            for (int i = 0; i < v.Length; i++)
            {
                parameters[i] = v[i].ToString();
            }

            baseLogger.Log(LL, string.Format(message, parameters));
        }
    }
}
