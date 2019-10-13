namespace Logger
{

    public class LogFactory
    {

        private string _path;

        public BaseLogger CreateLogger(string className)
        {
            if (_path is null)
            {
                return null;
            }

            BaseLogger baseLogger = new FileLogger(_path) {ClassName = className};
            return baseLogger;
        }

        public void ConfigureFileLogger(string path)
        {
            _path = path;
        }

    }

}
