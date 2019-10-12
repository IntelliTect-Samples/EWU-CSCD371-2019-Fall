using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger baseLogger, string message, params int[] v)
        {
            if (baseLogger is null) { throw new ArgumentNullException(); }

            string[] parameters = new string[v.Length];

            for (int i = 0; i < v.Length; i++)
            {
                parameters[i] = v[i].ToString();
            }

            baseLogger.Log(LogLevel.Error, String.Format(message, parameters));//check for null?
        }
    }
}
