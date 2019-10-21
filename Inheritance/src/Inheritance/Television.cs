using System;

namespace Inheritance
{
    public class Television : Item
    {
        public string Size { get; set; }
        public string Manufacturer { get; set; }

        public override string PrintInfo()
        {
            if (Size is null || Size == "")
            {
                throw new ArgumentNullException("Size is missing or null", new ArgumentNullException());
            }
            else if (Manufacturer is null || Manufacturer == "")
            {
                throw new ArgumentNullException("Manufacturer is missing or null", new ArgumentNullException());
            }
            return $"{Manufacturer} - {Size}";
        }
    }
}