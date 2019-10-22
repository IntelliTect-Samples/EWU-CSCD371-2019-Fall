using System;
namespace Inheritance
{
    public class Television : Item
    {
        public string Size { get; }
        public string Manufacturer { get; }

        public Television(string size, string manufacturer)
        {
            if (size is null) throw new ArgumentNullException(nameof(Size));
            if (manufacturer is null) throw new ArgumentNullException(nameof(manufacturer));
            Size = size;
            Manufacturer = manufacturer;
        }

        public override string PrintInfo()
        {
            return $"<{Manufacturer}> - <{Size}>";
        }
    }
}
