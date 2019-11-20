using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    public interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        IAddress Address { get; }

        /*
        string StreetAddress { get; }
        string City { get; }
        string State { get; }
        string Zip { get; }
        */
    }
}
