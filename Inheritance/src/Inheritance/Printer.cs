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
                Food food = new Food("Frosted Mini Wheats", "123456789");
                Printer.Print(food, sw);
                sw.Flush();

                Television television = new Television("60", "LG");
                Printer.Print(television, sw);
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
