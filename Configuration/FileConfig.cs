using System.IO;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            string path = "config.settings";
            // MMM Comment: What if path doesn't exist?
            if (File.Exists(path) && !(ConfigUtils.IsValidName(name)))
            {
                string[] fileContent = File.ReadAllLines(path);
                // MMM Comment: What if a line is blank or doesn't exist (edited manually for example)?
                foreach (string currentLine in fileContent)
                {
                    string lineName = currentLine.Split('=')[0];
                    if (name.Equals(lineName))
                    {
                        value = currentLine.Split('=')[1];
                        return true;
                    }
                }
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            // MMM Comment: What if you set the same setting twice?
            string path = "config.settings";
            if (value is null || !(File.Exists(path)) || !(ConfigUtils.IsValidName(name)))
                return false;
            File.AppendAllText(path, $"{name}={value}");
            return true;
        }
    }
}