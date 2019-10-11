using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string filePath;

        public void SetFilePath(string newFilePath)
        {
            filePath = newFilePath;

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            string messageLog = $"{DateTime.Now} {ClassName} {logLevel}: {message}";

            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(messageLog);
            }
        }
    }
}
