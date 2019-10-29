using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Configuration
{
    public class FileConfig : IConfig, IEnumerable<(string name, string value)>
    {
        private string Filename { get; }

        public FileConfig(string filename)
        {
            Filename = filename ?? throw new ArgumentNullException(nameof(filename));
        } 

        public bool GetConfigValue(string name, out string? value)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            if (name.Length == 0) throw new ArgumentException($"{nameof(name)} cannot be empty.", nameof(name));
            if (name.Contains(" ")) throw new ArgumentException($"{nameof(name)} cannot contain spaces.", nameof(name));
            if (name.Contains("=")) throw new ArgumentException($"{nameof(name)} cannot contain equal signs.", nameof(name));

            value = File.Exists(Filename) switch
            {
                true => (from line in File.ReadAllLines(Filename)
                         let split = line.Split('=')
                         select (name: split[0], value: split[1]))
                        .FirstOrDefault(setting => setting.name == name).value,
                false => null
            };

            return !(value is null);
        }

        public bool SetConfigValue(string name, string value)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            if (name.Length == 0) throw new ArgumentException($"{nameof(name)} cannot be empty.", nameof(name));
            if (name.Contains(" ")) throw new ArgumentException($"{nameof(name)} cannot contain spaces.", nameof(name));
            if (name.Contains("=")) throw new ArgumentException($"{nameof(name)} cannot contain equal signs.", nameof(name));

            if (value is null) throw new ArgumentNullException(nameof(value));
            if (value.Length == 0) throw new ArgumentException($"{nameof(value)} cannot be empty.", nameof(value));
            if (value.Contains(" ")) throw new ArgumentException($"{nameof(value)} cannot contain spaces.", nameof(value));
            if (value.Contains("=")) throw new ArgumentException($"{nameof(value)} cannot contain equal signs.", nameof(value));

            IDictionary<string, string> settings = File.Exists(Filename) switch
            {
                true => (from line in File.ReadAllLines(Filename)
                         let split = line.Split('=')
                         select (name: split[0], value: split[1]))
                        .ToDictionary(setting => setting.name, setting => setting.value),
                false => new Dictionary<string, string>()
            };

            settings[name] = value;

            File.WriteAllLines(Filename, settings.Select(item => $"{item.Key}={item.Value}"));
            return true;
        }

        public IEnumerator<(string name, string value)> GetEnumerator() =>
            File.Exists(Filename) switch
            {
                true => (from line in File.ReadAllLines(Filename)
                         let split = line.Split('=')
                         select (split[0], split[1])).GetEnumerator(),
                false => new List<(string, string)>().GetEnumerator()
            };

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
