using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Logger
{
    class FileLogger : BaseLogger
    {
        private string path;

        public FileLogger(string path)
        {
            
            //check if the path is valid

            if (File.Exists(path)){
                Console.WriteLine("the " + path + " is already existing");
            }

            else
            {
                Console.WriteLine("please update your path here: ");
                path = Console.ReadLine();
                File.Create(path);
                
            } //end check

            //update new path...
            this.path = path;

        }

        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter streamWriter = new StreamWriter(this.path);
            streamWriter.WriteLine( DateTime.Now.ToString() + " " + className + " " + logLevel + " " + message);
        }

        public void CreateLogger(string newLog)
        {
            this.path = newLog;
        }
    }
}
