using System.Linq;
using System.Collections.Generic;
using System;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get; set; }
        public string EmailAddress { get; set; }

        public Person(string firstName, string lastName, IAddress address, string emailAddress)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
        }

        public int CompareTo(Person person)
        {
            if (person is null)
                throw new ArgumentNullException(nameof(person));
            if (string.Compare(Address.State, person.Address.State, StringComparison.CurrentCulture) == 0)
            {
                if (string.Compare(Address.City, person.Address.City, StringComparison.CurrentCulture) == 0)
                {
                    if (string.Compare(Address.Zip, person.Address.Zip, StringComparison.CurrentCulture) == 0)
                    {
                        return 0;
                    }
                    return string.Compare(Address.State, person.Address.State, StringComparison.CurrentCulture);
                }
                return string.Compare(Address.City, person.Address.City, StringComparison.CurrentCulture);
            }
            return string.Compare(Address.State, person.Address.State, StringComparison.CurrentCulture);
        }

        public bool Equal(IPerson other)
        {
            if(!(other is null))
                return FirstName == other.FirstName &&
                LastName == other.LastName &&
                EmailAddress == other.EmailAddress &&
                Address.Equal(other.Address);
            return false;
        }
    }
}
