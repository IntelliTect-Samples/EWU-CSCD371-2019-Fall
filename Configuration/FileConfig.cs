using System;
using System.IO;
using System.Linq;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        public string Filename { get; }

        public FileConfig(string filename)
        {
            Filename = Path.Combine(Directory.GetCurrentDirectory(), filename) ?? throw new ArgumentNullException(nameof(filename));
        }

        public bool ReadConfigValue(string name, out string? value)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            if (name.Length == 0) throw new ArgumentException($"{nameof(name)} cannot be empty", nameof(name));
            if (name.Contains(" ")) throw new ArgumentException($"{nameof(name)} cannot contain a space", nameof(name));
            if (name.Contains("=")) throw new ArgumentException($"{nameof(name)} cannot contain an equal sign", nameof(name));

            if (File.Exists(Filename))
            {

                string[] lines = File.ReadAllLines(Filename);

                foreach (string line in lines)
                {
                    if (line.Contains(name))
                    {
                        var split = line.Split('=');
                        value = split[1];
                        return true;
                    }
                }
            }
            value = null;
            return false;
        }


        public bool WriteConfigValue(string name, string? value)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            if (name.Length == 0) throw new ArgumentException($"{nameof(name)} cannot be empty", nameof(name));
            if (name.Contains(" ")) throw new ArgumentException($"{nameof(name)} cannot contain a space", nameof(name));
            if (name.Contains("=")) throw new ArgumentException($"{nameof(name)} cannot contain an equal sign", nameof(name));

            if (value is null) throw new ArgumentNullException(nameof(value));
            if (value.Length == 0) throw new ArgumentException($"{nameof(value)} cannot be empty", nameof(value));
            if (value.Contains(" ")) throw new ArgumentException($"{nameof(value)} cannot contain a space", nameof(value));
            if (value.Contains("=")) throw new ArgumentException($"{nameof(value)} cannot contain an equal sign", nameof(value));

            using (StreamWriter writer = File.AppendText(Filename))
            {
                writer.WriteLine($"{name}={value}");
            }
            return true;
        }
    }
}