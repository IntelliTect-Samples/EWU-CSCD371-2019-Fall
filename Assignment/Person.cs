using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName { get; }
        public string LastName { get; }
        public IAddress Address { get; }
        public string EmailAddress { get; }

        public Person(string firstName, string lastName, string emailAddress, IAddress address)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
    }
}
