using System;
using System.Collections.Generic;
using System.Configuration;
namespace Configuration
{
    public class EnvironmentConfig : IConfig
    { 
        private List<string> usedVariableNames;

        public EnvironmentConfig()
        {
            usedVariableNames = new List<string>();
        }

        public bool GetConfigValue(string name, string? value)
        {
            if (name is null) return false; 
            var variable = Environment.GetEnvironmentVariable(name);
            return !(variable is null);
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (name.Contains(" ") || name.Contains("=") || name.Equals("") || name is null)
            {
                return false;
            }
            Environment.SetEnvironmentVariable(name, value);
            usedVariableNames.Add(name);
            return true;
        }

        public void DeleteCreatedVariables()
        {
            foreach (string item in usedVariableNames)
            {
                Environment.SetEnvironmentVariable(item, null);
            }
        }
    }
}
