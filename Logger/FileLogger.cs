namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private readonly string filePath;
        public FileLogger(string filePath) => this.filePath = filePath;
        public override void Log(LogLevel logLevel, string message)
        {
            var sb = new System.Text.StringBuilder($"{System.DateTime.Now.ToString()} {ClassName} {logLevel}: {message}\n");

            System.IO.File.AppendAllText(filePath, sb.ToString());
        }
    }
}
