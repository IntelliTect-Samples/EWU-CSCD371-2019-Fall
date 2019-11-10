using Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApp
{
    public static class Program
    {
        // MMM Comment: Yes, Tuples!
        public static readonly (string name, string value)[] Vars = new[] { ("var1", "val1"), ("var2", "val2"), ("var3", "val3") };

        // MMM Comment: My instructions were confusing! Why hardcode to use MockConfig?
        // Shouldn't it hard code to use FileConfig/EnvironmentConfig and MockConfig 
        // only for testing?
        public static void Main() => Run(new Mocks.MockConfig());

        public static void Run(IConfig config)
        {
            if (config is null) throw new ArgumentNullException(nameof(config));

            foreach (var (name, value) in Vars) config.SetConfigValue(name, value);

            string vars;

            if (config is IEnumerable<(string name, string value)> iterable)
            {
                vars = string.Join(Environment.NewLine, iterable.Select(setting => $"{setting.name} = {setting.value}"));
            }
            else
            {
                var temp = new StringBuilder();
                foreach ((string name, _) in Vars)
                {
                    bool success = config.GetConfigValue(name, out var value);
                    temp.Append($"{name} = {value}");
                }
                vars = temp.ToString();
            }

            Console.WriteLine(vars);
        }
    }
}
