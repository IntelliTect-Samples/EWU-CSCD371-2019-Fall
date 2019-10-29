using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    public static class Program
    {
        private static MockConfig mockConfig = new MockConfig();

        static void Main()
        {
            mockConfig.SetConfigValue("Var0", "yes");
            mockConfig.SetConfigValue("Var1", "no");
            mockConfig.SetConfigValue("Var2", "maybe");

            string? toPrint;

            mockConfig.GetConfigValue("Var0", out toPrint);
            Console.WriteLine(toPrint);

            mockConfig.GetConfigValue("Var1", out toPrint);
            Console.WriteLine(toPrint);

            mockConfig.GetConfigValue("Var2", out toPrint);
            Console.WriteLine(toPrint);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible", 
            Justification = "This is required in order to Unit Test according to instructions without circular dependency")]
        public class MockConfig : IConfig
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
