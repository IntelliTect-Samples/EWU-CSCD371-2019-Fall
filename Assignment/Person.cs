using System;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName  { get; set; }  = string.Empty;
        public string LastName   { get; set; }  = string.Empty;
        public IAddress? Address { get; set; }

        public override bool Equals(object other)
        {
            if (other is IPerson p)
                return FirstName == p.FirstName &&
                    LastName == p.LastName &&
                    Address.Equals(p.Address);
            else if (other is null)
                throw new ArgumentNullException($"{nameof(other)} cannot be null", nameof(other));
            else
                throw new ArgumentException($"{nameof(other)} must implement {nameof(IPerson)}", nameof(other));
        }

        public override int GetHashCode()
        {
            if (Address is null)
                throw new InvalidOperationException($"Cannot compare before setting {nameof(Address)}");
            return FirstName.GetHashCode() ^
                LastName.GetHashCode() ^
                Address.GetHashCode();
        }
    }
}
