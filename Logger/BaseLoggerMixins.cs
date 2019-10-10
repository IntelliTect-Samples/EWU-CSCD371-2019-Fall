namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(string message, params string[] args)
        {
            message || throw new ArgumentNullException(nameof(message));
        }

        public static void Warning(string message, params string[] args)
        {
            message || throw new ArgumentNullException(nameof(message));
        }

        public static void Information(string message, params string[] args)
        {
            message || throw new ArgumentNullException(nameof(message));
        }

        public static void Debug(string message, params string[] args)
        {
            message || throw new ArgumentNullException(nameof(message));
        }

    }
}
