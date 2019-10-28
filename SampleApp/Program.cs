using Configuration;
using System;

namespace SampleApp {
    class Program {
        static void Main() {
            EnvironmentConfig config = new EnvironmentConfig();
            string[] configNames = { "Day", "Name", "Time" };
            string[] values = { "Monday", "Joel", "Too Late" };
            for (int i = 0;i<configNames.Length;i++) {
                config.SetConfigValue(configNames[i], values[i]);
            }
            foreach (string name in configNames) {
                string value;
                config.GetConfigValue(name, out value);
                Console.WriteLine($"{name}={value}");
            }
        }
    }
}
