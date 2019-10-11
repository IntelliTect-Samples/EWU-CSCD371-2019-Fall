namespace Logger
{
    public class LogFactory
    {
        private string pathToFile;

        public BaseLogger CreateLogger(string className)
        {
            if(pathToFile is null){
                return null;
            }

            return new FileLogger(pathToFile);
        }

        public void ConfigureFileLogger(string path)
        {
            pathToFile = path;
        }
    }
}
