using System;

namespace Assignment
{
    public class Address : IAddress, IEquatable<Address>, IComparable<Address>
    {
        public string StreetAddress { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Zip { get; set; } = "";

        public override bool Equals(object? obj) =>
            obj is Address address && Equals(address);

        public bool Equals(Address other)
        {
            if (other is null) return false;

            return StreetAddress == other.StreetAddress && City == other.City
                && State == other.State && Zip == other.Zip;
        }

        public static bool operator ==(Address leftSide, Address rightSide)
            => leftSide?.Equals(rightSide) ?? false;

        public static bool operator !=(Address leftSide, Address rightSide)
            => !(leftSide?.Equals(rightSide) ?? false);

        public override int GetHashCode() =>
            (StreetAddress, City, State, Zip).GetHashCode();

        public int CompareTo(Address other)
        {
            int compState = string.Compare(State, other?.State);
            if (compState != 0) return compState;

            int compCity = string.Compare(City, other?.City);
            if (compCity != 0) return compCity;

            return string.Compare(Zip, other?.Zip);
        }
    }
}
