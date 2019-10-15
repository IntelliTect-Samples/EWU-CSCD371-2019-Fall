using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string filePath;
        private string cName;
        private StreamWriter streamWriter;

        public FileLogger(string className, string path)
        {
            cName = className;
            filePath = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-US");
            streamWriter = new StreamWriter(filePath);
            string toWrite = localDate.ToString(culture) + " " + cName + " " + logLevel + ": " + message;

            streamWriter.WriteLine(toWrite);
            streamWriter.Close();
        }
    }
}
