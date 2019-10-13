using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(DateTime.Now.ToString() + " ");
                writer.Write(ClassName + " ");
                writer.Write(logLevel + " : ");
                writer.Write(message);
                writer.WriteLine();
            }
        }
    }
}
