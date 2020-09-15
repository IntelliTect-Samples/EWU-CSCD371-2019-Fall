using System.Linq;
using System.Collections.Generic;

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
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new System.ArgumentException("Parameter cannot be null or whitespace", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new System.ArgumentException("Parameter cannot be null or whitespace", nameof(lastName));
            }

            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new System.ArgumentException("Parameter cannot be null or whitespace", nameof(emailAddress));
            }

            FirstName = firstName;
            LastName = lastName;
            Address = address ?? throw new System.ArgumentNullException(nameof(address));
            EmailAddress = emailAddress;
        }
    }
}
