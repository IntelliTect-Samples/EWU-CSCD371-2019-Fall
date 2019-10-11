using System;
using System.Text;

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

            StringBuilder sb = new StringBuilder();
            foreach (object o in args)
            {
                sb.Append(o.ToString());
            }
            message += sb.ToString();

            LogLevel logLevel = LogLevel.Error;

            baseLogger.Log(logLevel, message);
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }

            StringBuilder sb = new StringBuilder();
            foreach (object o in args)
            {
                sb.Append(o.ToString());
            }
            message += sb.ToString();

            LogLevel logLevel = LogLevel.Warning;

            baseLogger.Log(logLevel, message);
        }
        public static void Information(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }

            StringBuilder sb = new StringBuilder();
            foreach (object o in args)
            {
                sb.Append(o.ToString());
            }
            message += sb.ToString();

            LogLevel logLevel = LogLevel.Information;

            baseLogger.Log(logLevel, message);
        }

        public static void Debug(this BaseLogger baseLogger, string message, params object[] args)
        {
            if (baseLogger is null)
            {
                throw new ArgumentNullException("baseLogger is null");
            }

            StringBuilder sb = new StringBuilder();
            foreach (object o in args)
            {
                sb.Append(o.ToString());
            }
            message += sb.ToString();

            LogLevel logLevel = LogLevel.Debug;

            baseLogger.Log(logLevel, message);
        }
    }
}
