using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Food : Item
    {
        public string Upc { get; set; }
        public string Brand { get; set; }

        public override string PrintInfo()
        {
            if (Upc is null)
            {
                throw new ArgumentNullException("UPC is null", new ArgumentNullException());
            }
            return $"{Upc} - {Brand}";
        }
    }
}
