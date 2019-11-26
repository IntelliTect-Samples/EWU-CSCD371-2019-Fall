﻿using System;

namespace Assignment
{
    public class Address : IAddress
    {
        public Address(string streetAddress, string city, string state, string zip)
        {
            StreetAddress = streetAddress ?? throw new ArgumentNullException(nameof(streetAddress));
            City = city ?? throw new ArgumentNullException(nameof(city));
            State = state ?? throw new ArgumentNullException(nameof(state));
            Zip = zip ?? throw new ArgumentNullException(nameof(zip));
        }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        //for testing purposes.
        public override string ToString()
        {
            return ($"{StreetAddress}, {City}, {State}, {Zip}");
        }
    }
}
