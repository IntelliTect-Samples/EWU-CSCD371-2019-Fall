using System;
using System.Collections.Generic;
<<<<<<< HEAD

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool ReadConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        public bool WriteConfigValue(string name, string? value)
        {
            if (value is null)
            {
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
            if (string.IsNullOrEmpty(name) || name.Contains(" ") || name.Contains("=") ||
                value.Contains(" ") || value.Contains("=") || value.Equals(""))
=======
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
>>>>>>> Assignment4
            {
                return false;
            }
            Environment.SetEnvironmentVariable(name, value);
<<<<<<< HEAD
            return true;
        }
=======
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
>>>>>>> Assignment4
    }
}
