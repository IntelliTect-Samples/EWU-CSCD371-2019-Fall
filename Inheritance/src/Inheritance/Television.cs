using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Television : Item
    {
        public string Manufacturer { get; set; }
        public double Size { get; set; }

        public override string ReturnInfo()
        {
            return $"{Manufacturer} - {Size}";
        }
    }
}
