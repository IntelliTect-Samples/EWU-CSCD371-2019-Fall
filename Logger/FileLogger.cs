namespace Logger
{
    public class FileLogger: BaseLogger
    {
        private string _LoggerName; // Is this the correct naming convention?

        override public string LoggerName {
            get {};
            set {};
        }

        public static void Main(string[] args) {

        }

        override public void Log(LogLevel logLevel, string message) {
            return;
        }
    }
}
