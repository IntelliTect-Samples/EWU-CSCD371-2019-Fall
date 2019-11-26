using System;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get; set; }
        public string EmailAddress { get; set; }

        public Person(string firstName, string lastName, IAddress address, string email)
        {
            if (string.IsNullOrEmpty(firstName)) throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrEmpty(lastName)) throw new ArgumentNullException(nameof(lastName));
            if (address is null) throw new ArgumentNullException(nameof(address));
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            FirstName = firstName;
            LastName = lastName;
            Address = address;
            EmailAddress = email;
        }
    }
}