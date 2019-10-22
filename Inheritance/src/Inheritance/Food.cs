using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{

    public class Food : Item
    {

        public string Upc   { get; set; }
        public string Brand { get; set; }

        public override string PrintInfo()
        {
            if (Upc is null)
            {
                throw new ArgumentException("null", nameof(Upc));
            }

            if (Brand is null)
            {
                throw new ArgumentException("null", nameof(Brand));
            }

            return $"{(Upc.Length != 0 ? Upc : "Invalid UPC")} - {(Brand.Length != 0 ? Brand : "Unknown Brand")}";
        }

    }

}
