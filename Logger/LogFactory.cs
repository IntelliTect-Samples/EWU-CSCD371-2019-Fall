using System;

namespace Logger
{
    public class LogFactory
    {
        private string FilePath;

        public BaseLogger CreateLogger(string className)
        {
            if (className.Equals("FileLogger"))
                if (FilePath is null)
                {
                    return null;
                }

                else
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
