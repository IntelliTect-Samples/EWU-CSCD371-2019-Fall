using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string s, params object[] args)
        {
            LogLevel logLevel = LogLevel.Error;

            if (baseLogger == null)
            {
                throw new ArgumentNullException("baseLogger is null!");
            }
            else
            {
                for (int i = 0;i<args.Length;i++){
                    s+=args[i].ToString();
                }
                baseLogger.Log(logLevel, s);
            }
        }

        public static void Warning(this BaseLogger baseLogger, string s, params object[] args)
        {
            LogLevel logLevel = LogLevel.Warning;

            if (baseLogger == null)
            {
                throw new ArgumentNullException("baseLogger is null!");
            }
            else
            {
                for (int i = 0;i<args.Length;i++){
                    s+=args[i].ToString();
                }
                baseLogger.Log(logLevel, s);
            }
        }

        public static void Information(this BaseLogger baseLogger, string s, params object[] args)
        {
            LogLevel logLevel = LogLevel.Information;

            if (baseLogger == null)
            {
                throw new ArgumentNullException("baseLogger is null!");
            }
            else
            {
                for (int i = 0;i<args.Length;i++){
                    s+=args[i].ToString();
                }
                baseLogger.Log(logLevel, s);
            }
        }

        public static void Debug(this BaseLogger baseLogger, string s, params object[] args)
        {
            LogLevel logLevel = LogLevel.Debug;

            if (baseLogger == null)
            {
                throw new ArgumentNullException("baseLogger is null!");
            }
            else
            {
                for (int i = 0;i<args.Length;i++){
                    s+=args[i].ToString();
                }
                baseLogger.Log(logLevel, s);
            }
        }
    }
}