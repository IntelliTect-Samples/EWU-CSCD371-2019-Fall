using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Television : IItem
    {
        public string Manufacturer { get; set; }
        public double Size { get; set; }

        public string ReturnInfo()
        {
            return $"{Manufacturer} - {Size}";
        }
    }
}
