using System;

namespace Inheritance
{
    public class Television : Item
    {
        string Size { get; }
        string Manufacturer { get; }

        public Television(string size, string manufacturer)
        {
            if (size is null) throw new ArgumentNullException(nameof(Size));
            if (manufacturer is null) throw new ArgumentNullException(nameof(manufacturer));
            Size = size;
            Manufacturer = manufacturer;
        }

        public string PrintInfo() => $"<{Manufacturer}> - <{Size}>";
    }
}
