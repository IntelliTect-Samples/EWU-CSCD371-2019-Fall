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
                throw new ArgumentNullException("Upc is null");
            if (Brand is null)
                throw new ArgumentNullException("Brand is null");
            return $"{Upc} - {Brand}";
        }
    }
}
