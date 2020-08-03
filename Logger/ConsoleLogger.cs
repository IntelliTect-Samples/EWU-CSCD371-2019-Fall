using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ConsoleLogger : BaseLogger
    {
        public override void Log(LogLevel logLevel, string message)
        {
            string loggingLevel;

            switch (logLevel)
            {
                case LogLevel.Information:
                    loggingLevel = "Information";
                    break;
                case LogLevel.Error:
                    loggingLevel = "Error";
                    break;
                case LogLevel.Warning:
                    loggingLevel = "Warning";
                    break;
                default:
                    loggingLevel = "Debug";
                    break;
            }

            string finalMessage = $"{DateTime.Now} {ClassName} {loggingLevel} {message}";
            Console.WriteLine(finalMessage);
        }
    }
}
