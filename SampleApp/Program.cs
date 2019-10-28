using iTextSharp.text;
using System;
using System.Collections.Generic;
using Configuration;

namespace SampleApp
{
    public class Program
    {
        
        static void Main()
        {
        }

        public static void PrintList(List<MockConfig.MockSetting> list)
        {
            foreach(MockConfig.MockSetting item in list)
            {
                Console.WriteLine(item.name + " : " + item.value);
            }
        }
    }
}
