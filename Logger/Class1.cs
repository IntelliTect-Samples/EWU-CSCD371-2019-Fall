using System;
using System.IO;

namespace Logger
{
    class FileLogger
    {
        public string Path { get; }

        public FileLogger(string filePath)
        {
            Path = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }
    }
}
