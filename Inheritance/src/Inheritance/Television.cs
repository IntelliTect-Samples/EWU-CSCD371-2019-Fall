using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Television : Item
    {
        public string Manufacturer { get; set; }
        public string Size { get; set; }
        public override string PrintInfo() => $"{Manufacturer} - {Size}";
    }
}
