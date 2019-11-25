using System;

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
            if (string.IsNullOrEmpty(streetAddress)) throw new ArgumentNullException(nameof(streetAddress));
            if (string.IsNullOrEmpty(city)) throw new ArgumentNullException(nameof(city));
            if (string.IsNullOrEmpty(state)) throw new ArgumentNullException(nameof(state));
            if (string.IsNullOrEmpty(zip)) throw new ArgumentNullException(nameof(zip));

            StreetAddress = streetAddress;
            City = city;
            State = state;
            Zip = zip;
        }
    }
}
