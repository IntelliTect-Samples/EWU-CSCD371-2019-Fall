using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Configuration
{
    public class EnvironmentConfig : IConfig, IEnumerable<(string name, string value)>
    {
        // MMM Comment: Refactor commont code with SetConfigValue. 
        public bool GetConfigValue(string name, out string? value)
        {
            if (name is null) throw new ArgumentNullException(nameof(name));
            if (name.Length == 0) throw new ArgumentException($"{nameof(name)} cannot be empty.", nameof(name));
            if (name.Contains(" ")) throw new ArgumentException($"{nameof(name)} cannot contain spaces.", nameof(name));
            if (name.Contains("=")) throw new ArgumentException($"{nameof(name)} cannot contain equal signs.", nameof(name));

            return !((value = Environment.GetEnvironmentVariable(name)) is null);
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

            try
            {
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
            catch (System.Security.SecurityException)
            {
                return false;
            }
        }

        // MMM Comment: Wow!  Great job with this.
        public IEnumerator<(string name, string value)> GetEnumerator() =>
            Environment.GetEnvironmentVariables()
                       .Cast<DictionaryEntry>()
                       .Select(kv => ((string)kv.Key, (string)kv.Value))
                       .GetEnumerator();

        // MMM Comment: Great choice to make this an explicit implementation.
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
