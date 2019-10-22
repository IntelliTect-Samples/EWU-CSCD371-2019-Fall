using System;

namespace Inheritance
{

    public class Television : Item
    {

        public string Manufacturer { get; set; }
        public int    Size         { get; set; }

        public override string PrintInfo()
        {
            if (Manufacturer is null)
            {
                throw new ArgumentException("null", nameof(Manufacturer));
            }

            return $"{(Manufacturer.Length != 0 ? Manufacturer : "Unknown Manufacturer")} - {Size}";
        }

    }

}
