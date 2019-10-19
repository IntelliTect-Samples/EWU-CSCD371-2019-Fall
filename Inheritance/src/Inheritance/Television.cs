using System;

namespace Inheritance
{
    public class Television : IItem
    {
        public string Manufacturer { get; set; }
        public string Size { get; set; }
        public string PrintInfo() => $"{Manufacturer} {Size}";
    }
}
