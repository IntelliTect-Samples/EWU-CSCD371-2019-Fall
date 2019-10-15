using System;

namespace Logger
{
    public class LogFactory
    {
        private string? FilePath { get; set; }

        public BaseLogger? CreateLogger(string className)
        {
            if (className is null) throw new ArgumentNullException(nameof(className));

            return FilePath switch
            {
                null      => null,
                string fp => new FileLogger(fp) { ClassName = className }
            };
        }

        public void ConfigureFileLogger(string filePath) => FilePath = filePath;
    }
}
