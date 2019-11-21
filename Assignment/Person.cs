using System;

#pragma warning disable CA1307

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName  { get; set; }  = string.Empty;
        public string LastName   { get; set; }  = string.Empty;
        public IAddress? Address { get; set; }

        public override bool Equals(object other)
        {
            if (other is IPerson p && !(Address is null))
                return FirstName == p.FirstName &&
                    LastName == p.LastName &&
                    Address.Equals(p.Address);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Address is null ?
                FirstName.GetHashCode() ^
                LastName.GetHashCode() :
                FirstName.GetHashCode() ^
                LastName.GetHashCode() ^
                Address.GetHashCode();
        }
    }
}
