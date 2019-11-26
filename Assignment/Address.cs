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
            if (csvRow is null)
                throw new ArgumentNullException(nameof(csvRow));
            string[] data = csvRow.Split(',');
            StreetAddress = data[(int)SampleData.Column.StreetAddress];
            City = data[(int)SampleData.Column.City];
            State = data[(int)SampleData.Column.State];
            Zip = data[(int)SampleData.Column.Zip];
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