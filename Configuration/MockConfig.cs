using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public class MockConfig : IConfig   
    {
        // MMM Comment: _MockNames (or _mockNames) to distinguish from local variable.
        private readonly List<String> mockNames = new List<String>();
        private readonly List<String> mockValues = new List<String>();

        public bool GetConfigValue(string name, out string? value)
        {
            if(IsValidInput(name) || !(mockNames is null))
            {
                foreach (String mockName in mockNames)
                {
                    foreach(String mockValue in mockValues)
                    {
                        if(mockName.Equals(name, new StringComparison()))
                        {
                            value = mockValue;
                            return true;
                        }
                    }
                }
            }

            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (IsValidInput(name) && !(value is null))
            {
                mockNames.Add(name);
                mockValues.Add(value);
                return true;
            }

            return false;
        }

        // MMM Comment: Seems like this should be refactored.
        public static bool IsValidInput(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Contains(" ") || name.Contains("="))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
