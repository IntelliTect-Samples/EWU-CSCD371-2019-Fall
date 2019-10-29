using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    public class Program
    {
        static void Main()
        {
            string[] types = { "type1", "type2", "type3", "type4", "type5" };
            string[] values = { "value1", "value2", "value3", "value4", "value5" };

            FileConfig fileConfig = new FileConfig();

            for(int i = 0; i < types.Length; i++)
            {
                fileConfig.FileWrite(types[i],values[i]);
            }

            Console.WriteLine(fileConfig.FileRead());
        }
    }
}
