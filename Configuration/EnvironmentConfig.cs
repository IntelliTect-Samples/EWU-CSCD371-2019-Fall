using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration {
    class EnvironmentConfig : IConfig {
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

        public bool SetConfigValue(string name, string? value) {
            if (Environment.GetEnvironmentVariables().Contains(name)) {
                try {
                    Environment.SetEnvironmentVariable(name, value);
                } catch (ArgumentNullException) {
                    return false;
                } catch (ArgumentException) {
                    return false;
                }
            }
            return true;
        }
    }
}
