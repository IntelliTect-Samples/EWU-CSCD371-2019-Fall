using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string _path { get; set; }

        public FileLogger(string path)
        {
			if (!(path is null) && path != "")
			{
				_path = path;
				if (!File.Exists(path))
				{
					File.Create(path).Dispose();
				}
			}
			else
			{
				throw new ArgumentNullException(path, "Path cannot be null");
			}
		}

        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter streamWriter = new StreamWriter(_path);
            string log = $"{ DateTime.Now.ToString()} { LoggerName} { logLevel} { message}";
            streamWriter.WriteLine(log);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
