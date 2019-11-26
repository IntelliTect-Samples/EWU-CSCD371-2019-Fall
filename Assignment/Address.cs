using System;
using System.Linq;

namespace Assignment
{
    public class Address : IAddress
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address(string streetAddress, string city, string state, string zip)
        {
            StreetAddress = streetAddress ?? throw new ArgumentNullException(nameof(streetAddress));
            City = city ?? throw new ArgumentNullException(nameof(city));
            State = state ?? throw new ArgumentNullException(nameof(state));
            Zip = zip ?? throw new ArgumentNullException(nameof(zip));
        }

        public bool Equal(IAddress other)
        {
            if(!(other is null))
                return (StreetAddress == other.StreetAddress &&
                City == other.City &&
                State == other.State
                && Zip == other.Zip);
            return false;
        }
    }
}
