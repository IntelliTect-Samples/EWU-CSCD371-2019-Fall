using System;

namespace Logger
{
    public class BlankLogger : BaseLogger
    {
        public override void Log(LogLevel logLevel, string message)
        {

        }
        public override string ClassName { get; set; }

    }

}
