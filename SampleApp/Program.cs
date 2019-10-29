using Configuration;
using Mock;
using System;

namespace SampleApp
{
    class Program
    {
        static void Main()
        {
            string[] names = { "nameA", "nameB", "nameC" };
            string[] values = { "valueA", "valueB", "valueC" };

            MockConfig config = new MockConfig();

            for(int i = 0; i < names.Length; i++)
            {
                config.SetConfigValue(names[i], values[i]);
                Console.WriteLine($"{names[i]}={values[i]}");
            }

            
        }
    }
}
