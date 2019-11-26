using System;

namespace Assignment
{
    public class Person : IPerson, IEquatable<Person>
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public IAddress Address { get; set; } = new Address();

        public override int GetHashCode() =>
            (FirstName, LastName, EmailAddress, Address.GetHashCode()).GetHashCode();

        #region IEquatable methods
        public override bool Equals(object? obj) =>
            obj is Person person && Equals(person);

        public bool Equals(Person other)
        {
            if (other is null) return false;

            return LastName == other.LastName 
                && FirstName == other.FirstName 
                && EmailAddress == other.EmailAddress
                && ((Address) Address).Equals((Address) other.Address);
        }

        public static bool operator ==(Person leftSide, Person rightSide) 
            => leftSide?.Equals(rightSide) ?? false;

        public static bool operator !=(Person leftSide, Person rightSide)
            => !(leftSide?.Equals(rightSide) ?? false);
        #endregion
    }
}
