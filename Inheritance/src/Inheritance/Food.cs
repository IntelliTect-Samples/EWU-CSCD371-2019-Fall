using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Food : Item
    {
        public string? Upc { get; set; }
        public string? Brand { get; set; }

        public string PrintInfo() => (Upc, Brand) switch
        {
            (null, _) => throw new ArgumentNullException(nameof(Upc)),
            (_, null) => throw new ArgumentNullException(nameof(Brand)),
            (_, _)    => $"<{Upc}> - <{Brand}>"
        };
    }
}
