using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class ConsoleLogger : BaseLogger
    {
        public override void Log(LogLevel logLevel, string message)
        {
            string finalMessage = $"{DateTime.Now} {ClassName} {logLevel} {message}";
            Console.WriteLine(finalMessage);
        }
    }
}
