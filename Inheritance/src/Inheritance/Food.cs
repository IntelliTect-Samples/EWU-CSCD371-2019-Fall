using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Food : IItem
    {
        public string Upc { get; set; }
        public string Brand { get; set; }
        public string PrintInfo() => $"{Upc} - {Brand}";
    }
}
