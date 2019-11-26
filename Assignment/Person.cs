using System.Linq;
using System.Collections.Generic;
using System;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get;set; }
        public string EmailAddress { get; set; }

        public Person(string firstName, string lastName, IAddress address, string emailAddress)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
        }
    }
}
