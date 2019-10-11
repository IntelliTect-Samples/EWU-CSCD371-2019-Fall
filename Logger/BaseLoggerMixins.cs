using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params object[] vs)
        {
            LogLevel logLevel = LogLevel.Error;

            if (baseLogger == null)
                throw new ArgumentNullException(baseLogger.ToString());

            else {
                message = Convert.ToString(vs); 
                baseLogger.Log(logLevel, message);
            }
        }

        public static void Warning(this BaseLogger baseLogger, string message, params object[] vs)
        {
            LogLevel logLevel = LogLevel.Warning;

            if (baseLogger == null)
                throw new ArgumentNullException(baseLogger.ToString());

            else
            {
                message = Convert.ToString(vs);
                baseLogger.Log(logLevel, message);
            }
        }

        public static void Information(this BaseLogger baseLogger, string message, params object[] vs)
        {
            LogLevel logLevel = LogLevel.Information;

            if (baseLogger == null)
                throw new ArgumentNullException(baseLogger.ToString());

            else
            {
                message = Convert.ToString(vs);
                baseLogger.Log(logLevel, message);
            }
        }


        public static void Debug(this BaseLogger baseLogger, string message, params object[] vs)
        {
            LogLevel logLevel = LogLevel.Debug;

            if (baseLogger == null)
                throw new ArgumentNullException(baseLogger.ToString());

            else
            {
                message = Convert.ToString(vs);
                baseLogger.Log(logLevel, message);
            }
        }
    }
}
