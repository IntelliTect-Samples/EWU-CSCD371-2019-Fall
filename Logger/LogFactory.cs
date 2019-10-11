namespace Logger
{
    public class LogFactory
    {
        private string path;
        public BaseLogger CreateLogger(string className)
        {



            BaseLogger bl = new FileLogger(path)
            {
                className = className
            };


            if (path == null)
                return null;



            else return bl;
        }

        public void ConfigureFileLogger(string updatePath) { 
        
            path = updatePath;
        }
    }
}
