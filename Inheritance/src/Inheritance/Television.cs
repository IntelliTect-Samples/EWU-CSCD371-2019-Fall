using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Television : Item
    {
        public string Manufacturer { get; set; }
        public int Size { get; set; }

        public override string PrintInfo()
        {
            if(Size == 0)
            {
                return $"{Manufacturer}";
            }
            else
            {
                return $"{Manufacturer} - {Size}";
            }
        }
    }
}
