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
            if (Upc is null || Upc == "")
            {
                throw new ArgumentNullException("UPC is missing or null", new ArgumentNullException());
            } else if (Brand is null || Brand == "")
            {
                throw new ArgumentNullException("Brand is missing or null", new ArgumentNullException());
            }
            return $"{Upc} - {Brand}";
        }
    }
}
