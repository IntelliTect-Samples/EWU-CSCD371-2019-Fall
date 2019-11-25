using System;

namespace Assignment
{
    public class Address : IAddress
    {
        public string StreetAddress { get; }
        public string City { get; }
        public string State { get; }
        public string Zip { get; }

        public Address(string streetAddress, string city, string state, string zip)
        {
            StreetAddress = streetAddress ?? throw new ArgumentNullException(nameof(streetAddress));
            City = city ?? throw new ArgumentNullException(nameof(city));
            State = state ?? throw new ArgumentNullException(nameof(state));
            Zip = zip ?? throw new ArgumentNullException(nameof(zip));
        }
    }
}
