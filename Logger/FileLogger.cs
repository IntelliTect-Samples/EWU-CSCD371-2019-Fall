using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
	    public FileLogger()
	    {
	    }

        public override void Log(LogLevel logLevel, string message)
        {
            using (StreamWriter sw = File.AppendText(FilePath))
            {
                sw.WriteLine(DateTime.Now + " " + ClassName + " " + logLevel + " " + message);
            }
        }
        public override string ClassName { get; set; }
        private string FilePath { get; set; }
        public void setPath(string path)
        {
            FilePath = path;
        }
    }
}

