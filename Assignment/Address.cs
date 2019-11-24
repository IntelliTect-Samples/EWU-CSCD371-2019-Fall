using System;

namespace Assignment
{
    public class Address : IAddress
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public Address(string csvRow)
        {
            string[] data = csvRow.Split(',');
            StreetAddress = data[(int)SampleData.Information.StreetAddress];
            City = data[(int)SampleData.Information.City];
            State = data[(int)SampleData.Information.State];
            Zip = data[(int)SampleData.Information.Zip];
        }

        public override bool Equals(object? obj)
        {
            return obj is Address address &&
                   StreetAddress.Equals(address.StreetAddress) &&
                   City.Equals(address.City) &&
                   State.Equals(address.State) &&
                   Zip.Equals(address.Zip);
        }

        public override int GetHashCode()
        {
            return (StreetAddress, City, State, Zip).GetHashCode();
        }
    }
}