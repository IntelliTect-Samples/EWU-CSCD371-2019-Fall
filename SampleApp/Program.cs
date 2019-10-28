using Configuration;
using System.Collections.Generic;

namespace SampleApp {
    class Program {
        static void Main() {
            EnvironmentConfig config = new EnvironmentConfig();
            string[] configNames = { "Day", "Name", "Time" };
            string[] values = { "Monday", "Joel", "Too Late" };
            List<string[]> configList= createList(configNames, values);

        }

        static List<string[]> createList(string[] configNames, string[] values) {
            List<string[]> results = new List<string[]>();
            for (int i = 0; i < configNames.Length; i++) {
                results.Add(new string[] { configNames[i], values[i] });
            }
            return results;
        }
    }
}
