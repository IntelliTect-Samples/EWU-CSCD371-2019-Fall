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
            if (Manufacturer is null)
                throw new ArgumentNullException("Manufacturer is null");
            if (Size is 0)
                throw new ArgumentNullException("Size is not set");
            return $"{Manufacturer} - {Size}";
        }
    }
}
