using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Food : Item
    {
        public string Upc { get; }
        public string Brand { get; }

        public Food(string upc, string brand)
        {
            if (upc is null) throw new ArgumentNullException(nameof(Upc));
            if (brand is null) throw new ArgumentNullException(nameof(Brand));
            Upc = upc;
            Brand = brand;
        }

        public override string PrintInfo()
        {
            return $"<{Upc}> - <{Brand}>";
        }
    }
}
