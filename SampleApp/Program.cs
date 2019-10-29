using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    public class Program
    {
        private static MockLogger mockLogger = new MockLogger();

        static void Main()
        {
            mockLogger.SetConfigValue("Var0", "yes");
            mockLogger.SetConfigValue("Var1", "no");
            mockLogger.SetConfigValue("Var2", "maybe");

            string? toPrint;

            mockLogger.GetConfigValue("Var0", out toPrint);
            Console.WriteLine(toPrint);

            mockLogger.GetConfigValue("Var1", out toPrint);
            Console.WriteLine(toPrint);

            mockLogger.GetConfigValue("Var2", out toPrint);
            Console.WriteLine(toPrint);
        }

        public class MockLogger : IConfig
        {
            private List<string> settingsList = new List<string>();

            public bool GetConfigValue(string name, out string? value)
            {
                if (!isValidName(name))
                {
                    value = null;
                    return false;
                }

                foreach(string s in settingsList)
                {
                    if (s.StartsWith(name, StringComparison.CurrentCulture))
                    {
                        string[] nameAndValue = s.Split('=');
                        if(nameAndValue.Length != 2) { throw new FormatException("Invalid Setting In Memory"); }

                        value = nameAndValue[1];
                        return true;
                    }
                }

                value = null;
                return false;
            }

            public bool SetConfigValue(string name, string? value)
            {
                if (!isValidName(name) || value is null) { return false; }

                settingsList.RemoveAll(x => x.StartsWith(name, StringComparison.CurrentCulture));

                settingsList.Add(name + '=' + value);

                return true;
            }

            private static bool isValidName(string name)
            {
                if (string.IsNullOrEmpty(name) || name.Contains(' ', StringComparison.CurrentCulture) || name.Contains('=', StringComparison.CurrentCulture))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
