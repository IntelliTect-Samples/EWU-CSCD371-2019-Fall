using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inheritance
{
    public class Program
    {
        public static void Main()
        {
            using (var sw = new StreamWriter(Console.OpenStandardOutput()))
            {
                Printer.Print(new Food { Brand = "Frosted Mini Wheats", Upc = "123456789" }, sw);
                sw.Flush();
            }
        }
    }
    public static class Printer
    {
        public static void Print(Item item, TextWriter writer)
        {
            writer.WriteLine(item.PrintInfo());
        }
    }
}
