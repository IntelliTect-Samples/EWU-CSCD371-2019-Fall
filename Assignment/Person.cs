using System;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }

        public Address Address { get;set; }

        public Person(string fname, string lname, string streetAddress, string city, string state, string zip, string email)
        {
            FirstName = fname ?? throw new ArgumentNullException(nameof(fname));
            LastName = lname ?? throw new ArgumentNullException(nameof(lname));
            StreetAddress = streetAddress ?? throw new ArgumentNullException(nameof(streetAddress));
            City = city ?? throw new ArgumentNullException(nameof(fname));
            State = state ?? throw new ArgumentNullException(nameof(state));
            Zip = zip ?? throw new ArgumentNullException(nameof(zip));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Address = new Address(streetAddress, city, state, zip);
        }

    }
}
