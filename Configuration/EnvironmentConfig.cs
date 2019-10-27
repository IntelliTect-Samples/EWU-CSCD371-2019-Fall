using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration {
    class EnvironmentConfig : IConfig {
        private List<String> names;

        public bool GetConfigValue(string name, out string? value) {
            value = null;
            try {
                value = Environment.GetEnvironmentVariable(name);
            } catch (ArgumentNullException) {
            }
            if (value is null) {
                return false;
            }
            return true;
        }

        internal List<string> getNames() {
            return this.names;
        }

        public bool SetConfigValue(string name, string? value) {
            if (InputIsValid(name, value)) {
                try {
                    Environment.SetEnvironmentVariable(name, value);
                    names.Add(name);
                } catch (ArgumentNullException) {
                    return false;
                } catch (ArgumentException) {
                    return false;
                }
                return true;
            }
            return false;
        }

        private static bool InputIsValid(string? name, string? value) {
            return !(name is null || name is "" || value is null || value is "" || name.Contains("=") || name.Contains(" "));
        }

        ~EnvironmentConfig() {
            foreach (string name in names) {
                Environment.SetEnvironmentVariable(name, null);
            }
        }
    }
}
