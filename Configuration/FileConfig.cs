using System;
using System.Collections.Generic;
using System.IO;

namespace Configuration {
    public class FileConfig {
        private string path;
        public FileConfig(string path) {
            this.path = path;
        }

        public void WriteToFile(EnvironmentConfig config) {
            List<string> names = config.getNames();
            using (StreamWriter sw = new StreamWriter(this.path, false)) {
                foreach (string name in names) {
                    sw.WriteLine($"{name}={Environment.GetEnvironmentVariable(name)}");
                }
            }
        }

        public List<string[]> ReadFromFile() {
            List<string[]> result = new List<String[]>();
            string[] lines = File.ReadAllLines(this.path);
            foreach (string line in lines) {
                result.Add(line.Split("="));
            }
            return result;
        }

        public string getPath() {
            return this.path;
        }
    }
}
