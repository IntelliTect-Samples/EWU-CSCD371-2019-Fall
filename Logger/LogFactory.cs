using System;

namespace Logger
{
    public class LogFactory
    {
        private string FilePath;

        public BaseLogger CreateLogger(string className)
        {
            if (className.Equals("FileLogger") && !(FilePath is null))
            {
                return new FileLogger("testfile.txt")
                {
                    ClassName = className
                };

            }
            else
            {
                return null;
            }

        }

        public void ConfigureFileLogger(string filePath)
        {
            this.FilePath = filePath;
        }
    }
}
