using Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mocks
{
    public class MockConfig : IConfig, IEnumerable<(string name, string value)>
    {
        public IDictionary<string, string> Settings { get; } = new Dictionary<string, string>();

        public bool GetConfigValue(string name, out string? value) => Settings.TryGetValue(name, out value);

        public bool SetConfigValue(string name, string value) => (Settings[name] = value) == value;

        public IEnumerator<(string name, string value)> GetEnumerator() =>
            Settings.Select(kv => (kv.Key, kv.Value))
                    .GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
