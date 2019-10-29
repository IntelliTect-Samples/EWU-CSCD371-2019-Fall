using System.IO;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            string path = "config.settings";
            if (File.Exists(path) && !(ConfigUtils.IsValidName(name)))
            {
                string[] fileContent = File.ReadAllLines(path);
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
            string path = "config.settings";
            if (value is null || !(File.Exists(path)) || !(ConfigUtils.IsValidName(name)))
                return false;
            File.AppendAllText(path, $"{name}={value}");
            return true;
        }
    }
}