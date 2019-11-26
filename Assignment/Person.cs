using System.Linq;
using System.Collections.Generic;

namespace Assignment
{
    public class Person : IPerson
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public IAddress Address { get;set; } = new Address();

        public string EmailAddress { get; set; } = "";
    }
}
