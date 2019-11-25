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

        public bool Equals(IAddress other) =>
            (StreetAddress, City, State, Zip) == (other.StreetAddress, other.City, other.State, other.Zip);

        public override bool Equals(object obj) =>
            obj is IAddress address && Equals(address);

        public override int GetHashCode() =>
            (StreetAddress, City, State, Zip).GetHashCode();
    }
}
